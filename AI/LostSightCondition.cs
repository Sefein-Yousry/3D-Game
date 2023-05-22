using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LostSightCondition", menuName = "SVS_AI/conditions/LostSightConsition")]
public class LostSightCondition : conditions
{
    public override bool Test(Agent agent)
    {
        return agent.target == null;
    }
}
