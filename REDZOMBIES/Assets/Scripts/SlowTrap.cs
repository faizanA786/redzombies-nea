using UnityEngine.UI;
using UnityEngine;

public class SlowTrap : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D body)
    {
        Enemy isEnemy = body.gameObject.GetComponent<Enemy>();
        ExploderEnemy isExploderEnemy = body.gameObject.GetComponent<ExploderEnemy>();
        if (isEnemy != null)
        {
            isEnemy.movementSpeed *= 0.6f;
        }
        if (isExploderEnemy != null)
        {
            isExploderEnemy.movementSpeed *= 0.6f;
        }
    }

    public void OnTriggerExit2D(Collider2D body)
    {
        Enemy isEnemy = body.gameObject.GetComponent<Enemy>();
        ExploderEnemy isExploderEnemy = body.gameObject.GetComponent<ExploderEnemy>();
        if (isEnemy != null)
        {
            isEnemy.movementSpeed /= 0.6f;
        }
        if (isExploderEnemy != null)
        {
            isExploderEnemy.movementSpeed /= 0.6f;
        }
    }
}

