using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationView : FightingBaseView {

    [Inject]
    public FightingCommon common { get; set; }
    //有按键按下时
    public void OnClick(GameObject o)
    {
        Debug.Log("输入"+o.name);
        CustomOperationEventData data = new CustomOperationEventData
        {
            type = GameConfig.OperationEvent.CLICK_DOWN,
            str = o.name,
           
            OperationEventType = GameConfig.OperationEvent.CLICK_DOWN
            
        };
        
        common.SwithMoveDir(data);
        common.SwithCamDir(data);
        dispatcher.Dispatch(GameConfig.OperationEvent.CLICK_DOWN, data);
    }

    //有按键抬起时
    public void OnRelease(GameObject o)
    {
        CustomOperationEventData data = new CustomOperationEventData
        {
            type = GameConfig.OperationEvent.CLICK_UP,
            str = o.name,
         OperationEventType = GameConfig.OperationEvent.CLICK_UP
        };
        common.SwithMoveDir(data);
        common.SwithCamDir(data);
        dispatcher.Dispatch(GameConfig.OperationEvent.CLICK_UP, data);
    }
}
