using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public float enemyHealth;
    public float maxEnemyHealth;
    public static bool instantKill = false;
    public static int doublePoints = 1;
    public GameObject playerObject;
    public GameObject gameProcessingObject;
    public GameObject healthbarSlider;
    public GameObject powerupObject;
    EnemyHealthbar healthbar;
    Player player;
    GameProcessing gameProcessing;
    Rigidbody2D rb;

    void Start()
    {
        healthbar = healthbarSlider.GetComponent<EnemyHealthbar>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameProcessingObject = GameObject.Find("GameProcessing");
        playerObject = GameObject.Find("Player");

        player = playerObject.GetComponent<Player>(); //Fetch player class
        gameProcessing = gameProcessingObject.GetComponent<GameProcessing>();
        healthbar.SetHealthbar(enemyHealth, maxEnemyHealth);
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 distanceFromPlayer;
        distanceFromPlayer = playerObject.transform.position - transform.position;
        //Calculate distance between this object and the player object
        distanceFromPlayer.Normalize();
        //Set magnitude to this vector to 1
        rb.velocity = distanceFromPlayer * movementSpeed;
        //Set velocity to this direction multiplied by the speed
    }

    public void DamageEnemy() 
    {
        if (instantKill)
        {
            enemyHealth -= 100;
        }
        else
        {
            float bulletDamage = Random.Range(0.5f, 1f);
            enemyHealth -= bulletDamage;
        }

        if (enemyHealth <= 0)
        {
            Eliminate();
        }
        healthbar.SetHealthbar(enemyHealth, maxEnemyHealth);
    }

    void Eliminate()
    {
        player.totalPoints += (20 * doublePoints);
        player.playerPoints += (20 * doublePoints);
        gameProcessing.enemiesToKill -= 1;
        int randomChance = Random.Range(1, 51); // generate number between 1-50
        if (randomChance == 1) // 2% chance to execute
        {
            Instantiate(powerupObject,transform.position,transform.rotation);
        }
        Destroy(gameObject);
    }

}
