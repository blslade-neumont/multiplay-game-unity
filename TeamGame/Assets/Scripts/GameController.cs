using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

public static class GameController
{
    private static bool isStarted = false;
    public static void StartGame()
    {
        if (isStarted) throw new InvalidOperationException("This game has already been started!");
        isStarted = true;
        loadMinigame();
    }
    public static void EndMinigame(int p1score, int p2score)
    {
        GameController.p1score = p1score;
        GameController.p2score = p2score;
        loadMinigame();
    }

    public static int p1score = 0, p2score = 0;
    private static int minigamesLeft = 5;
    
    private static void loadMinigame()
    {
        if (minigamesLeft-- == 0)
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
    private static void endGame()
    {
        SceneManager.LoadScene("GameEnd");
    }
}
