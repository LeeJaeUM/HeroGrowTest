using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameDataUI : MonoBehaviour
{
    TextMeshProUGUI playTimeTMP;
    TextMeshProUGUI getCoinTMP;
    TextMeshProUGUI killTMP;
    TextMeshProUGUI expTMP;

    Slider expSlider;

    GameManager gameManager;
    UIManager uiManager;

    private void Awake()
    {
        playTimeTMP = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        getCoinTMP = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        killTMP = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        expTMP = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        expSlider = transform.GetChild(4).GetComponent<Slider>();

        gameManager = GameManager.Instance;
        uiManager = GameManager.Instance.UiManager;
    }
    private void Start()
    {
        uiManager.OnAddCoin += CoinCountUpdate;
        uiManager.OnAddKillCount += KillCountUpdate;
        uiManager.OnAddExp += ExpSliderUpdate;
    }

    private void Update()
    {
        playTimeTMP.text = gameManager.StateManager.playTime.ToString();
    }

    private void CoinCountUpdate(int count)
    {
        getCoinTMP.text = count.ToString();
    }

    private void KillCountUpdate(int count)
    {
        killTMP.text = count.ToString();
    }

    private void ExpSliderUpdate(float percent)
    {
        expSlider.value = percent;
    }
}
