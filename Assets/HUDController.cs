using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text textScore;
    public Text textLives;
    public Text win;
    public Button lose;


    public static int score = 0;
    public static int lives = 5;
    public static int numberOfEnemys;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WinCondotions();
        LivesAndScore();

    }

    private void LivesAndScore()
    {
        textScore.text = $"SCORE:{(int)score}";


        textLives.text = $"LIVES:{(int)lives}";
    }

    private void WinCondotions()
    {
        if (numberOfEnemys <= 0)
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
