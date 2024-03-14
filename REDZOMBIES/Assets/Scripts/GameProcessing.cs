using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameProcessing : MonoBehaviour
{
    public GameObject[] spawnLocations; //Holds all possible spawn locations for enemy
    public Player player; //Get reference to player inside game scene
    public GameObject waveDisplay; //Reference WaveText object
    Text waveText;
    public GameObject scoreDisplay; //Reference ScoreText object
    Text scoreText;

    float spawnTimer = 0.8f; //Delay enemy spawns
    public int waveNumber = 0; //Current wave number
    int enemiesSpawned; //Num of enemies existing
    float enemyHealthMultiplier; //Enemy health difficulty scaling
    float enemySpeedMultiplier; //Enemy movement speed difficulty scaling
    void Start()
    {
        waveNumber = 1; //Initialise wave to 1

        scoreText = scoreDisplay.GetComponent<Text>(); //Grab text component
        waveText = waveDisplay.GetComponent<Text>();
        waveText.text = "Wave:" + waveNumber.ToString();//Output wave number
    }

    void Update()
    {
        scoreText.text = "Points:" + player.playerPoints.ToString();//Output players in-game points
        if (player.playerHealth <= 0)
        {
            Debug.Log("Game ended!");
            SceneManager.LoadScene("GameOver"); //Load game over scene, ending the game
        }
    }

    void WaveSystem()
    {

    }
}
