using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    SystemManager systemManager;
    public SystemManager SystemManager
    {
        get
        {
            if (systemManager == null)
                systemManager = FindAnyObjectByType<SystemManager>();
            return systemManager;
        }
    }

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

    SceneStateManager stateManager;
    public SceneStateManager StateManager
    {
        get
        {
            if(stateManager == null)
                stateManager = FindAnyObjectByType<SceneStateManager>();
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
    
    PlayerManager playerManager;
    public PlayerManager PlayerManager
    {
        get
        {
            if(playerManager == null)
                playerManager = FindAnyObjectByType<PlayerManager>();
            return playerManager;
        }
    }

}
