using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

    public Text mathAnswer;
    public Text mathText;
    public Text scoreText;

    public GameObject timeProgress;
    private float limitTime;
    private float currentTime;

    private int leftNum;
    private int rightNum;
    private int mathOperator;
    private int trueResult;
    private int falseResult;
    private int currentScore;

    public void Start()
    {
        limitTime = 5.0f;
        currentTime = 0.0f;

        currentScore = 0;
        createMath();
    }

    public void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > limitTime)
        {
            LoseGame();
        }
        else
        {
            float scaleProgressTime = 1.0f - currentTime / limitTime;
            timeProgress.transform.localScale = new Vector3(scaleProgressTime, 1, 1);
        }
    }
    public void createMath()
    {
        leftNum = Random.Range(0, 10);
        rightNum = Random.Range(0, 10);

        mathOperator = Random.Range(0, 3);

        switch (mathOperator)
        {
            case 0:
                trueResult = leftNum + rightNum;
                falseResult = trueResult + Random.Range(-2, 2);
                mathText.GetComponent<Text>().text =
                    leftNum.ToString() +
                    " + "
                    + rightNum.ToString();
                mathAnswer.GetComponent<Text>().text = " = " + falseResult.ToString();
                break;
            case 1:
                trueResult = leftNum - rightNum;
                falseResult = trueResult + Random.Range(-2, 2);
                mathText.GetComponent<Text>().text =
                    leftNum.ToString() +
                    " - "
                    + rightNum.ToString();
                mathAnswer.GetComponent<Text>().text = " = " + falseResult.ToString();
                break;
            case 2:
                trueResult = leftNum * rightNum;
                falseResult = trueResult + Random.Range(-2, 3);
                mathText.GetComponent<Text>().text =
                    leftNum.ToString() +
                    " * "
                    + rightNum.ToString();
                mathAnswer.GetComponent<Text>().text = " = " + falseResult.ToString();

                break;
            default:
                break;
        }

        scoreText.GetComponent<Text>().text = currentScore.ToString();
    }

    public void LoseGame()
    {
        GameValues.currentScore = currentScore;
        int highScore = PlayerPrefs.GetInt("HIGH_SCORE", 0);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HIGH_SCORE", currentScore);
        }

        SceneManager.LoadScene("LoseGame");

    }

    public void onTrueButtonClick()
    {
        if (trueResult == falseResult)
        {
            currentScore += 1;
            currentTime = 0.0f;
            createMath();
        }
        else
        {
            LoseGame();
        }
    }

    public void onFalseButtonClick()
    {
        if (trueResult != falseResult)
        {
            currentScore += 1;
            currentTime = 0.0f;
            createMath();
        }
        else 
        {
            LoseGame();
        }
    }

}
