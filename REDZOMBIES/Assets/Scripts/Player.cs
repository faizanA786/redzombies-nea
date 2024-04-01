using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed; //value set in inspector window
    public int playerMaxHealth = 3;
    public int playerHealth;
    public int playerPoints = 0;
    public int totalPoints = 0;
    public int bulletCapacity = 100;
    float shootTimer; //Differing values are set in Shoot()
    public int weaponSelected; //Holds the value of the weapon currently assigned
    float attackTimer = 1.2f;//Speed at which enemy can 'attack' player

    public GameObject weaponSprite; //References weapon object
    public GameObject bulletObject; //References bullet object
    SpriteRenderer sprite;
    Rigidbody2D rb;

    void Start() //Initialisation, called on first frame
    {
        playerHealth = playerMaxHealth;
        weaponSelected = 1; //Assign pistol as starting weapon
        rb = gameObject.GetComponent<Rigidbody2D>(); //Reference rigidbody component
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update() //Called every frame
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            sprite.color = new Color(32 / 255f, 255 / 255f, 253 /255f);
            //set colour of sprite to cyan
        }
        Movement();
        FaceCursor();
        Shoot();
    }

    void Movement() //Responsible for movement of this object
    {
        float x = Input.GetAxis("Horizontal"); //Gets input from horizontal axis
        float y = Input.GetAxis("Vertical"); //Gets input from vertical axis

        Vector2 inputVector = new Vector2(x, y); //Constructs new vector2 with given input
        inputVector.Normalize(); //Set magnitude to 1
        rb.velocity = inputVector * movementSpeed; //Objects velocity updated accordingly to specified direction

        //Debug.Log(inputVector); //Prints the values inside this vector2 in console
    }

    void FaceCursor() //Responsible for object facing users cursor
    {
        Vector3 mousePosition = Input.mousePosition; //Fetch coordinates of mouse on screen
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //Convert coordinates from real-world to in-game world

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        //Calculate direction from current objects position to the mouse position
        transform.up = direction; //Set objects 'up' direction to face the calculated direction
    }

    void Shoot() //Responsible for firing a bullet
    {
        shootTimer -= Time.deltaTime; //Reduce the shooting cooldown every second
        if (Input.GetMouseButton(0) && shootTimer <= 0 && bulletCapacity > 0) //If left mouse button is held down and theres no shoot cooldown
        {
            bulletCapacity -= 1;
            float randomRotation = Random.Range(-8f, 9f);
            if (weaponSelected == 1) //1 is pistol
            {
                Instantiate(bulletObject, weaponSprite.transform.position, transform.rotation * Quaternion.Euler(0, 0, randomRotation));
                //Create instance of bullet at weapon sprites position with an manipulated rotation from the players rotation
                shootTimer = 0.4f; //Sets a cooldown to how fast the weapon can be fired
            }

            else if (weaponSelected == 2) //2 is assualt rifle
            {
                Instantiate(bulletObject, weaponSprite.transform.position, transform.rotation * Quaternion.Euler(0, 0, randomRotation));
                shootTimer = 0.16f;
            }

            else if (weaponSelected == 3) //3 is shotgun
            {
                bulletCapacity -= 1;
                Instantiate(bulletObject, weaponSprite.transform.position + new Vector3(-0.2f, 0f, 0), transform.rotation * Quaternion.Euler(0, 0, 8f));
                Instantiate(bulletObject, weaponSprite.transform.position + new Vector3(0, 0, 0), transform.rotation);
                Instantiate(bulletObject, weaponSprite.transform.position + new Vector3(0.2f, 0f, 0), transform.rotation * Quaternion.Euler(0, 0, -8f));
                shootTimer = 0.5f;
            }

            else if (weaponSelected == 4) //4 is rocket launcher
            {
                Instantiate(bulletObject, weaponSprite.transform.position, transform.rotation * Quaternion.Euler(0, 0, randomRotation));
                shootTimer = 1f;
            }

            //Debug.Log("left mouse button inputted\nFiring bullet!");
        }
    }

    public void OnCollisionStay2D(Collision2D body)//Called when a collisions being made
    {
        Enemy isEnemy = body.gameObject.GetComponent<Enemy>();
        ExploderEnemy isExploderEnemy = body.gameObject.GetComponent<ExploderEnemy>();
        if (isEnemy != null || isExploderEnemy != null)
        //If enemy class found or exploder enemy class found
        {
            DamagePlayer();
        }
    }

    public void DamagePlayer()
    {
        if (attackTimer <= 0)
        {
            playerHealth -= 1;
            attackTimer = 1.2f;
            sprite.color = new Color(255 / 255f, 1 / 255f, 1 / 255f);
            //set colour of sprite to light red
            Debug.Log("Player damaged!\nHealth:" + playerHealth.ToString());
        }
    }
}