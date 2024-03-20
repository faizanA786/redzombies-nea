using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameProcessing : MonoBehaviour
{
    public GameObject[] spawnLocations; //Holds all possible spawn locations for enemy
    public Player player; //Get reference to player class inside game scene
    public GameObject enemyObject; //Get enemy object prefab
    public GameObject fastEnemyObject;
    public GameObject exploderEnemyObject;
    public GameObject waveDisplay; //Reference WaveText object
    Text waveText;
    public GameObject scoreDisplay; //Reference ScoreText object
    Text scoreText;
    public GameObject healthDisplay; //Reference HealthText object
    Text healthText;
    Enemy enemyClass;
    ExploderEnemy exploderEnemyClass;

    public int waveNumber = 0; //Current wave number
    int enemiesToSpawn; //Num of enemies to spawn next round
    public int enemiesToKill; // Num of enemies to be eliminated to start next round
    void Start()
    {
        waveNumber = 0; //Initialise wave to 0
        enemiesToSpawn = 4; //Spawn atleast 4 enemies
        enemyClass = enemyObject.GetComponent<Enemy>();
        exploderEnemyClass = exploderEnemyObject.GetComponent<ExploderEnemy>();
        NextWave(); //Start first wave

        scoreText = scoreDisplay.GetComponent<Text>(); //Grab text component
        waveText = waveDisplay.GetComponent<Text>();
        healthText = healthDisplay.GetComponent<Text>();
    }
    
    void Update()
    {
        healthText.text = "Health: " + player.playerHealth.ToString(); //Output players health
        waveText.text = "Wave: " + waveNumber.ToString();//Output wave number
        scoreText.text = "Points: " + player.playerPoints.ToString();//Output players in-game points
        if (player.playerHealth <= 0)
        {
            Debug.Log("Game ended!");
            SceneManager.LoadScene("GameOver"); //Load game over scene, ending the game
        }
        else if (enemiesToKill <= 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        waveNumber += 1; //Increment wave number
        player.playerHealth = player.playerMaxHealth;
        if (waveNumber > 1)
        {
            int randomChance = Random.Range(1, 5); //Generate number between 1 and 4
            //50% to increase a random stat
            if (randomChance == 3) //25% to increase health 
            {
                enemyClass.maxEnemyHealth += Random.Range(0.1f, 0.6f);
                exploderEnemyClass.maxEnemyHealth += Random.Range(0.1f, 0.6f);
            }
            else if (randomChance == 4) //25% to increase speed
            {
                enemyClass.movementSpeed += Random.Range(0.08f, 0.3f);
                exploderEnemyClass.maxEnemyHealth += Random.Range(0.1f, 0.6f);
            }
        }

        enemiesToSpawn += Random.Range(4, 9); //Spawn more enemies next round by a seemingly random amount
        enemiesToKill = enemiesToSpawn; 
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomSpawn = Random.Range(0, 7); //Choose a random enemy spawn location
            int randomChance = Random.Range(1, 5); //Choose a number from 1 to 4
            if (randomChance == 4) // 25% chance to spawn a fast enemy
            {
                randomChance = Random.Range(1, 11);
                if (randomChance == 10) // 10% chance to spawn a fast enemy
                {
                    Instantiate(exploderEnemyObject, spawnLocations[randomSpawn].transform.position, transform.rotation); //Spawn exploder enemy
                }
                else
                {
                    Instantiate(fastEnemyObject, spawnLocations[randomSpawn].transform.position, transform.rotation); //Spawn fast enemy
                }
            }

            else
            {
                Instantiate(enemyObject, spawnLocations[randomSpawn].transform.position, transform.rotation); //Spawn enemy
            }
        }
        Debug.Log("Next round started!\n" + enemiesToSpawn.ToString() + " enemies have spawned this round");
    }
}
