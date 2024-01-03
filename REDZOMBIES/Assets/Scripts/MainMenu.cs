using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
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