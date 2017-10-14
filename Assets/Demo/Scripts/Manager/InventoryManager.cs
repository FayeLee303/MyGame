using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class InventoryManager  {
    //做成单例模式
    private static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                //_instance = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
                _instance = new InventoryManager();
            }
            return _instance;
        }
        
    }

    //私有的构造方法
    private InventoryManager()
    {
        ParseItemJson();
        ParseWeaponJson();
    }

    public void Init()
    {
        toolTip = GameObject.Find("ToolTip").GetComponent<ToolTip>();
        pickedItem = GameObject.Find("PickedObj").GetComponent<ItemObj>();
    }

#region Item相关
    public List<ItemModel> itemList;
    /// <summary>
    /// 解析物品信息
    /// </summary>
    private void ParseItemJson()
    {
        //文本在Unity里面是TextAsset类型
        TextAsset itemJsonText = Resources.Load<TextAsset>("Localization/ItemJson");
        if (itemJsonText != null)
        {
            string itemJsonString = itemJsonText.text;
            itemList = JsonMapper.ToObject<List<ItemModel>>(itemJsonString);
            //itemList = JsonUtility.FromJson<List<ItemModel>>(itemJsonString);
            if (itemList == null) return;
            //foreach (ItemModel item in itemList)
            //{
            //    Debug.Log(item);
            //}
        }
        else
        {
            Debug.Log("读取文件失败");
        }
    }

    //根据id从列表里取得物品
    public ItemModel GetItemById(int id)
    {
        foreach (ItemModel item in itemList)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return null;
    }
    #endregion

#region Weapon相关
    public List<WeaponModel> weaponList;
    /// <summary>
    /// 解析武器信息
    /// </summary>
    private void ParseWeaponJson()
    {
        //文本在Unity里面是TextAsset类型
        TextAsset weaponJsonText = Resources.Load<TextAsset>("Localization/WeaponJson");
        if (weaponJsonText != null)
        {
            string weaponJsonString = weaponJsonText.text;
            //Debug.Log(weaponJsonString);
            weaponList = JsonMapper.ToObject<List<WeaponModel>>(weaponJsonString);
            //if (weaponList == null) Debug.Log("读取文件失败");
        }
        else
        {
            Debug.Log("读取文件失败");
        }
    }  

    //根据id从列表里取武器
    public WeaponModel GetWeaponById(int id)
    {
        foreach (WeaponModel weapon in weaponList)
        {
            if (weapon.Id == id)
            {
                return weapon;
            }
        }

        return null;
    }
    #endregion

#region ToolTip相关
    public ToolTip toolTip;
    public bool isToolTipShow = false;

    public void ShowToolTip(string content)
    {
        if (this.isPicked) return;//如果当前鼠标上有选中的物品就不显示信息面板
        isToolTipShow = true;
        toolTip.ShowToolTip(content);
    }

    public void HideToolTip()
    {
        isToolTipShow = false;
        toolTip.HideToolTip();
    }

    #endregion

#region PickedItem相关
    private ItemObj pickedItem;//鼠标选中的物体
    private bool isPicked = false; //标志是否选中

    public bool IsPicked
    {
        get { return isPicked; }
    }

    public ItemObj PickedItem
    {
        get { return pickedItem; }
    }

    //拿起物品槽中指定数量的物品
    public void PickUpItem(ItemModel item,int amount)
    {
        PickedItem.SetItem(item,amount);
        isPicked = true;
        this.toolTip.HideToolTip(); //隐藏信息面板
    }

#endregion
}
