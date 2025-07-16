using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    public void Load()
    {
        Debug.Log("Load 메서드가 호출되었습니다."); // 메서드 호출 여부 확인용 디버그

        // 씬 이름에 따라 다른 디버그 메시지 출력
        if (sceneName == "Stage1")
        {
            Debug.Log("게임이 시작됩니다.: " + sceneName);
        }
        else if (sceneName == "GameStart")
        {
            Debug.Log("홈 화면으로 이동합니다.: " + sceneName);
        }
        else
        {
            Debug.Log(sceneName + " 씬으로 이동합니다.");
        }

        SceneManager.LoadScene(sceneName);
    }
}