using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed; //Value set in inspector
    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); //Reference objects rigidbody
    }

    void Update()
    {
        rb.velocity = transform.up * bulletSpeed; //Move object forward
    }

    public void OnCollisionStay2D(Collision2D body)//Called when a collisions been made
    {
        
    }
}
