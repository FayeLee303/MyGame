using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物品槽
/// </summary>
public class ItemSlot : MonoBehaviour {

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
            transform.GetChild(0).GetComponent<ItemObj>().AddAmount(1);
        }
    }

    //返回当前物品槽储存的物品的类型
    public ItemModel.ItemType GetItemType()
    {
        return transform.GetChild(0).GetComponent<ItemObj>().Item.Type;
    }

    //如果True就是当前格子已经装满某物品了
    public bool IsFilled()
    {
        ItemObj itemObj = transform.GetChild(0).GetComponent<ItemObj>();
        return itemObj.Item.MaxLimit <= itemObj.Amount;
    }
}
