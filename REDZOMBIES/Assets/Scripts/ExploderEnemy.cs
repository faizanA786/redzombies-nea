using UnityEngine;

public class ExploderEnemy : MonoBehaviour
{
    public float movementSpeed;
    public float enemyHealth;
    public float maxEnemyHealth;
    public static bool instantKill = false;
    public static int doublePoints = 1;
    public GameObject playerObject;
    public GameObject gameProcessingObject;
    public GameObject explosionObject;
    public GameObject healthbarSlider;
    EnemyHealthbar healthbar;
    Player player;
    GameProcessing gameProcessing;
    Rigidbody2D rb;

    void Start()
    {
        enemyHealth = maxEnemyHealth;
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

    public void OnCollisionEnter2D(Collision2D body)
    {
        Player isPlayer = body.gameObject.GetComponent<Player>();
        if (isPlayer != null)
        {
            Instantiate(explosionObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
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
        player.playerPoints += (30 * doublePoints);
        player.totalPoints += (30 * doublePoints);
        gameProcessing.enemiesToKill -= 1;
        Instantiate(explosionObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
