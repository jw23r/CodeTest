using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text textScore;
    public Text textLives;
    public static int score = 0;
    public static int lives = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = $"SCORE:{(int)score}";
        textLives.text = $"Lives:{(int)lives}";

    }
}
