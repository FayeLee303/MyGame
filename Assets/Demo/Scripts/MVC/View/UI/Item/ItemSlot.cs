using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 物品槽
/// </summary>
public class ItemSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

    public GameObject itemPrefab;
    

    //把item放在自身下面，如果已经有了就让数量增加
    public void StoreItem(ItemModel item)
    {
        //如果没有就实例化出来
        if (transform.childCount == 0)
        {
            GameObject itemObj = Instantiate(itemPrefab) as GameObject;
            itemObj.transform.SetParent(this.transform);
            itemObj.transform.localPosition = Vector3.zero; //归零
            itemObj.GetComponent<ItemObj>().SetItem(item, 1);
        }
        else
        {
            transform.Find("ItemObj(Clone)").GetComponent<ItemObj>().AddAmount(1);
        }
    }

    //返回当前物品槽储存的物品ID
    public int GetItemId()
    {
        return transform.Find("ItemObj(Clone)").GetComponent<ItemObj>().Item.Id;
    }

    //如果True就是当前格子已经装满某物品了
    public bool IsFilled()
    {
        ItemObj itemObj = transform.Find("ItemObj(Clone)").GetComponent<ItemObj>();
        return itemObj.Item.MaxLimit <= itemObj.Amount;
    }

    //重写Unity自带的事件触发函数
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            string text = transform.Find("ItemObj(Clone)").GetComponent<ItemObj>().Item.GetToolTipText();
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
