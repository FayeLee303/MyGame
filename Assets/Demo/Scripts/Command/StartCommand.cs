using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class StartCommand : Command {

    //开始命令，用来做一些初始化工作，框架外的东西也可以在这里Init
    //当这个命令执行时，默认调用Execute方法
    public override void Execute()
    {
        Debug.Log("StartCommand Execute");
        //UIPanelManager.Instance.Test();
        //InventoryManager.Instance();
    }
}
