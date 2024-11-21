using UnityEngine;

public class ItemModelMove : MonoBehaviour
{
    public float moveSpeed = 3f; // 위아래 이동 속도
    public float moveDistance = 0.2f; // 위아래로 이동할 거리
    public float rotationSpeed = 45f; // 회전 속도

    private Vector3 startPosition;

    void Start()
    {
        // 시작 위치를 저장
        startPosition = transform.position;
    }

    void Update()
    {
        // 위아래로 반복적으로 이동
        float newY = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);

        // 지속적으로 회전
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // Y축을 중심으로 회전
    }
}
