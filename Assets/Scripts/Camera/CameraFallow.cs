using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public Transform target; // 따라갈 대상 (플레이어)
    public Vector3 offset = new Vector3(0,12,-15);   // 카메라와 대상 사이의 거리
    public float fallowSpeed = 5.0f;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player 태그를 가진 오브젝트를 찾을 수 없습니다!");
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * fallowSpeed);
        }
    }
}