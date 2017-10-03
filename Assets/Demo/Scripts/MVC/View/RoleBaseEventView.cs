using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class RoleBaseEventView : FightingBaseView {

    //protected是在外部不可以调用，并且只能在子类里实现
    //protected bool MoveState { get; set; } //移动状态
    //protected RoleModel.Direction dir { get; set; }
    [Inject]
    public RoleModel role { get; set; }

    private Rigidbody role_rb;

    public virtual void Init(RoleModel Role)
    {
        //初始化数据和一些组件
        Debug.Log("初始化");
        role = Role;
        role.RoleDir = RoleModel.Direction.None;
        role_rb = this.gameObject.GetComponent<Rigidbody>();
    }
    public virtual void MoveToDirection(IEvent e)
    {
        RoleModel.Direction _dir = (RoleModel.Direction)e.data;//强制转换传过来的数据为方向
        if (_dir != null)
        {
            role.RoleDir = _dir;
           
        }
    }

    public virtual void GameUpdate()
    {
        if (role == null)
            return;
        //在这里更新速度
        if (role.RoleDir == RoleModel.Direction.Down)
        {
            //role_rb.velocity = new Vector3(0, 0, -role.MoveSpeed);
            role_rb.velocity = new Vector3(0, 0, -1);
        }
        if (role.RoleDir == RoleModel.Direction.Up)
        {
            //role_rb.velocity = new Vector3(0, 0, role.MoveSpeed);
            role_rb.velocity = new Vector3(0, 0, 1);
        }
        if (role.RoleDir == RoleModel.Direction.Left)
        {
            //role_rb.velocity = new Vector3(-role.MoveSpeed, 0, 0);
            role_rb.velocity = new Vector3(-1, 0, 0);
        }
        if (role.RoleDir == RoleModel.Direction.Right)
        {
            //role_rb.velocity = new Vector3(role.MoveSpeed, 0, 0);
            role_rb.velocity = new Vector3(1, 0, 0);
        }
    }
}
