using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public float gameTime;
    public int score;

    public GameObject MenuPanel;
    public GameObject ScorePanel;
    public GameObject GameOverPanel;

    public TextMeshProUGUI _winText;

    public bool _isStarted;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameTime = 200f;
        _isStarted = false;



    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime > 0 && _isStarted)
        {
            gameTime -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(gameTime);
        }

        if(gameTime <= 0)
        {
            ScorePanel.SetActive(false);
            GameOverPanel.SetActive(true);
            _winText.text = "You Lost The Game. Try Again";
        }

    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int points)
    {
        score += points;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        if(score == 5)
        {
            ScorePanel.SetActive(false);
            GameOverPanel.SetActive(true);
            _winText.text = "You Won The Game. Congratulations!";
        }
    }

    public void onButtonClick(GameObject UIObject)
    {
        if(UIObject.name == "StartButton")
        {
            MenuPanel.SetActive(false);
            ScorePanel.SetActive(true);
            _isStarted = true;
        }

        if(UIObject.name == "ExitButton")
        {
            Application.Quit();
        }

        if(UIObject.name == "RestartButton")
        {
            Application.LoadLevel(0);
        }
    }
}
