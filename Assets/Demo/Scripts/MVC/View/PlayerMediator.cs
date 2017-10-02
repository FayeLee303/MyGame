using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMediator : Mediator {
    [Inject]
    public PlayerView playerView { get; set; }

    [Inject]
    public RoleModel player { get; set; }

    //定义了一个事件派发器，并且设置为全局派发器
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }

    //当所有的属性注入之后运行时就会注册
    public override void OnRegister()
    {
        playerView.Dispatcher.AddListener(ViewEvent.PlayerTurnDown, PlayerTurnDown);
        playerView.Dispatcher.AddListener(ViewEvent.PlayerTurnUp, PlayerTurnUp);
        playerView.Dispatcher.AddListener(ViewEvent.PlayerTurnLeft, PlayerTurnLeft);
        playerView.Dispatcher.AddListener(ViewEvent.PlayerTurnRight, PlayerTurnRight);

        playerView.PlayerFaccDir(player.RoleDir);

    }

    public override void OnRemove()
    {
        playerView.Dispatcher.RemoveListener(ViewEvent.PlayerTurnDown, PlayerTurnDown);
        playerView.Dispatcher.RemoveListener(ViewEvent.PlayerTurnUp, PlayerTurnUp);
        playerView.Dispatcher.RemoveListener(ViewEvent.PlayerTurnLeft, PlayerTurnLeft);
        playerView.Dispatcher.RemoveListener(ViewEvent.PlayerTurnRight, PlayerTurnRight);
    }


    public void PlayerTurnDown()
    {
        player.RoleDir = RoleModel.Direction.Down;
    }
    public void PlayerTurnUp()
    {
        player.RoleDir = RoleModel.Direction.Up;
    }
    public void PlayerTurnLeft()
    {
        player.RoleDir = RoleModel.Direction.Left;
    }
    public void PlayerTurnRight()
    {
        player.RoleDir = RoleModel.Direction.Right;
    }
}
