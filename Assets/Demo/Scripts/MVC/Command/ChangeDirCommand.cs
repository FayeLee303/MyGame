using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirCommand : EventCommand {
    //注入数据模型
    [Inject]
    public RoleModel player { get; set; }
    public override void Execute()
    {
        Retain();
        //执行转向操作
        Debug.Log("接受ChangeDir事件并执行某些操作");
        Release();
    }
}
