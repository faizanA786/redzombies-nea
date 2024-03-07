using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AssaultRifle : MonoBehaviour
{
    public int cost = 500;
    public GameObject costLabel; //Reference CostLabel object
    TextMeshPro costText;

    void Start()
    {
        costText = costLabel.GetComponent<TextMeshPro>(); //Fetch text component
        costText.text = "[AssaultRifle]\nCost\n" + cost.ToString(); //Initialise text to current cost (500)
    }

    void Update()
    {
        costText.text = "[AssualtRifle]\n[Cost]\n" + cost.ToString(); //Set text to display new cost of buying weapons (for others)
    }

    public void OnTriggerStay2D(Collider2D body) //Called everytime an objects inside area
    {
        Player isPlayer = body.gameObject.GetComponent<Player>(); //Fetch player class
        if (isPlayer != null) //If player class found in body
        {
            if (isPlayer.weaponSelected != 2 && Input.GetKey(KeyCode.E) && isPlayer.playerPoints >= cost)
            //If player doesnt already have an assualt rifle and 'E' key pressed and player has enough points to buy weapon
            {
                isPlayer.playerPoints -= cost; //Subtract playerPoints attribute of player object by the cost
                isPlayer.weaponSelected = 2;
                Debug.Log("User bought rifle");
            }
        }
    }
}