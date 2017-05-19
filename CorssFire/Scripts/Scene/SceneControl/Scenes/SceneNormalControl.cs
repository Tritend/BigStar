using System;
using System.Collections.Generic;

public class SceneNormalControl : BaseSceneControl
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

