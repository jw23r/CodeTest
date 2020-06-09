using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text textScore;/// gets text ui score

    public Text textLives; /// gets text ui lives

    public Text win;   /// gets text win

    public Button lose;    /// gets button ui lose


    public static int score = 0;/// keeps track of score and is edtiable from other clases

    public static int lives = 5;  /// keeps track of Lives and is edtiable from other clases

    public static int numberOfEnemys; /// keeps track of how many enemys are spawned and is edtiable from other clases

    // Update is called once per frame
    /// <summary>
    /// updates wether you win or lose
    /// updates the lives and score
    /// </summary>
    void Update()
    {
        WinCondotions();
        LivesAndScore();

    }
    /// <summary>
    /// updates the lives and score
    /// </summary>
    private void LivesAndScore()
    {
        textScore.text = $"SCORE:{(int)score}";


        textLives.text = $"LIVES:{(int)lives}";
    }
    /// <summary>
    ///  updates wether you win or lose
    /// </summary>
    private void WinCondotions()
    {
        if (numberOfEnemys <= 0 && lives >= 0)
        {
            win.gameObject.SetActive(true);

        }
        else
        {
            win.gameObject.SetActive(false);
        }
        if (lives < 0)
        {
           
            lose.gameObject.SetActive(true);

        }
        else
        {
            lose.gameObject.SetActive(false);
        }
    }
}
