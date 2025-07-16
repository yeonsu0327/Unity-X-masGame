using UnityEngine;
using System.Collections;

public class DisappearBlock : MonoBehaviour
{
    public float disappearDelay = 1f; // 사라지는 대기 시간

    private bool isSteppedOn = false;

    void OnCollisionEnter(Collision collision)
    {
        // 플레이어가 위에서 밟았는지 확인 (y축 위치로 확인 가능)
        if (collision.gameObject.CompareTag("Player") && !isSteppedOn)
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            if (collisionPoint.y > transform.position.y)
            {
                isSteppedOn = true;
                StartCoroutine(DisappearAfterDelay());
            }
        }
    }

    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(disappearDelay); // 대기 시간 후
        gameObject.SetActive(false); // 블럭 비활성화
    }
}
