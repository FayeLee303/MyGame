using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MiniMapManager {

    //做成一个单例模式，每次启动的时候重新画一张图
    private static MiniMapManager _instance;
    public static MiniMapManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MiniMapManager();
            }
            return _instance;
        }
    }

    private Camera mapCam;//拍小地图的摄像机
    private RenderTexture renderTexture;//摄像机的渲染纹理
    private Texture2D mapTex;//摄像机的渲染纹理转成的Texture2D形式
    //private string filePath; //存临时地图的路径
    private Image mapImg;
    private Transform playerTrans;
    public Texture2D playerIcon;

    public int width = 900;
    public int height = 450;

    //私有的构造方法
    private MiniMapManager()
    {
        //初始化
        mapCam = GameObject.Find("MapCam").GetComponent<Camera>();
        this.renderTexture = mapCam.activeTexture;
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;


        //FileInfo fileInfo = new FileInfo("tempMap.png");
        //if (!fileInfo.Exists)
        //{
        //    Tex2Png();
        //}

        if (GameObject.Find("MiniMap") == null)
        {
            Debug.Log(mapImg);
            return;
        }
        else
        {
            this.mapImg = GameObject.Find("MiniMap").GetComponent<Image>();
            Debug.Log(mapImg);
        }
      
        RT_Texture_UIImg();
     
    }

    public void Init()
    {
        //Do Nothing
    }

    //把相机渲染出来的RenderderTexture转成Texture2D，根据这个Texture2D生成Sprite并赋值给Image组件
    private void RT_Texture_UIImg()
    {
        int width = renderTexture.width;
        int height = renderTexture.height;
        mapTex = new Texture2D(width, height, TextureFormat.ARGB32, false);
        RenderTexture.active = renderTexture;
        mapTex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        mapTex.Apply();
        //创建一个Sprite并赋给Image组件
        //后面Vector2就是你Anchors的Pivot的x / y属性值
        Sprite sp = Sprite.Create(mapTex, new Rect(0, 0, mapTex.width, mapTex.height), new Vector2(0.5f, 0.5f));
        mapImg.sprite = sp;
    }

    //根据玩家在地图和位置和在Map图片的比例在图上画出玩家的Icon
    void DrawPlayer()
    {
        
    }

    ////把Texture2D转换为PNG存在temp文件夹里
    //public void Tex2Png ()
    //{
    //    byte[] bytes = mapTex.EncodeToPNG();
    //    if (bytes != null && bytes.Length > 0)
    //    {
    //        File.WriteAllBytes(Application.dataPath+"/_Resources/Resources/temp/tempMap.png", bytes); //会把原来的图覆盖掉
    //    }   
    //}
}
