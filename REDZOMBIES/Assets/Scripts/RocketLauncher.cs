using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RocketLauncher : MonoBehaviour
{
    public int cost = 350;
    public GameObject costLabel; //Reference CostLabel object
    TextMeshPro costText;

    void Start()
    {
        costText = costLabel.GetComponent<TextMeshPro>(); //Fetch text component
        costText.text = "[RocketLauncher]\nCost\n" + cost.ToString(); //Initialise text to current cost (350)
    }

    void Update()
    {
        costText.text = "[RocketLauncher]\n[Cost]\n" + cost.ToString(); //Set text to display new cost of buying weapons 
    }

    public void OnTriggerStay2D(Collider2D body) //Called everytime an objects inside area
    {
        Player isPlayer = body.gameObject.GetComponent<Player>(); //Fetch player class
        if (isPlayer != null) //If player class found in body
        {
            if (Input.GetKeyDown(KeyCode.E) && isPlayer.playerPoints >= cost)
            //If player doesnt already have a shotgun and 'E' key pressed and player has enough points to buy weapon
            {
                isPlayer.bulletCapacity = 80;
                isPlayer.playerPoints -= cost; //Subtract playerPoints attribute of player object by the cost
                isPlayer.weaponSelected = 4;
                Debug.Log("User bought rocket launcher");
            }
        }
    }
}