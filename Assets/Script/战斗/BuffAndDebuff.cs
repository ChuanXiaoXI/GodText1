using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Buff", menuName = "Buff/New Buff")]//创造新的选项
public class BuffAndDebuff : ScriptableObject
{
   [Header("buff图标")]
   public Sprite buffImage;
   public string buffInfo;
 [Header("buff时长")]
public int buffTime;
 [Header("技能系数")]
public float skillFactor;
 [Header("眩晕")]
    public bool dizzy;
    public bool disarm;
 [Header("buff数值")]
    public float hp;
    public float mp;
    public float sp;
    public float replyHp;
    public float replyMp;
    public float replySp;
    public float replyHpPCT;
    public float replyMpPCT;
    public float replySpPCT;

    public float totalhp; 
    public float totalhpPCT;//血量与最大血量
    public float totalmp;  
    public float totalmpPCT;//魔量与最大魔量
    public float totalsp;  
    public float totalspPCT;//体力
    public float ad;  
    public float adPCT;//物攻
    public float ap;  
    public float apPCT;//法强
    public float def;  
    public float defPCT;//物防
    public float mdef;  
    public float mdefPCT;//魔防
    public float speed;  
    public float speedPCT;//速度
    public float dodge;  
    ///public float dodgePCT;//闪避
    public float crit;  
    //public float critPCT;//暴击率
    public float iq;  
    public float iqPCT;//脑力
    public float charm;  
    public float charmPCT;//魅力
    public float critDamge;  
    //public float critDamgePCT;//暴伤
    public float drainLife;  
    //public float drainLifePCT;//吸血
    public float sword;//剑的系数
    public float gun;//枪的系数
    public float shieldFactor;//盾的系数
    public float skillOdds;

/*public bool startSkill;//光环buff
public bool activeSkill;//主动技能
public bool endSkill;//被动技能
public bool growthSkill;//成长型技能

public int endSkillOdd;//被动概率*/

/*public bool singleDamage;//单体伤害
public bool teamDamage;//群体伤害*/
 [Header("buff对象（单体buff/群体buff/自身buff/单体debebuff/群体debuff）")]
public bool singleBuff;//单体buff
public bool teamBuff;//群体buff
public bool ownBuff;//单体buff
public bool singleDebuff;//单体debuff
public bool teamDebuff;//群体debuff
//public bool startBuff;



    
}

   