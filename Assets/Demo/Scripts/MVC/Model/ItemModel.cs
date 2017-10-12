using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel
{
  
    public int Id { get; set; }
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public string Description { get; set; }
    public int MaxLimit { get; set; }
    public string SpritePath { get; set; } //图片路径

    public enum ItemType
    {
        Consumable = 0,//消耗品
        Active = 1 //主动使用道具
    }

    public override string ToString()
    {
        return string.Format("Id: {0}, Name: {1}, Type:{2}, Description: {3}, MaxLimit: {4}, SpritePath: {5}", Id, Name,Type, Description, MaxLimit, SpritePath);
    }

    //得到显示面板应该显示的内容
    public virtual string GetToolTipText()
    {
        return Name;//TODO
    }
}
