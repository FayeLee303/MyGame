using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : RoleBaseEventView
{
    protected override void Start()
    {
        base.Start();
        Init(role);
    }

    public void Update()
    {
        GameUpdate();
    }


    //public GameObject _p_up;
    //public GameObject _p_down;
    //public GameObject _p_left;
    //public GameObject _p_right;

    //protected override void Start()
    //{
    //    _p_down.SetActive(true);
    //    _p_up.SetActive(false);
    //    _p_left.SetActive(false);
    //    _p_right.SetActive(false);
    //}

    //// Update is called once per frame
    //void Update ()
    //{
    //    ShowPlayer(role.RoleDir);
    //}

    //public void ShowPlayer(RoleModel.Direction dir)
    //{
    //    if (dir == RoleModel.Direction.Up)
    //    {
    //        _p_down.SetActive(false);
    //        _p_up.SetActive(true);
    //        _p_left.SetActive(false);
    //        _p_right.SetActive(false);
    //    }
    //    else if (dir == RoleModel.Direction.Down)
    //    {
    //        _p_down.SetActive(true);
    //        _p_up.SetActive(false);
    //        _p_left.SetActive(false);
    //        _p_right.SetActive(false);
    //    }
    //    else if (dir == RoleModel.Direction.Left)
    //    {
    //        _p_down.SetActive(false);
    //        _p_up.SetActive(false);
    //        _p_left.SetActive(true);
    //        _p_right.SetActive(false);
    //    }
    //    else if (dir == RoleModel.Direction.Right)
    //    {
    //        _p_down.SetActive(false);
    //        _p_up.SetActive(false);
    //        _p_left.SetActive(false);
    //        _p_right.SetActive(true);
    //    }
    //}

}
