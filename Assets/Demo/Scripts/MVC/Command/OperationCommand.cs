using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class OperationCommand : EventCommand {

    public override void Execute()
    {
        var cd = evt as CustomOperationEventData;
        Debug.Log(cd.dir);
        if (cd.dir == RoleModel.Direction.Up ||
            cd.dir == RoleModel.Direction.Down ||
            cd.dir == RoleModel.Direction.Left ||
            cd.dir == RoleModel.Direction.Right)
        {
            dispatcher.Dispatch(GameConfig.PlayerState.MOVE, cd.dir);
            Debug.Log("移动");
        }
        else if (cd.OperationEventType == GameConfig.OperationEvent.ATTACK)
        {
            dispatcher.Dispatch(GameConfig.PlayerState.FIGHT);
        }else if (cd.OperationEventType == GameConfig.OperationEvent.PICK)
        {
            //
        }else if (cd.OperationEventType == GameConfig.OperationEvent.TURN_LEFT ||
                  cd.OperationEventType == GameConfig.OperationEvent.TURN_RIGHT)
        {
            dispatcher.Dispatch(GameConfig.PlayerState.TURNDIRECTION, cd.turnDir);
        }
        else
        {
            Debug.Log("失败");
        }

    }
}
