using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winUI;
    public GameObject loseUI;
    public int score;
    public Text loseScoreText,winScoreText;
    public Text InGameScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LevelEnd()
    {
        loseUI.SetActive(true);
        loseScoreText.text = "Score = " + score;
        InGameScoreText.gameObject.SetActive(false);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void WinLevel()
    {
        winUI.SetActive(true);
        winScoreText.text = "Score = " + score;
        InGameScoreText.gameObject.SetActive(false);
    }
    public void AddScore(int pointValue)
    {
        score += pointValue;
        InGameScoreText.text = "Score = " + score;
    }
    public void StartApp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitApp()
    {
        Application.Quit();
    }
 
  
}
