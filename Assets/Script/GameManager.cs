using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerUI playerUI; // Reference to the PlayerUI script

    public void CompleteGame()
    {
        if (playerUI != null)
        {
            playerUI.ShowGameCompletedScreen();
        }
        Debug.Log("Game Completed!");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void ShowMenu()
    {
        if (playerUI != null)
        {
            playerUI.ShowMenuScreen();
        }
    }

    public void HideMenu()
    {
        if (playerUI != null)
        {
            playerUI.HideMenuScreen();
        }
    }
}