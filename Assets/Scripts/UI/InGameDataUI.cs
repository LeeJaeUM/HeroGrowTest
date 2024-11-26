using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InGameDataUI : MonoBehaviour
{
    TextMeshProUGUI playTimeTMP;
    TextMeshProUGUI getCoinTMP;
    TextMeshProUGUI killTMP;
    TextMeshProUGUI expTMP;

    Slider slider;

    GameManager gameManager;
    UIManager uiManager;

    private void Awake()
    {
        playTimeTMP = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        getCoinTMP = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        killTMP = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        expTMP = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        slider = transform.GetChild(4).GetComponent<Slider>();

        gameManager = GameManager.Instance;
        uiManager = UIManager.Instance;
    }
    private void Start()
    {
        uiManager.OnGetCoin += CoinCountUpdate;
        uiManager.OnAddKillCount += KillCountUpdate;
    }

    private void Update()
    {
        playTimeTMP.text = gameManager.playTime.ToString();
    }

    private void CoinCountUpdate(int count)
    {
        getCoinTMP.text = count.ToString();
    }

    private void KillCountUpdate(int count)
    {
        killTMP.text = count.ToString();
    }
}
