using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 武器槽
/// </summary>
public class WeaponSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject weaponPrefab;


    //把weapon放在自身下面，重置冷却时间
    public void StoreWeapon(WeaponModel weapon)
    {
        //如果没有就实例化出来
        if (transform.childCount == 0)
        {
            GameObject weaponObj = Instantiate(weaponPrefab) as GameObject;
            weaponObj.transform.SetParent(this.transform);
            weaponObj.transform.localPosition = Vector3.zero; //归零
            weaponObj.GetComponent<WeaponObj>().SetWeapon(weapon);

            //重置冷却时间
            //weaponObj.GetComponent<WeaponObj>().SetCoolingTime();
        }
    }

    //返回当前武器槽储存的武器ID
    public int GetWeaponId()
    {
        return transform.GetChild(0).GetComponent<WeaponObj>().Weapon.Id;
    }

    //如果True就是这个武器槽装备了武器
    //要在其他地方判断两个武器槽都装备了武器
    public bool IsFilled()
    {
        WeaponObj weaponObj = transform.GetChild(0).GetComponent<WeaponObj>();
        if (weaponObj != null)
        { return true;}
        else return false;
    }

    //重写Unity自带的事件触发函数
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            string text = transform.GetChild(0).GetComponent<WeaponObj>().Weapon.GetToolTipText();
            InventoryManager.Instance.ShowToolTip(text); //要传递数据

        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            InventoryManager.Instance.HideToolTip();
        }
    }
}
