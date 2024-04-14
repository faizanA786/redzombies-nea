using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject waveObject;
    public GameObject pointsObject;
    void Start()
    {
        Text waveText = waveObject.GetComponent<Text>();
        Text pointsText = pointsObject.GetComponent<Text>();
        int waveReached = GameProcessing.LoadSaveData("WaveReached");
        int totalPoints = GameProcessing.LoadSaveData("TotalPoints");

        waveText.text = "Previous Wave: " + waveReached.ToString();
        pointsText.text = "Previous Points : " + totalPoints.ToString();
    }
    public void OnPlayButton() //Executes if play button pressed
    {
        Debug.Log("Play button pressed\nLoaded game scene");
        SceneManager.LoadScene("Game"); //Load the game
    }

    public void OnExitButton() //Executes if exit button pressed
    {
        Debug.Log("Exit button pressed\nProgram closed");
        Application.Quit(); //Exit program
    }
}