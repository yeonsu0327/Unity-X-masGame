using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int lives = 5;                    // 초기 생명 수
    public GameObject lifeImagePrefab;       // 하트 아이콘 프리팹
    public Transform lifePanel;              // 하트 아이콘을 담을 패널 (LifePanel)

    private List<GameObject> lifeImages = new List<GameObject>();

    void Start()
    {
        InitializeLifeImages(); // 게임 시작 시 하트 아이콘 생성
    }

    void InitializeLifeImages()
    {
        for (int i = 0; i < lives; i++)
        {
            GameObject lifeImage = Instantiate(lifeImagePrefab, lifePanel);
            lifeImages.Add(lifeImage);
        }
    }


    public void TakeDamage(int amount = 1)
    {
        if (lives > 0)
        {
            lives -= amount;           // 인자로 받은 만큼 생명 감소
            lives = Mathf.Max(lives, 0); // 생명이 0 이하로 내려가지 않도록 제한
            UpdateLifeImages(); // 하트 아이콘 업데이트
            Debug.Log("플레이어 생명 감소: 남은 생명 = " + lives); // 생명 차감 로그
        }

        if (lives <= 0)
        {
            GameOver();
        }
    }



    void UpdateLifeImages()
    {
        for (int i = 0; i < lifeImages.Count; i++)
        {
            lifeImages[i].SetActive(i < lives); // 남은 생명 수에 따라 하트 아이콘을 비활성화
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over: 생명이 모두 소진되었습니다."); // 게임 오버 로그
        Time.timeScale = 0;     // 게임 멈춤
    }
}
