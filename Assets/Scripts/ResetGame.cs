using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    /// <summary>
    /// restes the game
    /// </summary>
    public void ButtonPlay()
    {
        HUDController.score = 0;
        HUDController.lives = 5;
        SceneManager.LoadScene("Game");

    }
}
