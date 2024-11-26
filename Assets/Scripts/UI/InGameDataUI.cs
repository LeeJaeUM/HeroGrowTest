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
    ItemManager itemManager;

    private void Awake()
    {
        playTimeTMP = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        getCoinTMP = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        killTMP = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        expTMP = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        expSlider = transform.GetChild(4).GetComponent<Slider>();

        gameManager = GameManager.Instance;
        itemManager = GameManager.Instance.ItemManager;
    }
    private void Start()
    {
        itemManager.OnAddCoin += CoinCountUpdate;
        itemManager.OnAddKillCount += KillCountUpdate;
        itemManager.OnAddExp += ExpSliderUpdate;
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
