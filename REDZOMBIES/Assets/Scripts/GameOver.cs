using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject waveObject;
    public GameObject pointsObject;
    void Start()
    {
        Text waveText = waveObject.GetComponent<Text>();
        Text pointsText = pointsObject.GetComponent<Text>();
        int waveReached = GameProcessing.LoadSaveData("WaveReached");
        int totalPoints = GameProcessing.LoadSaveData("TotalPoints");

        waveText.text = "Highest Wave: " + waveReached.ToString();
        pointsText.text = "Total Points : " + totalPoints.ToString();

    }
    public void OnReplayButton() //Executes if replay button pressed
    {
        Debug.Log("Replay button pressed\nReloaded game scene");
        SceneManager.LoadScene("Game"); //Reload the game
    }

    public void OnExitButton() //Executes if exit button pressed
    {
        Debug.Log("Exit button pressed\nMain menu loaded");
        SceneManager.LoadScene("MainMenu"); //Exit to main menu
    }
}