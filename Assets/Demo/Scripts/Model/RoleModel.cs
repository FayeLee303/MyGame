using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleModel {

    public int Hp { get; set; }//生命值
    public int Mp { get; set; }//法力值
    public int MixHp { get; set; }//生命值上限
    public int MixMp { get; set; }//Mp上限
    public int Atk { get; set; }//攻击力
    public int Def { get; set; }//防御力
    public int MoveSpeed { get; set; }//移动速度
    public int AtkSpeed { get; set; }//攻击速度
    public int HpRecoveryRate { get; set; }//生命恢复速率
    public int MpRecoveryRate { get; set; }//法力恢复速率
    public List<WeaponModel> Weapon { get; set; } //武器
    public List<ItemModel> Item { get; set; }//道具
    public bool IsWeaponForbidden { get; set; }//是否禁用武器
    public bool IsItemForbodden { get; set; }//是否禁用道具
    public int AnimationId { get; set; }//角色动画编号

    public virtual void PlayAnimation(int animationId)
    {
        animationId = this.AnimationId;
        //根据动画Id播放动画
    }
}
