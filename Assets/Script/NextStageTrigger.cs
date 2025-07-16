using UnityEngine;
using UnityEngine.SceneManagement; // �� ��ȯ�� ���� �ʿ�

public class NextStageTrigger : MonoBehaviour
{
    public string nextSceneName = "Stage2"; // �̵��� ���� �̸��� Inspector���� ������ �� �ֵ��� �մϴ�.

    void OnTriggerEnter(Collider other)
    {
        // �÷��̾ FinishPoint�� ����� ��
        if (other.CompareTag("Player")) // �÷��̾� ������Ʈ�� �±װ� "Player"�� �����Ǿ� �־�� �մϴ�.
        {
            LoadNextStage();
        }
    }

    void LoadNextStage()
    {
        // ���� ���������� �̵�
        SceneManager.LoadScene(nextSceneName);
    }
}
