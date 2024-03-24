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
            isPlayer.playerHealth -= 3;
        }
        else if (isEnemy != null)
        {
            isEnemy.enemyHealth -= 3;
        }
        else if (isExploderEnemy != null)
        {
            isExploderEnemy.enemyHealth -= 3;
        }
    }
}
