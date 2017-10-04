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

    public void Update()
    {
        GameUpdate();
    }

    //监听玩家对角色的输入
    public override void GameUpdate()
    {
        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S))
        {
            Debug.Log("按下");
            CustomOperationEventData data = new CustomOperationEventData
            {
                type = GameConfig.OperationEvent.KEY_DOWN,
                ismoving = true,
                OperationEventType = GameConfig.OperationEvent.KEY_DOWN
            };
            dispatcher.Dispatch(GameConfig.OperationEvent.KEY_DOWN, data);
        }
        if (Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.D) ||
            Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.S))
        {
            Debug.Log("抬起");
            CustomOperationEventData data = new CustomOperationEventData
            {
                type = GameConfig.OperationEvent.KEY_UP,
                ismoving = false,
                OperationEventType = GameConfig.OperationEvent.KEY_UP
            };
            dispatcher.Dispatch(GameConfig.OperationEvent.KEY_UP, data);
        }

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("按下" + KeyCode.A);
        //    CustomOperationEventData data = new CustomOperationEventData
        //    {
        //        type = GameConfig.OperationEvent.KEY_DOWN,
        //        dir = RoleModel.Direction.Left,
        //        OperationEventType = GameConfig.OperationEvent.KEY_DOWN
        //    };
        //    dispatcher.Dispatch(GameConfig.OperationEvent.KEY_DOWN, data);
        //}
        //else if(Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log("按下" + KeyCode.D);
        //    CustomOperationEventData data = new CustomOperationEventData
        //    {
        //        type = GameConfig.OperationEvent.KEY_DOWN,
        //        dir = RoleModel.Direction.Right,
        //        OperationEventType = GameConfig.OperationEvent.KEY_DOWN
        //    };
        //    dispatcher.Dispatch(GameConfig.OperationEvent.KEY_DOWN, data);
        //}
        //else if (Input.GetKeyDown(KeyCode.W))
        //{
        //    Debug.Log("按下" + KeyCode.W);
        //    CustomOperationEventData data = new CustomOperationEventData
        //    {
        //        type = GameConfig.OperationEvent.KEY_DOWN,
        //        dir = RoleModel.Direction.Up,
        //        OperationEventType = GameConfig.OperationEvent.KEY_DOWN
        //    };
        //    dispatcher.Dispatch(GameConfig.OperationEvent.KEY_DOWN, data);
        //}
        //else if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Debug.Log("按下" + KeyCode.S);
        //    CustomOperationEventData data = new CustomOperationEventData
        //    {
        //        type = GameConfig.OperationEvent.KEY_DOWN,
        //        dir = RoleModel.Direction.Down,
        //        OperationEventType = GameConfig.OperationEvent.KEY_DOWN
        //    };
        //    dispatcher.Dispatch(GameConfig.OperationEvent.KEY_DOWN, data);
        //}
        //else if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("按下" + KeyCode.W + "和" + KeyCode.A);
        //    CustomOperationEventData data = new CustomOperationEventData
        //    {
        //        type = GameConfig.OperationEvent.KEY_DOWN,
        //        dir = RoleModel.Direction.Up_Left,
        //        OperationEventType = GameConfig.OperationEvent.KEY_DOWN
        //    };
        //    dispatcher.Dispatch(GameConfig.OperationEvent.KEY_DOWN, data);
        //}
        //else if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("按下" + KeyCode.W + "和" + KeyCode.A);
        //    CustomOperationEventData data = new CustomOperationEventData
        //    {
        //        type = GameConfig.OperationEvent.KEY_DOWN,
        //        dir = RoleModel.Direction.Up_Left,
        //        OperationEventType = GameConfig.OperationEvent.KEY_DOWN
        //    };
        //    dispatcher.Dispatch(GameConfig.OperationEvent.KEY_DOWN, data);
        //}
        //else if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log("按下" + KeyCode.W + "和" + KeyCode.D);
        //    CustomOperationEventData data = new CustomOperationEventData
        //    {
        //        type = GameConfig.OperationEvent.KEY_DOWN,
        //        dir = RoleModel.Direction.Up_Right,
        //        OperationEventType = GameConfig.OperationEvent.KEY_DOWN
        //    };
        //    dispatcher.Dispatch(GameConfig.OperationEvent.KEY_DOWN, data);
        //}
        //else if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("按下" + KeyCode.S + "和" + KeyCode.A);
        //    CustomOperationEventData data = new CustomOperationEventData
        //    {
        //        type = GameConfig.OperationEvent.KEY_DOWN,
        //        dir = RoleModel.Direction.Down_Left,
        //        OperationEventType = GameConfig.OperationEvent.KEY_DOWN
        //    };
        //    dispatcher.Dispatch(GameConfig.OperationEvent.KEY_DOWN, data);
        //}
        //else if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log("按下" + KeyCode.W + "和" + KeyCode.A);
        //    CustomOperationEventData data = new CustomOperationEventData
        //    {
        //        type = GameConfig.OperationEvent.KEY_DOWN,
        //        dir = RoleModel.Direction.Down_Right,
        //        OperationEventType = GameConfig.OperationEvent.KEY_DOWN
        //    };
        //    dispatcher.Dispatch(GameConfig.OperationEvent.KEY_DOWN, data);
        //}
        //else
        //{
        //    
        //}

    }
}
