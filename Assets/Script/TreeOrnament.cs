using UnityEngine;

public class TreeOrnament : MonoBehaviour
{
    public int scoreValue = 1; // 아이템당 점수 값

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(scoreValue); // GameManager를 통해 장식 점수 추가
            Destroy(gameObject); // 아이템 삭제
        }
    }
}
