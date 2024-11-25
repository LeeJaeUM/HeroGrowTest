using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WeaponAttackLogic : MonoBehaviour
{
    protected Transform player;
    protected WeaponData weaponData;

    private void Start()
    {
        FindPlayer();
        weaponData = GetComponent<WeaponData>();
    }
  
    protected void FindPlayer()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        if (_player != null)
        {
            player = _player.transform;
        }
        else
        {
            Debug.LogWarning("Player 태그를 가진 오브젝트를 찾을 수 없습니다!");
        }
    }
}
