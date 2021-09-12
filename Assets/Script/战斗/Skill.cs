using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill/New Skill")]//创造新的选项
public class Skill : ScriptableObject
{
[Header("技能名字")]
public string skillName;
[Header("领域技能（战斗开始立即释放，只释放一次）")]
[Header("技能释放机制（领域/主动/被动/回合/击杀/死亡/结束，七选一）")]
public bool startSkill;//光环buff
[Header("主动技能（每回合概率释放，需要消耗蓝量或者体力）")]
public bool activeSkill;//主动技能
[Header("被动技能（攻击后有概率释放）")]
public bool endSkill;//被动技能
[Header("被动概率(被动技能需要设置概率，可以100%)")]
public int endSkillOdd;//被动概率
[Header("回合技能（每回合结束前释放）")]
public bool turnSkill;//回合结束技能
[Header("击杀型技能（击杀怪物触发）")]
public bool killSkill;
[Header("死亡型技能（怪物死亡触发）")]
public bool deathSkill;
[Header("结束型技能（战斗结束后触发（例子：每经历一场战斗成长一次））")]
public bool overSkill;



[Header("攻击加成技能")]
[Header("伤害型技能选择(可多选)")]
//public float baseDamage;
//[Header("攻击加成技能")]
public bool adSkill;
public float adSkillFactor;//技能系数
[Header("法强加成技能")]
public bool apSkill;
public float apSkillFactor;
[Header("脑力加成技能")]
public bool iqSkill;
public float iqSkillFactor;
[Header("生命加成技能")]
public bool hpSkill;
public float hpSkillFactor;



[Header("消耗魔量/体力/生命（可多选）（固定数值，无百分比）")]
 public float mp;
 public float sp;
 public float hp;

[Header("眩晕/缴械")]
public bool dizzy;
public bool disarm;

[Header("单体伤害")]
[Header("技能种类（单体伤害/群体伤害/单体buff/群体buff/单体debuff/群体debuff）(可单选，可多选)（多选可选一个buff，一个伤害）")]
public bool singleDamage;//单体伤害
[Header("群体伤害")]
public bool teamDamage;//群体伤害
[Header("单体队友buff")]
public bool singleBuff;//单体buff
[Header("全队buff")]
public bool teamBuff;//群体buff
[Header("自我buff")]
public bool ownBuff;//单体buff
[Header("单体敌人debuff")]
public bool singleDebuff;//单体debuff
[Header("群体敌人debuff")]
public bool teamDebuff;//群体debuff

[Header("成长性技能")]
public bool growthSkill;//成长型技能
[Header("成长属性（攻击/法强/最大生命/物防/魔防/暴击伤害/脑力/魅力）（单选）")]
public float ad;
public float ap;
public float totalhp;
public float speed;
public float def;
public float mdef;
public float critDamge;
public float iq;
public float charm;
 [Header("buff及debuff类型")]
//public int buffID;//
public BuffAndDebuff buff;




//public float skillFactor;




    


    
}

   