using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float deathTimer = 0.5f;

    void Update()
    {
        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D body)
    {
        Player isPlayer = body.gameObject.GetComponent<Player>();
        Enemy isEnemy = body.gameObject.GetComponent<Enemy>();
        ExploderEnemy isExploderEnemy = body.gameObject.GetComponent<ExploderEnemy>();
        if (isPlayer != null)
        {
            isPlayer.playerHealth -= 2;
            isPlayer.DamagePlayer();
        }
        if (isEnemy != null)
        {
            isEnemy.enemyHealth -= 2;
            isEnemy.DamageEnemy();
        }
        if (isExploderEnemy != null)
        {
            isExploderEnemy.enemyHealth -= 2;
            isExploderEnemy.DamageEnemy();
        }
    }
}
