using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    //private List<ItemSlot> itemSlotList;
    private ItemSlot[] itemSlotList;

    public virtual void Start()
    {
        //得到插槽的链表
        //foreach (Transform child in transform)
        //{
        //    ItemSlot itemSlot = child.GetComponent<ItemSlot>();
        //    itemSlotList.Add(itemSlot);
        //}
        itemSlotList = transform.GetComponentsInChildren<ItemSlot>();
    }

    //根据ID存东西，如果存成功就返回true
    public bool StoreItem(int id)
    {
        ItemModel item = InventoryManager.Instance.GetItemById(id);
        return StoreItem(item);
    }

    //根据物品存东西，如果存成功就返回true
    public bool StoreItem(ItemModel item)
    {
        if (item == null)
        {
            Debug.LogWarning("要存的东西不存在");
            return false;
        }
        //看这个物体是不是只能存一个
        if (item.MaxLimit == 1)
        {
            ItemSlot slot = FindEmptyItemSlot();
            if (slot == null)
            {
                Debug.LogWarning("格子已经满了");
                return false;
            }
            else
            {
                slot.StoreItem(item); //把物品存进去
            }
        }
        else
        {
            ItemSlot slot = FindSameTypeSlot(item);
            if (slot == null)
            {
                //如果找不到存相同东西的格子就找一个新格子存
                ItemSlot _slot = FindEmptyItemSlot();
                if (_slot == null)
                {
                    Debug.LogWarning("格子已经满了");
                    return false;
                }
                else
                {
                    _slot.StoreItem(item); //把物品存进去
                }
            }
            else
            {
                slot.StoreItem(item); //把物品存进去
            }
        }
        return true;
    }

    //找一个空的格子
    private ItemSlot FindEmptyItemSlot()
    {
        foreach (ItemSlot itemSlot in itemSlotList)
        {
            if (itemSlot.transform.childCount == 0)
            {
                return itemSlot;
            }
        }
        return null;
    }

    //找一个装同样东西的格子
    private ItemSlot FindSameTypeSlot(ItemModel item)
    {
        foreach (ItemSlot slot in itemSlotList)
        {
            //当格子不为空，格子装同样东西，并且还没有装满时
            if (slot.transform.childCount >= 1 && slot.GetItemType() == item.Type && slot.IsFilled() == false)
            {
                return slot;
            }
        }
        return null;
    }
}
