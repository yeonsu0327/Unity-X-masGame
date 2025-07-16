using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    public string sceneToLoad = "GameStart"; // 이동할 씬 이름을 설정 (GameStart)

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어가 피니시 포인트에 닿았을 때만 씬 변경
        if (other.CompareTag("Player"))
        {
            Debug.Log("게임을 완료했습니다." + sceneToLoad );
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
