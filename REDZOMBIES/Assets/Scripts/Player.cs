using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       float x = Input.GetAxis("Horizontal");
       float y = Input.GetAxis("Vertical");

       Vector2 inputVector = new Vector2(x, y);
       rb.velocity = inputVector * movementSpeed;
    }
}
