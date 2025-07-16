using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                  // 카메라가 따라갈 대상 (Player)
    public Vector3 offset = new Vector3(0, 0, -10); // 카메라와의 거리 설정

    private float fixedYPosition;
    private float fixedZPosition;

    void Start()
    {
        // Y와 Z 위치 고정
        fixedYPosition = transform.position.y;
        fixedZPosition = transform.position.z;
    }

    void LateUpdate()
    {
        // 카메라의 목표 위치 설정 (X축은 플레이어를 따라가고, Y와 Z 축은 고정)
        Vector3 targetPosition = new Vector3(target.position.x + offset.x, fixedYPosition, fixedZPosition);

        // 카메라 위치를 목표 위치에 정확하게 설정
        transform.position = targetPosition;
    }
}
