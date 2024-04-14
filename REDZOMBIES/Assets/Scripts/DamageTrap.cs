using UnityEngine.UI;
using UnityEngine;

public class DamageTrap : MonoBehaviour
{ 
    float damageTimer = 0.6f;
    float regenTimer;
    bool deactivated = false;
    float trapMaxHealth = 40f;
    public float trapHealth = 40f;
    public LayerMask enemyLayer;
    public GameObject healthbarSlider;
    TrapHealthbar healthbar;
    void Start()
    {
        healthbar = healthbarSlider.GetComponent<TrapHealthbar>();
        healthbar.SetHealthbar(trapHealth, trapMaxHealth);
    }

    void Update()
    {
        if (trapHealth <= 0 || deactivated)
        {
            if (trapHealth >= trapMaxHealth)
            {
                deactivated = false;
            }
            else if (trapHealth < trapMaxHealth && regenTimer <= 0)
            {
                deactivated = true;
                regenTimer = 1f;
                trapHealth += 1f;
                healthbar.SetHealthbar(trapHealth, trapMaxHealth);
            }
        }
        regenTimer -= Time.deltaTime;
        damageTimer -= Time.deltaTime;

        //Check for colliders in the circle on a specific layer
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f, enemyLayer);

        if (damageTimer <= 0 && !deactivated)
        {
            foreach (Collider2D collider in colliders)
            {

                Enemy enemyClass = collider.gameObject.GetComponent<Enemy>();
                ExploderEnemy exploderEnemyClass = collider.gameObject.GetComponent<ExploderEnemy>();
                if (enemyClass != null)
                {
                    enemyClass.DamageEnemy();
                    //Damage trap by random amount between 0.5 - 1
                }
                if (exploderEnemyClass != null)
                {
                    exploderEnemyClass.DamageEnemy();
                }
            }

            if (colliders.Length > 0)
            {
                trapHealth -= Random.Range(0.5f, 1f);
                healthbar.SetHealthbar(trapHealth, trapMaxHealth);
            }
            damageTimer = 0.8f;
        }

    }
}
