using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public static int cost = 100; //Cost is same for all instances
    public GameObject costLabel; //Reference CostLabel object
    public GameObject clearedObstacleVariant;
    TextMeshPro costText;

    void Start()
    {
        costText = costLabel.GetComponent<TextMeshPro>(); //Fetch text component
        costText.text = "[Cost]\n" + cost.ToString(); //Initialise text to current cost (500)
    }

    void Update()
    {
        costText.text = "[Cost]\n" + cost.ToString(); //Set text to display new cost of clearing obstacle (for others)
    }

    public void OnTriggerStay2D(Collider2D body) //Called everytime an objects inside area
    {
        Player isPlayer = body.gameObject.GetComponent<Player>(); //Fetch player class
        if (isPlayer != null) //If player class found in body
        {
            //Debug.Log("PLayer Inside");
            if (Input.GetKey(KeyCode.E) && isPlayer.playerPoints >= cost) 
            //If 'E' key pressed and player has enough points to clear obstacle
            {
                Debug.Log("Obstacle cleared");
                isPlayer.playerPoints -= cost; //Subtract playerPoints attribute of player object by the cost
                cost += 100; //Increase cost of clearing obstacles
                Instantiate(clearedObstacleVariant, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
                Destroy(transform.parent.gameObject); //Remove obstacle object from game i.e clearing
            }
        }
    }
}
