using System.Collections;
using UnityEngine;

public class DangerLine : MonoBehaviour
{
    public Transform expandLine; 
    float elapsedTime = 0f;
    public float duration = 0.5f;

    public float testValue = 0f;

    private void OnEnable()
    {
        if (expandLine == null)
            expandLine = transform.GetChild(0).gameObject.transform;
        elapsedTime = 0f;
        StartCoroutine(Lerp(duration));
    }

    public IEnumerator Lerp(float _duration)
    {
        while (elapsedTime < _duration)
        {
            // 0에서 1까지의 비율 계산
            float value = Mathf.Lerp(0f, 1f, elapsedTime / _duration);
            elapsedTime += Time.deltaTime;
            // 현재 localScale을 가져와 x 축만 변경
            Vector3 newScale = expandLine.localScale;
            newScale.x = value;
            expandLine.localScale = newScale;

            testValue = value;

            yield return null; // 다음 프레임까지 대기
        }

        //범위표시 후 제거
        Destroy(gameObject);
    }
}
