using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환을 위해 필요

public class NextStageTrigger : MonoBehaviour
{
    public string nextSceneName = "Stage2"; // 이동할 씬의 이름을 Inspector에서 설정할 수 있도록 합니다.

    void OnTriggerEnter(Collider other)
    {
        // 플레이어가 FinishPoint에 닿았을 때
        if (other.CompareTag("Player")) // 플레이어 오브젝트에 태그가 "Player"로 설정되어 있어야 합니다.
        {
            LoadNextStage();
        }
    }

    void LoadNextStage()
    {
        // 다음 스테이지로 이동
        SceneManager.LoadScene(nextSceneName);
    }
}
