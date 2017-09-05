using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class InventoryManager : MonoBehaviour {
    //做成单例模式
    #region
    private static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            }
            return _instance;
        }
        set
        {
            
        }
    }
    #endregion

    private void Start()
    {
        ParseItemJson();
    }

    public List<ItemModel> itemList;
    //private string itemJsonPath = Application.dataPath+"Resources/Localization/ItemJson";
    /// <summary>
    /// 解析物品信息
    /// </summary>
    private void ParseItemJson()
    {
        itemList = new List<ItemModel>();
        //文本在Unity里面是TextAsset类型
        TextAsset itemJsonText = Resources.Load<TextAsset>("Localization/ItemJson") as TextAsset;
        if (itemJsonText != null)
        {
            string itemJsonString = itemJsonText.text;
            itemList = JsonMapper.ToObject<List<ItemModel>>(itemJsonString);
            if (itemList == null) return;
            foreach (ItemModel item in itemList)
            {
                Debug.Log(item);
            }
        }
        else
        {
            Debug.Log("读取文件失败");
        }
    }
   

}
