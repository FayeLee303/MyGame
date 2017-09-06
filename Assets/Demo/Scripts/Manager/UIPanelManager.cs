using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class UIPanelManager : MonoBehaviour
{
    /// <summary>
    /// 单例模式的核心
    /// 定义一个静态对象，在外界访问，在内部访问
    /// 构造方法私有化，保证只能在内部构造
    /// </summary>
    private static UIPanelManager _instance;

    public static UIPanelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("UIPanelManager").GetComponent<UIPanelManager>();
                //_instance = new UIPanelManager();//相当于调用下面的私有构造方法
            }
            return _instance;
        }
    }

    //私有的构造方法
    private UIPanelManager ()
    {
        //ParseUIPanelTypeJson();
    }

    private void Start()
    {
        ParseUIPanelTypeJson();
        Test();
    }

    //用字典储存所有面板prefab的路径
    private Dictionary<UIPanelType, string> panelPathDic;
    //解析Json文件
    private void ParseUIPanelTypeJson()
    {
        panelPathDic = new Dictionary<UIPanelType, string>();//把字典置空
        TextAsset ta = Resources.Load<TextAsset>("Localization/UIPanelType");
        if (ta != null)
        {
            //解析Json文件的两种方法
            List<UIPanelInfo> panelInfoList = JsonMapper.ToObject<List<UIPanelInfo>>(ta.text);
            //List<UIPanelInfo> panelInfoList = JsonUtility.FromJson<List<UIPanelInfo>>(ta.text);
            foreach (UIPanelInfo info in panelInfoList)
            {
                //存到字典里
                panelPathDic.Add(info.PanelType,info.path);
            }
        }
        else
        {
            Debug.Log("读取文件失败");
        }
    }

    public void Test()
    {
        string path;
        panelPathDic.TryGetValue(UIPanelType.ItemPanel,out path);
        Debug.Log(path);
        Debug.Log("555555");
    }

}
