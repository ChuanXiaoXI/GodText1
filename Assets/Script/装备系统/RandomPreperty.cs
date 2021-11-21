using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Property", menuName = "Property/New Property")]//创造新的选项

public class RandomPreperty: ScriptableObject
{
    [Header("物品属性")]
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
    public float crit;   
    public float iq;  
    public float iqPCT;//脑力
    public float charm;  
    public float charmPCT;//魅力
    public float critDamge;  
    public float drainLife;  

    public float sword;//剑的系数
    public float gun;//枪的系数
    public int shieldFactor;//盾的系数
    public float skillOdds;//施法概率

    public string prepertyText;
}
