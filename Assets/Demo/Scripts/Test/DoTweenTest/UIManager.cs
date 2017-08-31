using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour {

    public RectTransform panelTransform;
    public bool panelIsOn;

	// Use this for initialization
	void Start () {
        panelIsOn = false;
        //默认动画播放完会销毁,用一个值来保存它,放在Start里就只生成了一次
        //Tweener tweener = panelTransform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);//修改局部坐标
        Tweener tweener = panelTransform.DOLocalMoveX(0, 0.5f);//修改局部坐标
        tweener.SetAutoKill(false);//关闭自动销毁
        tweener.SetEase(Ease.OutBounce);//设置动画曲线
        tweener.SetLoops(0);//设置循环几次
        tweener.Pause();//避免自动播放
        tweener.OnPlay(OnTweenPlay);
        tweener.OnComplete(OnTweenComplete);//设置当动画播放完成时触发的事件，注意没有参数

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (!panelIsOn)
            {
                panelTransform.DOPlayForward();//向前播放，用DoPlay只播放一次
                 panelIsOn = true;
            }
            else {
                panelTransform.DOPlayBackwards();//动画倒放
                panelIsOn = false;
            }
            
        }
	}

    void OnTweenPlay() {
        Debug.Log("开始播放动画");
    }
    void OnTweenComplete() {
        Debug.Log("动画播放完成");
    }

    
}
