using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class TestSceneControl : BaseSceneControl
{
    public override void onStart()
    {
        //TimeMgr.Instance.setTimerHandler(new TimerHandler(999999999, true, 1f, updateGold)); 
        if (this.info != null)
        {
            DDOLObj.Instance.StartCoroutine(createEntityCrystal(info.CrystalTime));
            DDOLObj.Instance.StartCoroutine(createEntityMonster(info.AISpawnTimer));
        }
    }
}

