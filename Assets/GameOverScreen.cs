using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text FinalScore;
    public Text WinnerText;

    public void Setup(string P1Score, string P2Score)
    {
        FinalScore.text = P1Score + " - " + P2Score;

        int p1ScoreInt = int.Parse(P1Score);
        int p2ScoreInt = int.Parse(P2Score);

        if (p1ScoreInt > p2ScoreInt)
        {
            WinnerText.text = "Player 1 Wins!";
        }
        else if (p2ScoreInt > p1ScoreInt)
        {
            WinnerText.text = "Player 2 Wins!";
        }

        gameObject.SetActive(true); // Show the game over screen
    }
}
