using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillModel {

	public string Name{ get; set; }//技能名
    public int Id { get; set; }//技能编号
    public int Damage { get; set; }//技能伤害
    public string Description { get; set; }//描述
    public List<BuffModel> Buff { get; set; }//附加buff
    public int AnimationId { get; set; }//技能动画编号
}
