using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel  {
    public int Id { get; set; }//武器编号
    public string Name { get; set; }//武器名字
    public int Atk { get; set; }//武器攻击力加成
    public int AtkRadius { get; set; }//攻击距离半径
    public int AtkSpeed { get; set; }//攻击速度加成
    public List<SkillModel> Skill { get; set; }//附加技能
}
