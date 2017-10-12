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
    }

    public void Init()
    {
        toolTip = GameObject.Find("ToolTip").GetComponent<ToolTip>();
    }

    public List<ItemModel> itemList;

    public ToolTip toolTip;
    public bool isToolTipShow = false;

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

  
    public void ShowToolTip(string content)
    {
        isToolTipShow = true;
        toolTip.ShowToolTip(content);
    }

    public void HideToolTip()
    {
        isToolTipShow = false;
        toolTip.HideToolTip();
    }
}
