using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]//创造新的选项
public class Item : ScriptableObject
{
 [Header("物品配置属性")]
public string itemName;//名字
public Sprite itemImage;//图片
public Color itemColor;//颜色
public int itemHeld;//数量
public int itemID;//Id
 [Header("装备")]
public bool equipment;//装备
 [Header("装备种类（武器/上衣/鞋子/裤子/饰品/魂体）")]
public string equipmentClass;//装备种类
 [Header("武器种类（剑/枪/盾/法杖/书/匕首/符文/咒术）")]
public string weaponClass;

[Header("消耗品")]
public bool consumable;//消耗品
public int consumableTime;//消耗品的持续时间
[Header("血统")]
public bool blood;//血统
public bool singleBlood;
[Header("血统种类")]
public string bloodClass;
public int level;//等级
[Header("故事")]
public bool story;//故事

[Header("技能词条")]
public List<Skill> skillList = new List<Skill>();

public TextAsset textFile;

[TextArea]
[Header("物品信息")]
public string itemInfo;//信息
[Header("物品属性")]

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
    //public float dodgePCT;//闪避
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
    public int shieldFactor;//盾的系数
    public float skillOdds;//施法概率
    public bool assassin;//刺心

    public float baseTotalhp;
    public float baseDef;
    public float baseMdef;
    public float baseAd;
    public float baseAp;
    public float baseCharm;
    public float baseIq;
    public float baseSpeed;
    public float basePoint;
    public float baseCPoint;
    public float baseSPoint;
    public float baseSSSPoint;



    
}

   