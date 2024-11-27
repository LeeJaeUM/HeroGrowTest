using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameDataUI : MonoBehaviour
{
    TextMeshProUGUI playTimeTMP;
    TextMeshProUGUI getCoinTMP;
    TextMeshProUGUI killTMP;
    TextMeshProUGUI expTMP;
    TextMeshProUGUI playerHpTMP;

    Slider expSlider;
    Slider playerHpSlider;

    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    SystemManager systemManager;
    [SerializeField]
    CharacterHP characterHP;

    private void Awake()
    {
        playTimeTMP = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        getCoinTMP = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        killTMP = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        expTMP = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        expSlider = transform.GetChild(4).GetComponent<Slider>();
        playerHpTMP = transform.GetChild(5).GetComponent<TextMeshProUGUI>();
        playerHpSlider = transform.GetChild(6).GetComponent<Slider>();

        gameManager = GameManager.Instance;
        systemManager = GameManager.Instance.SystemManager;
    }
    private void Start()
    {
        systemManager.OnAddCoin += CoinCountUpdate;
        systemManager.OnAddKillCount += KillCountUpdate;
        systemManager.OnAddExp += ExpSliderUpdate;

        characterHP = gameManager.PlayerManager.GetComponent<CharacterHP>();
        characterHP.OnHpChange += PlayerHpUpdate;
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

    private void PlayerHpUpdate(float maxHp, float curHp)
    {
        playerHpTMP.text = curHp.ToString() + "/" + maxHp.ToString();
        playerHpSlider.value = curHp / maxHp;
    }
}
