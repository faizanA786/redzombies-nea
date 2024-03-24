using UnityEngine;

public class ExploderEnemy : MonoBehaviour
{
    public float movementSpeed;
    public float enemyHealth;
    public GameObject playerObject;
    public GameObject gameProcessingObject;
    public GameObject explosionObject;
    Player player;
    GameProcessing gameProcessing;
    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameProcessingObject = GameObject.Find("GameProcessing");
        playerObject = GameObject.Find("Player");

        player = playerObject.GetComponent<Player>(); //Fetch player class
        gameProcessing = gameProcessingObject.GetComponent<GameProcessing>();
    }

    void Update()
    {
        Movement();

        if (enemyHealth <= 0)
        {
            player.playerPoints += 20;
            gameProcessing.enemiesToKill -= 1;
            Instantiate(explosionObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
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

}
