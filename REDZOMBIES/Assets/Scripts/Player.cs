using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed; //value set in inspector window
    int playerMaxHealth = 3;
    public int playerHealth;
    public int playerPoints = 0;
    float shootTimer; //Values are set in Shoot()
    public bool playerDeath = false;
    public int weaponSelected;

    public GameObject bulletObject; //References bullet object
    public GameObject weaponSprite; //References weapon object
    Rigidbody2D rb;

    void Start() //Initialisation, called on first frame
    {
        playerHealth = playerMaxHealth;
        rb = gameObject.GetComponent<Rigidbody2D>(); //Reference rigidbody component
    }

    void Update() //Called every frame
    {
        Movement();
        Shoot();
        FaceCursor();
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

    }

    void Shoot() //Responsible for firing a bullet
    {
        shootTimer *= Time.deltaTime; //Reduces value every second
        if (Input.GetMouseButton(0) && shootTimer <= 0)
        {
            if (weaponSelected == 1) //1 is pistol
            {
                Instantiate(bulletObject, weaponSprite.transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
                shootTimer = 0.7f;
            }

            /*else if (weaponSelected == 2) //2 is assualt rifle
            {

            }*/

            Debug.Log("left mouse button inputted\nFiring bullet!");

        }
    }

    public void OnCollisionStay2D(Collision2D body)//Called when a collisions been made
    {
        
    }
}
