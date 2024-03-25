using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    public int cost = 300;
    public GameObject costLabel; //Reference CostLabel object
    TextMeshPro costText;

    void Start()
    {
        costText = costLabel.GetComponent<TextMeshPro>(); //Fetch text component
        costText.text = "[Shotgun]\nCost\n" + cost.ToString(); //Initialise text to current cost (500)
    }

    void Update()
    {
        costText.text = "[Shotgun]\n[Cost]\n" + cost.ToString(); //Set text to display new cost of buying weapons (for others)
    }

    public void OnTriggerStay2D(Collider2D body) //Called everytime an objects inside area
    {
        Player isPlayer = body.gameObject.GetComponent<Player>(); //Fetch player class
        if (isPlayer != null) //If player class found in body
        {
            if (Input.GetKeyDown(KeyCode.E) && isPlayer.playerPoints >= cost)
            //If player doesnt already have a shotgun and 'E' key pressed and player has enough points to buy weapon
            {
                isPlayer.bulletCapacity = 300;
                isPlayer.playerPoints -= cost; //Subtract playerPoints attribute of player object by the cost
                isPlayer.weaponSelected = 3;
                Debug.Log("User bought shotgun");
            }
        }
    }
}