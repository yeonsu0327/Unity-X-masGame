using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI StarScoreText; // 변수명 수정
    public GameObject stageStartImage;

    private int StarScore = 0; // 변수명 수정

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
        UpdateStarScoreText();

        if (stageStartImage != null && SceneManager.GetActiveScene().name == "Stage2")
        {
            StartCoroutine(DisplayStageStartImage());
        }
    }

    IEnumerator DisplayStageStartImage()
    {
        if (stageStartImage != null)
        {

            stageStartImage.SetActive(true);
            yield return new WaitForSeconds(1f);
            stageStartImage.SetActive(false);

        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
        Debug.Log("장식: " + score);
    }

    public void AddStarScore(int amount)
    {
        StarScore += amount; // 변수명 수정
        UpdateStarScoreText();
        Debug.Log("별 장식 획득! 현재 별 점수: " + StarScore); // 변수명 수정
    }


    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = ": " + score;
        }
    }

    void UpdateStarScoreText()
    {
        if (StarScoreText != null)
        {
            StarScoreText.text = ": " + StarScore;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // UI 요소들을 찾아 할당
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        StarScoreText = GameObject.Find("StarScoreText")?.GetComponent<TextMeshProUGUI>();
        stageStartImage = GameObject.Find("StageStartImage");

        // UI 업데이트
        UpdateScoreText();
        if (StarScoreText != null) UpdateStarScoreText();
    }
}
