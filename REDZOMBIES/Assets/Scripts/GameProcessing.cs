using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProcessing : MonoBehaviour
{
    public GameObject[] spawnLocations; //Holds all possible spawn locations for enemy
    public Player player; //Get reference to player inside game scene
    void Start()
    {
        
    }

    void Update()
    {
        if (player.playerHealth <= 0)
        {
            Debug.Log("Game ended!");
            SceneManager.LoadScene("GameOver"); //Load game over scene, ending the game
        }
    }
}
