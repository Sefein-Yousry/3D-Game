using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="SightCondition", menuName ="SVS_AI/conditions/SightConsition")]
public class SightCondition : conditions
{
    public override bool Test(Agent agent)
    {
        return agent.target;
    }
}
