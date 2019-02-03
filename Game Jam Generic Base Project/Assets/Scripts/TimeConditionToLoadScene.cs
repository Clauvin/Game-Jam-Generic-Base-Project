using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeConditionToLoadScene : AbstractConditionToLoadScene {

    public float actual_time;
    public float time_to_load_scene;

    public void Update()
    {
        CountTime();
    }

    public override bool ConditionToLoadHasBeenFulfilled()
    {
        if (actual_time >= time_to_load_scene) return true;
        else return false;
    }

    public void CountTime()
    {
        actual_time += Time.deltaTime;
    }
}
