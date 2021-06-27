using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{

    public float score;
    public float Highscore;

    private void Start()
    {
        score = PlayerPrefs.GetFloat("Score", 0);
        Highscore = PlayerPrefs.GetFloat("Highscore", 0);
    }

    void Update()
    {
        if(score > Highscore)
        {
            Highscore = score;
        }
    }
}
