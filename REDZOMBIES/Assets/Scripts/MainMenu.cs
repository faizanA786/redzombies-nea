using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Play button pressed\nLoaded game scene");
    }

    public void OnExitButton()
    {
        Debug.Log("Program closed");
        Application.Quit();
    }
}