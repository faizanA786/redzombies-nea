using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyDamageTrap : MonoBehaviour
{
    public int cost = 800;
    public GameObject costLabel; //Reference CostLabel object
    public GameObject damageTrap;
    TextMeshPro costText;

    void Start()
    {
        costText = costLabel.GetComponent<TextMeshPro>(); //Fetch text component
        costText.text = "[DamageTrap]\nCost\n" + cost.ToString(); //Initialise text to current cost (350)
    }

    void Update()
    {
        costText.text = "[DamageTrap]\n[Cost]\n" + cost.ToString(); //Set text to display new cost of buying trap 
    }

    public void OnTriggerStay2D(Collider2D body) //Called everytime an objects inside area
    {
        Player isPlayer = body.gameObject.GetComponent<Player>(); //Fetch player class
        if (isPlayer != null) //If player class found in body
        {
            if (Input.GetKeyDown(KeyCode.E) && isPlayer.playerPoints >= cost)
            //If 'E' key pressed and player has enough points to buy trap
            {
                isPlayer.playerPoints -= cost; //Subtract playerPoints attribute of player object by the cost
                Instantiate(damageTrap, transform.position, transform.rotation);
                Debug.Log("User bought damage trap");
                Destroy(transform.parent.gameObject);
            }
        }
    }
}