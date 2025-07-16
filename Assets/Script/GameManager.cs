using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI StarScoreText; // ������ ����
    public GameObject stageStartImage;

    private int StarScore = 0; // ������ ����

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
        Debug.Log("���: " + score);
    }

    public void AddStarScore(int amount)
    {
        StarScore += amount; // ������ ����
        UpdateStarScoreText();
        Debug.Log("�� ��� ȹ��! ���� �� ����: " + StarScore); // ������ ����
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
        // UI ��ҵ��� ã�� �Ҵ�
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        StarScoreText = GameObject.Find("StarScoreText")?.GetComponent<TextMeshProUGUI>();
        stageStartImage = GameObject.Find("StageStartImage");

        // UI ������Ʈ
        UpdateScoreText();
        if (StarScoreText != null) UpdateStarScoreText();
    }
}
