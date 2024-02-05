using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float respawnDelay= 2f;
    private bool isGameEnding=false;
    private int score;
    public Text scoreText;
    public Text winText;
    public GameObject WinnerUI;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
   
    public void RespawnPlayer()
    {
        if (isGameEnding==false)
        {
            isGameEnding = true;
            StartCoroutine(RespawnCoroutine());
            
        }
       
    }
    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // sahneyi tekrardan yükle
       
        //playerController.transform.position = playerController.respawnPoint;
        //playerController.gameObject.SetActive(true);
        isGameEnding = false;

    }
    public void AddScore(int numberOfScore)
    {
        score += numberOfScore;
        scoreText.text ="Score : "+ score.ToString();
    }
    public void LevelUp()
    {
        WinnerUI.SetActive(true);
        winText.text = "Seviye Tamamlandý    Toplam Puan " + score;
        Invoke("NextLevel", respawnDelay);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
