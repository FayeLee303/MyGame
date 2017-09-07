﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanel : BasePanel {

    public void OnPushPanel(string panelTypeString)
    {
        //转成枚举类型
        UIPanelType panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        UIPanelManager.Instance.PushPanel(panelType);
    }
}
