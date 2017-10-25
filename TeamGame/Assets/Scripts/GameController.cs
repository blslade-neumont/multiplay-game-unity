using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

public class GameController
{
    public GameController()
    {
        
    }

    private bool isStarted = false;
    public void StartGame()
    {
        if (isStarted) throw new InvalidOperationException("This game has already been started!");
        isStarted = true;
        loadMinigame();
    }
    public void EndMinigame(int p1score, int p2score)
    {
        p1score += p1score;
        p2score += p2score;
        loadMinigame();
    }

    private int p1score = 0, p2score = 0;
    private int minigamesLeft = 10;
    
    private void loadMinigame()
    {
        if (this.minigamesLeft-- == 0)
        {
            endGame();
            return;
        }

        var rnd = new Random();
        switch (rnd.Next(3))
        {
        case 0:
            SceneManager.LoadScene("Skyscrapers");
            break;

        case 1:
            SceneManager.LoadScene("Lasers");
            break;

        case 2:
            SceneManager.LoadScene("FlappyBirds");
            break;

        default:
            throw new InvalidOperationException();
        }
    }
    private void endGame()
    {
        SceneManager.LoadScene("GameEnd");
    }
}
