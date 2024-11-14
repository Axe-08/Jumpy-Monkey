using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class solidPlatform : BasePlatform
{
    public float bounceFactor=1f;
    protected override void Update()
    {
        base.Update();  

    }
    public void toggleDecoyTrue()
    {
        setDecoyTrue();
    }
    protected override void setDecoyTrue()
    {
        base.setDecoyTrue();
    }

    protected float getBounce()
    {
        return bounceFactor;
    }
}   
