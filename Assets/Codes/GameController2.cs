using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour
{
    public Text currentScoreText;
    public Text highScoreText;

    public void Start()
    {
        currentScoreText.GetComponent<Text>().text = "SCORE " +
            GameValues.currentScore.ToString();
        highScoreText.GetComponent<Text>().text = "HIGHSCORE " +
            PlayerPrefs.GetInt("HIGH_SCORE", 0).ToString();
 
    }
    public void onPlayAgainButtonClick()
    {
        SceneManager.LoadScene("Proj Sana");
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Main");
    }

}
