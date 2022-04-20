using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Stats playerStats;

    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform RightWall;
    [SerializeField] private Transform LeftWall;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private GameObject GameOverPanel;

    private int Score;

    private void Start()
    {
        LoadOnStart();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float xPos = transform.position.x + x * speed * Time.deltaTime;
        float playerSize = transform.localScale.x / 2;

        if (xPos-playerSize <= LeftWall.position.x + LeftWall.localScale.x/2)
        {
            return;
        }
        if (xPos + playerSize >= RightWall.position.x - RightWall.localScale.x / 2)
        {
            return;
        }
        transform.position = new Vector3(xPos + x*speed * Time.deltaTime, transform.position.y,transform.position.z);
    }

    private void LoadOnStart()
    {
        GameOverPanel.SetActive(false);

        playerStats = GetComponent<Stats>();
        playerStats.Health = 150;
        healthText.text = "Health: " + playerStats.Health.ToString();
        scoreText.text = "Score: " + Score.ToString();
    }

    public void HealthChange(int value)
    {
        playerStats.Health += value;

        if (playerStats.Health <= 0)
        {
            GameOver();
        }       

        healthText.text = "Health: " + playerStats.Health.ToString();
    }

    public void ScoreChange(int value)
    {
        Score += value;
        scoreText.text = "Score: " + Score.ToString();
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + Score.ToString();
    }
}
