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
                //_instance = GameObject.Find("UIPanelManager").GetComponent<UIPanelManager>();
                _instance = new UIPanelManager();//相当于调用下面的私有构造方法
            }
            return _instance;
        }
    }

    //画布
    private Transform canvasTransform;

    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }
    //用字典储存所有面板prefab的路径
    private Dictionary<UIPanelType, string> panelPathDic;
    //用字典储存所有实例化的面板的游戏物体上的BasePanel组件
    private Dictionary<UIPanelType, BasePanel> panelDic;
   
    //私有的构造方法
    private UIPanelManager ()
    {
        //ParseUIPanelTypeJson();
    }
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    { 
        ParseUIPanelTypeJson();
    }

    /// <summary>
    /// 根据面板类型，得到实例化的面板
    /// </summary>
    /// <returns></returns>
    public BasePanel GetPanel(UIPanelType panelType)
    {
        if (panelDic == null)
        {
            panelDic = new Dictionary<UIPanelType, BasePanel>();//创建空字典

        }
        //根据传过来的面板类型去面板字典里找
        //BasePanel panel;
        //panelDic.TryGetValue(panelType, out panel);//TODO
        BasePanel panel = panelDic.TryGet(panelType);
        if (panel == null)
        {
            //如果找不到，就在面板路径字典里找prefab的路径
            //string path;
            //panelPathDic.TryGetValue(panelType, out path);
            string path = panelPathDic.TryGet(panelType);
            //根据prefab的路径实例化物体
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            //放到画布下面
            instPanel.transform.SetParent(canvasTransform); //TODO
            panelDic.Add(panelType, instPanel.GetComponent<BasePanel>());
            return instPanel.GetComponent<BasePanel>();
        }
        else
        {
            return panel;
        }
    }

    /// <summary>
    /// 解析Json文件
    /// </summary>
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
                panelPathDic.Add(info.PanelType, info.path);
            }
        }
        else
        {
            Debug.Log("读取文件失败");
        }
        //string path;
        //panelPathDic.TryGetValue(UIPanelType.ItemPanel, out path);
        //Debug.Log(path);
        ////Debug.Log("555555");
    }

}
