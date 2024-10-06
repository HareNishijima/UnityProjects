using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager
{
    public void ToGameOver()
    {
        new TimeScaleManager().UpdateTimeScale(0f);
    }
}
