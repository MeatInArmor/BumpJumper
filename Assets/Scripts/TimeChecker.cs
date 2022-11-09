using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeChecker : MonoBehaviour
{
    public Text timeLeftText;
    float timeLeft;
    GameObject tmp1;
    GameObject tmp2;
   

    private void Start()
    {
        timeLeft = 30 + 3;
        tmp1 = GameObject.Find("BumpSpawner");
        tmp2 = GameObject.Find("Player");
    }
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft >= 3)
        {
            timeLeftText.text = Mathf.Round(timeLeft - 3f).ToString();
        }
        else
        {
            tmp1.GetComponent<BumpSpawner>().enabled = false;
            tmp2.GetComponent<PlayerController>().enabled = false;
        }
        if(timeLeft <= 0)
        {
            if(ScoreChecker.HighestScore <= PlayerChecker.score) 
            {
                ScoreChecker.HighestScore = PlayerChecker.score;
            }
            SceneManager.LoadScene("Scenes/Menu");
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           SceneManager.LoadScene("Scenes/Menu");
        }
    }
}
