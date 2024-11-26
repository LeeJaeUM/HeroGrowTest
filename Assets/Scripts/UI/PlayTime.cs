using TMPro;
using UnityEngine;

public class PlayTime : MonoBehaviour
{
    TextMeshProUGUI m_TextMeshProUGUI;

    private void Awake()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        m_TextMeshProUGUI.text = GameManager.Instance.playTime.ToString();
    }
}
