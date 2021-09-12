using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class EnemyInformation : MonoBehaviour
{
   
    public EnemyUI playerscript;

    //public TeamManage teamManage;

    //public float[] playerIq;
    //public float[] enemyIq;
    //public float playerMaxIq;
    //public float enemyMaxIq;
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
    public Text critDamge;
    public Text iq;//脑力
    public Text charm;//魅力
    public Text drainLife;
    public Text blood; 
    

    public Text level;//等级

  private void Update() 
  {
   /*for (int i = 0; i < teamManage.players.Count; i++)
    {
        if(teamManage.players[i] != null)
        {
            playerIq[i] = teamManage.players[i].GetComponent<TeamPlayer>().iq;
        }
        if(teamManage.players[i] == null)
        {
            playerIq[i] = 0;
        }       
    }
    playerMaxIq = Mathf.Max(playerIq); */

    //if(playerMaxIq >= playerscript.iq)
    //{
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
    //}
    /*if(playerMaxIq < playerscript.iq)
    {
    hp.text = "???/???";
    mp.text = "???/???";
    sp.text = "???/???";
    ad.text = "???";
    ap.text = "???";
    def.text = "???";
    mdef.text = "???";
    speed.text ="???";
    dodge.text = "???";
    crit.text = "???";
    iq.text = "???";
    charm.text = "???";
    playername.text = playerscript.name.ToString();

    }*/
  }
}