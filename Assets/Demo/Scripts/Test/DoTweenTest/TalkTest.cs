using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TalkTest : MonoBehaviour {

    private Text text;
    public GameObject textTransform;
	// Use this for initialization
	void Start () {
        //text = this.GetComponent<Text>();
        //text.DOText("哈哈哈哈哈",2);
        //text.DOColor(Color.red,5);//颜色渐变
        //text.DOFade(0,10);//透明度渐变，可以渐隐之后动画Complete之后摧毁或隐藏

        Sequence talkSqu = DOTween.Sequence();//创建序s列

        DOTweenAnimation tweenAni = textTransform.GetComponent<DOTweenAnimation>();

        //DOTween.Sequence().;
        //Debug.Log(tweener.id);
        tweenAni.DOPlayById("4");

        //talkSqu.Append(tweenAni.);



    }

    // Update is called once per frame
    void Update () {
        
	}
}
