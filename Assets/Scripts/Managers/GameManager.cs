using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    InputManager inputManager;
    public InputManager InputManager
    {
        get
        {
            if (inputManager == null)
                inputManager = FindAnyObjectByType<InputManager>();
            return inputManager;

        }
    }

    ItemManager itemManager;
    public ItemManager ItemManager
    {
        get
        {
            if(itemManager == null)
                itemManager = FindAnyObjectByType<ItemManager>();
            return itemManager;
        }
    }

    StateManager stateManager;
    public StateManager StateManager
    {
        get
        {
            if(stateManager == null)
                stateManager = FindAnyObjectByType<StateManager>();
            return stateManager;
        }
    }

    UIManager uiManager;
    public UIManager UiManager
    {
        get
        {
            if(uiManager == null)  
                uiManager = FindAnyObjectByType<UIManager>();
            return uiManager;
        }
    }

    WeaponManager weaponManager;
    public WeaponManager WeaponManager
    {
        get
        {
            if (weaponManager == null)
                weaponManager = FindAnyObjectByType<WeaponManager>();
            return weaponManager;
        }
    }

}
