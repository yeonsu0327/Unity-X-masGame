using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    public string sceneToLoad = "GameStart"; // �̵��� �� �̸��� ���� (GameStart)

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾ �ǴϽ� ����Ʈ�� ����� ���� �� ����
        if (other.CompareTag("Player"))
        {
            Debug.Log("������ �Ϸ��߽��ϴ�." + sceneToLoad );
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
