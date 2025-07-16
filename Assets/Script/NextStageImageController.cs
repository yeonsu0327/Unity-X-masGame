using System.Collections;
using UnityEngine;

public class NextStageImageController : MonoBehaviour
{
    public GameObject nextStageImage; // NextStage �̹��� ������Ʈ

    private void Start()
    {
        // Stage2�� ���۵� �� �ڷ�ƾ ����
        if (nextStageImage != null)
        {
            StartCoroutine(ShowAndHideNextStageImage());
        }
    }

    private IEnumerator ShowAndHideNextStageImage()
    {
        nextStageImage.SetActive(true); // �̹��� Ȱ��ȭ
        yield return new WaitForSeconds(1f); // 1�� ���� ǥ��
        nextStageImage.SetActive(false); // �̹��� ��Ȱ��ȭ
    }
}
