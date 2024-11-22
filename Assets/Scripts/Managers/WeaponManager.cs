using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weaponEncyclopedia;
    [SerializeField]
    private bool[] isWeaponInUse;  // 각 무기의 사용 여부를 추적하는 배열
    [SerializeField]
    private GameObject[] ingameWeapons; 
    private int maxWeaponSlots = 6;
    void Start()
    {
        // isWeaponInUse 배열의 크기를 weaponEncyclopedia 배열의 크기와 맞춰 초기화
        isWeaponInUse = new bool[weaponEncyclopedia.Length];
    }
    // 무기를 사용할 때, 사용 여부 업데이트
    public void UseWeapon(int index)
    {
        if (index >= 0 && index < weaponEncyclopedia.Length)
        {
            if (!isWeaponInUse[index])  // 무기가 사용 중이지 않으면
            {
                // 무기를 사용한다고 가정하고, 사용 여부를 true로 설정
                isWeaponInUse[index] = true;
                Debug.Log(weaponEncyclopedia[index].name + " is now in use.");
            }
            else
            {
                Debug.Log(weaponEncyclopedia[index].name + " is already in use.");
            }
        }
        else
        {
            Debug.LogWarning("Invalid index.");
        }
    }

    // 무기를 더 이상 사용하지 않으면, 사용 여부를 false로 설정
    public void StopUsingWeapon(int index)
    {
        if (index >= 0 && index < weaponEncyclopedia.Length)
        {
            isWeaponInUse[index] = false;
            Debug.Log(weaponEncyclopedia[index].name + " is no longer in use.");
        }
        else
        {
            Debug.LogWarning("Invalid index.");
        }
    }

    // 무기가 사용 중인지 체크하는 메서드
    public bool IsWeaponInUse(int index)
    {
        if (index >= 0 && index < weaponEncyclopedia.Length)
        {
            return isWeaponInUse[index];  // 해당 인덱스의 사용 여부 반환
        }
        return false;
    }

    //public void AddWeapon(int _weaponID)
    //{
    //    // 이미 획득한 무기가 있는지 고유 번호로 확인
    //    //Weapon existingWeapon = ingameWeapons.Find(w =>w.weaponID == weaponID);
    //    Weapon existingWeapon = null;

    //    for(int i = 0; i < ingameWeapons.Length; i++)
    //    {
    //        if(ingameWeapons[i].TryGetComponent<Weapon>(out existingWeapon))
    //        {

    //        }
    //    }
    //}
    //public List<Weapon> GetWeapons()
    //{
    //    return ingameWeapons;
    //}
}


            /*
            if (existingWeapon != null)
            {
                // 무기 업그레이드
                if (existingWeapon.UpgradeWeapon())
                {
                    Debug.Log($"{weapon.weaponName} 업그레이드! 현재 레벨: {existingWeapon.currentLevel}");
                }
                else
                {
                    Debug.Log($"{weapon.weaponName}은 최대 레벨에 도달했습니다.");
                }
            }
            else
            {
                // 새로운 무기를 추가
                if (ingameWeapons.Count < maxWeaponSlots)
                {
                    ingameWeapons.Add(weapon);

                    // prefab 인스턴스화
                    GameObject weaponInstance = Instantiate(weapon.prefab);

                    // WeaponManager의 자식으로 설정
                    weaponInstance.transform.SetParent(transform);
                    Debug.Log($"{weapon.weaponName} 획득!");
                }
                else
                {
                    Debug.Log("더 이상 무기를 추가할 수 없습니다.");
                }
            }*/