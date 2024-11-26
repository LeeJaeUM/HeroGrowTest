using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class LootBoxUI : MonoBehaviour
{
    [SerializeField]
    private List<int> availableValues;
    public int maxWeaponID = 11;
    public int[] availableWeaponIDs = new int[3];
    public Button[] rewardButtons = new Button[3];
    public TextMeshProUGUI[] rewardButtonTMPs = new TextMeshProUGUI[3];

    private void Awake()
    {
        rewardButtons = GetComponentsInChildren<Button>();
        rewardButtonTMPs = GetComponentsInChildren<TextMeshProUGUI>();
        AddButtonListeners();       //onClick 등록
    }
    private void AddButtonListeners()
    {
        foreach (Button button in rewardButtons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    public void AssignRandomValues()
    {
        // Initialize the list of available values
        availableValues = new List<int>();
        for (int i = 0; i <= maxWeaponID; i++)
        {
            availableValues.Add(i);
        }

        // Assign random values to buttons
        for (int i = 0; i < rewardButtons.Length; i++)
        {
            if (availableValues.Count > 0)
            {
                int randomIndex = Random.Range(0, availableValues.Count);
                int randomValue = availableValues[randomIndex];
                availableValues.RemoveAt(randomIndex);

                // Assign the random value to the button's name or a custom component
                rewardButtonTMPs[i].text = randomValue.ToString();
                rewardButtons[i].gameObject.name = "Reward_Btn_" + randomValue.ToString(); // Alternatively, use the button's name
                availableWeaponIDs[i] = randomValue;
            }
        }
    }

    private void OnButtonClick(Button button)
    {
        int index = 100;
        for(int i = 0;i < rewardButtons.Length; i++)
        {
            if(rewardButtons[i] == button)
            {
                index = availableWeaponIDs[i];
            }
        }
        WeaponManager.Instance.AddWeapon(index);
       
    }

}
