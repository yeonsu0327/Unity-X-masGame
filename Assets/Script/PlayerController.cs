using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;           // 이동 속도
    public float jumpForce = 7f;           // 점프 힘
    public LifeManager lifeManager;        // LifeManager 스크립트 참조
    public GameObject gameOverPanel;       // 게임 오버 패널

    private Rigidbody rb;                  // Rigidbody 컴포넌트
    private int jumpCount = 0;             // 이단 점프를 위한 점프 횟수
    private bool canTakeDamage = true;     // 생명 감소 가능 여부
    public float damageCooldown = 2f;      // 생명 감소 쿨타임
    private Coroutine damageCoroutine;     // 생명 감소용 코루틴 참조

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트 가져오기
        Time.timeScale = 1;             // 게임 시작 시 시간을 정상으로 설정
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // 게임 오버 패널 숨기기
    }

    void Update()
    {
        Move();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && jumpCount < 2)
        {
            Jump();
        }

        if (transform.position.y < -10f)
        {
            GameOver();
            Debug.Log("Game Over: 플레이어가 추락했습니다."); // 추락으로 인한 게임 오버 로그
        }
    }

    void Move()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveDirection, 0, 0);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpCount++;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            // ground에 닿았을 때만 jumpCount 초기화
            jumpCount = 0;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            // 장애물과 닿았을 때 생명 감소 및 jumpCount 초기화
            TakeDamage(2);
            Debug.Log("장애물 충돌: 플레이어가 장애물에 닿아 생명 2 감소"); // 장애물 충돌 로그
            jumpCount = 0; // 장애물 위에서도 점프 가능하도록 초기화
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Vector3 collisionPoint = other.contacts[0].point;

            if (collisionPoint.y < transform.position.y - 0.2f && rb.velocity.y < 0)
            {
                // 적을 밟았을 때만 적 제거
                Destroy(other.gameObject);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                Debug.Log("적 제거: 플레이어가 적을 밟았습니다."); // 적 밟기 로그
            }
            else if (canTakeDamage)
            {
                // 적과 충돌했을 때 생명 감소
                damageCoroutine = StartCoroutine(DamageOverTime());
            }
        }
    }


    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    IEnumerator DamageOverTime()
    {
        while (true)
        {
            TakeDamage(1);
            yield return new WaitForSeconds(damageCooldown);
        }
    }

    void TakeDamage(int amount)
    {
        if (lifeManager != null)
        {
            lifeManager.TakeDamage(amount); // LifeManager에서 생명 감소 처리
            Debug.Log("플레이어가 적과 충돌하여 생명 감소"); // 생명 차감 로그
            if (lifeManager.lives <= 0)
            {
                GameOver();
            }
        }
    }


    void GameOver()
    {
        Debug.Log("Game Over: 플레이어의 생명이 모두 소진되었습니다."); // 게임 오버 로그
        Time.timeScale = 0;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
