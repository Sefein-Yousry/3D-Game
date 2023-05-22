using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class conditions : ScriptableObject
{
    public virtual bool Test(Agent agent)
    {
        return false;
    }
}
