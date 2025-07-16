using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    public void Load()
    {
        Debug.Log("Load �޼��尡 ȣ��Ǿ����ϴ�."); // �޼��� ȣ�� ���� Ȯ�ο� �����

        // �� �̸��� ���� �ٸ� ����� �޽��� ���
        if (sceneName == "Stage1")
        {
            Debug.Log("������ ���۵˴ϴ�.: " + sceneName);
        }
        else if (sceneName == "GameStart")
        {
            Debug.Log("Ȩ ȭ������ �̵��մϴ�.: " + sceneName);
        }
        else
        {
            Debug.Log(sceneName + " ������ �̵��մϴ�.");
        }

        SceneManager.LoadScene(sceneName);
    }
}