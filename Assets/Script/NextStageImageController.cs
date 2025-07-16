using System.Collections;
using UnityEngine;

public class NextStageImageController : MonoBehaviour
{
    public GameObject nextStageImage; // NextStage 이미지 오브젝트

    private void Start()
    {
        // Stage2가 시작될 때 코루틴 실행
        if (nextStageImage != null)
        {
            StartCoroutine(ShowAndHideNextStageImage());
        }
    }

    private IEnumerator ShowAndHideNextStageImage()
    {
        nextStageImage.SetActive(true); // 이미지 활성화
        yield return new WaitForSeconds(1f); // 1초 동안 표시
        nextStageImage.SetActive(false); // 이미지 비활성화
    }
}
