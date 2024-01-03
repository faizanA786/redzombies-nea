using UnityEngine;

public class Player : MonoBehaviour
{
    //Public variable values set in inspector window
    public float movementSpeed;
    public GameObject bulletObject;
    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); //Reference rigidbody component
    }

    void Update()
    {
       float x = Input.GetAxis("Horizontal");
       float y = Input.GetAxis("Vertical");

       Vector2 inputVector = new Vector2(x, y);
       rb.velocity = inputVector * movementSpeed;

       if (Input.GetMouseButton(0))
        {
           Instantiate(bulletObject, transform.position, transform.rotation);
           Debug.Log("left mouse button inputted\nFiring bullet!");
        }
    }
}
