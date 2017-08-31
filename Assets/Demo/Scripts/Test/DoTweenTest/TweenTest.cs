using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenTest : MonoBehaviour {

    private DOTweenAnimation tweenAni;
	// Use this for initialization
	void Start () {
        //默认是从当前位置运行到目标位置，加上from之后就是从目标位置到当前位置
        //transform.DoMoveX(5, 1).from();//不加true就是不累积，就是从5回到当前位置
        //transform.DoMoveX(5, 1).from(true);//true表示相对坐标，就是从当前位置+5的地方回到当前位置
        tweenAni = this.GetComponent<DOTweenAnimation>();
        tweenAni.DOPlay();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
