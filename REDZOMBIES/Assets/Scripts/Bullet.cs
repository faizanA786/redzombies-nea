using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed; //Value set in inspector
    public GameObject playerObject;
    public GameObject explosionObject;
    float deathTimer = 4f; //Value responsible for how long object will exist
    Rigidbody2D rb;
    Player player;

    void Start()
    {
        playerObject = GameObject.Find("Player");

        rb = gameObject.GetComponent<Rigidbody2D>(); //Reference objects rigidbody
        player = playerObject.GetComponent<Player>();
    }

    void Update()
    {
        rb.velocity = transform.up * bulletSpeed; //Move object forward
        deathTimer -= Time.deltaTime; //Reduce time each second 
        if (deathTimer <= 0) 
        {
            Destroy(gameObject); //Delete this object from the scene
        }
    }

    public void OnTriggerEnter2D(Collider2D body)//Called once the moment a collisions been made
    {
        Collider2D hasCollider = body.gameObject.GetComponent<Collider2D>();
        //Attempt to fetch the collider component attatched to the object collided with
        string isTrigger = body.gameObject.name; //Fetch name of collided game object
        Enemy isEnemy = body.gameObject.GetComponent<Enemy>();
        ExploderEnemy isExploderEnemy = body.gameObject.GetComponent<ExploderEnemy>();

        if (hasCollider != null && isTrigger != "DetectPlayer")
        //If the collided object does have a collider and isTrigger not holding DetectPlayer text
        {
            if (player.weaponSelected == 4) //Rocket launcher
            {
                Instantiate(explosionObject, transform.position, transform.rotation);
            }

            if (isEnemy != null && isEnemy.enemyHealth > 0)
            {
                isEnemy.DamageEnemy();
            }
            else if (isExploderEnemy != null && isExploderEnemy.enemyHealth > 0)
            {
                isExploderEnemy.DamageEnemy();
            }
            Destroy(gameObject); 
        }
    }
}
