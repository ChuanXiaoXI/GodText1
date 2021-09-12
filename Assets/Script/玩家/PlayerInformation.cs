using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerInformation : MonoBehaviour
{
    //public Player_Class playerclass;
    public TeamPlayer playerscript;

    public Text playername;
    public Text hp;//血量与最大血量
    public Text mp;//魔量与最大魔量
    public Text sp;//体力
    public Text ad;//物攻
    public Text ap;//法强
    public Text def;//物防
    public Text mdef;//魔防
    public Text speed;//速度
    public Text dodge;//闪避
    public Text crit;//暴击率
    public Text iq;//脑力
    public Text charm;//魅力
    public Text blood; 
    public Text critDamge;//暴伤
    public Text drainLife;//吸血
    //public Text exp;//经验
    public Text level;//等级

    public int hp1,totalhp1;//血量与最大血量
    public int mp1,totalmp1;//魔量与最大魔量
    public int sp1,totalsp1;//体力
    public int ad1;//物攻
    public int ap1;//法强
    public int def1;//物防
    public int mdef1;//魔防
    public int speed1;//速度
    public int dodge1;//闪避
    public int crit1;//暴击率
    public int iq1;//脑力
    public int charm1;//魅力
    //public int blood; 
    public int critDamge1;//暴伤
    public int drainLife1;//吸血
    

private void Update() 
{
    //hp1 = Convert.ToInt16(playerscript.hp);
    //playerclass = playerscript.playerclass;
    hp.text = Convert.ToInt16(playerscript.hp).ToString() + "/" + Convert.ToInt16(playerscript.totalhp).ToString();
    mp.text = Convert.ToInt16(playerscript.mp).ToString() + "/" + Convert.ToInt16(playerscript.totalmp).ToString();
    sp.text = Convert.ToInt16(playerscript.sp).ToString() + "/" + Convert.ToInt16(playerscript.totalsp).ToString();
    ad.text = Convert.ToInt16(playerscript.ad).ToString();
    ap.text = Convert.ToInt16(playerscript.ap).ToString();
    def.text = Convert.ToInt16(playerscript.def).ToString();
    mdef.text = Convert.ToInt16(playerscript.mdef).ToString();
    speed.text = Convert.ToInt16(playerscript.speed).ToString();
    dodge.text = Convert.ToInt16(playerscript.dodge).ToString();
    crit.text = Convert.ToInt16(playerscript.crit).ToString();
    critDamge.text = Convert.ToInt16(playerscript.critDamge).ToString();
    drainLife.text = Convert.ToInt16(playerscript.drainLife).ToString();
    iq.text = Convert.ToInt16(playerscript.iq).ToString();
    charm.text = Convert.ToInt16(playerscript.charm).ToString();
    playername.text = playerscript.playerClass.playerName.ToString();
    if(playerscript.equipmentList[9] != null)
    {
        blood.text = playerscript.equipmentList[9].itemName; 
    }
}}