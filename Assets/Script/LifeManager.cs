using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int lives = 5;                    // �ʱ� ���� ��
    public GameObject lifeImagePrefab;       // ��Ʈ ������ ������
    public Transform lifePanel;              // ��Ʈ �������� ���� �г� (LifePanel)

    private List<GameObject> lifeImages = new List<GameObject>();

    void Start()
    {
        InitializeLifeImages(); // ���� ���� �� ��Ʈ ������ ����
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
            lives -= amount;           // ���ڷ� ���� ��ŭ ���� ����
            lives = Mathf.Max(lives, 0); // ������ 0 ���Ϸ� �������� �ʵ��� ����
            UpdateLifeImages(); // ��Ʈ ������ ������Ʈ
            Debug.Log("�÷��̾� ���� ����: ���� ���� = " + lives); // ���� ���� �α�
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
            lifeImages[i].SetActive(i < lives); // ���� ���� ���� ���� ��Ʈ �������� ��Ȱ��ȭ
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over: ������ ��� �����Ǿ����ϴ�."); // ���� ���� �α�
        Time.timeScale = 0;     // ���� ����
    }
}
