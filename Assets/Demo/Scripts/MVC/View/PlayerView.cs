using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : View {

    //局部事件派发器
    [Inject]
    public IEventDispatcher Dispatcher { get; set; }

    [Inject]
    public RoleModel Player { get; set; }

    public GameObject _p_up;
    public GameObject _p_down;
    public GameObject _p_left;
    public GameObject _p_right;

    protected override void Start()
    {
        _p_down.SetActive(true);
        _p_up.SetActive(false);
        _p_left.SetActive(false);
        _p_right.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            TurnUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            TurnDown();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            TurnLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TurnRight();
        }
    }

    void TurnLeft()
    {
        Dispatcher.Dispatch(ViewEvent.PlayerTurnLeft);
    }
    void TurnRight()
    {
        Dispatcher.Dispatch(ViewEvent.PlayerTurnRight);
    }
    void TurnUp()
    {
        Dispatcher.Dispatch(ViewEvent.PlayerTurnUp);
    }
    void TurnDown()
    {
        Dispatcher.Dispatch(ViewEvent.PlayerTurnDown);
    }

    public void PlayerFaccDir(RoleModel.Direction dir)
    {
        if (dir == RoleModel.Direction.Up)
        {
            _p_down.SetActive(false);
            _p_up.SetActive(true);
            _p_left.SetActive(false);
            _p_right.SetActive(false);
        }
        else if (dir == RoleModel.Direction.Down)
        {
            _p_down.SetActive(true);
            _p_up.SetActive(false);
            _p_left.SetActive(false);
            _p_right.SetActive(false);
        }
        else if (dir == RoleModel.Direction.Left)
        {
            _p_down.SetActive(false);
            _p_up.SetActive(false);
            _p_left.SetActive(true);
            _p_right.SetActive(false);
        }
        else if (dir == RoleModel.Direction.Right)
        {
            _p_down.SetActive(false);
            _p_up.SetActive(false);
            _p_left.SetActive(false);
            _p_right.SetActive(true);
        }
    }

}
