using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;

    private void Awake()

    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        scoreText.text = score.ToString() + " Points";
        highscoreText.text = "HighScore: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " Points";
        if (highscore < score)
            PlayerPrefs.SetInt("Highscore", score);
       
    }
    public void Win() 
    { 
       if  (score > highscore) 
        {
            WinGame();
        } 
  }
    private void WinGame() 
    {
        Debug.Log("You Win!");
        SceneManager.LoadScene("WinScene");
    }
}
