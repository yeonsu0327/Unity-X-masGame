using UnityEngine;

public class TreeStar : MonoBehaviour
{
    public int scoreValue = 1; // 별 아이템당 점수 값

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddStarScore(scoreValue); // 별 점수 추가
            Destroy(gameObject); // 아이템 삭제
            
        }
    }
}
