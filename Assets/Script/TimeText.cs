using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    public float startTime = 60f;
    private float currentTime;

    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;

    void Start()
    {
        currentTime = startTime;
        UpdateTimerText();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                currentTime = 0;
            }
            UpdateTimerText();

            if (currentTime <= 0)
            {
                GameOver();
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Game Over: 시간이 모두 소진되었습니다."); // 타이머 종료로 인한 게임 오버 로그
    }
}
