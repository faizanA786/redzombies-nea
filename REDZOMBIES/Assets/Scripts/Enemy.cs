using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    Vector2 distanceFromPlayer;
    public GameObject player;
    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        distanceFromPlayer = player.transform.position - transform.position;
        //Calculate distance between this object and the player object
        distanceFromPlayer.Normalize();
        //Set magnitude to 1
        rb.velocity = distanceFromPlayer * movementSpeed;
        //Set velocity to this direction multiplied by the movementSpeed
    }
}
