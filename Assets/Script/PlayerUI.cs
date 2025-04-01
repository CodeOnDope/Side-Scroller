using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text healthText; // Reference to the health UI text
    public TMP_Text scoreText; // Reference to the score UI text
    public GameObject gameCompletedScreen; // Reference to the game completed screen
    public GameObject menuScreen; // Reference to the menu screen

    private int playerScore = 0;

    public void UpdateHealth(float health)
    {
        if (healthText != null)
        {
            healthText.text = $"Health: {health}";
        }
    }

    public void UpdateScore(int score)
    {
        playerScore += score;
        if (scoreText != null)
        {
            scoreText.text = $"Score: {playerScore}";
        }
    }

    public void ShowGameCompletedScreen()
    {
        if (gameCompletedScreen != null)
        {
            gameCompletedScreen.SetActive(true);
        }
    }

    public void ShowMenuScreen()
    {
        if (menuScreen != null)
        {
            menuScreen.SetActive(true);
        }
    }

    public void HideMenuScreen()
    {
        if (menuScreen != null)
        {
            menuScreen.SetActive(false);
        }
    }
}