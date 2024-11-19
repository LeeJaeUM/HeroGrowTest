using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public void ChangeToGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
