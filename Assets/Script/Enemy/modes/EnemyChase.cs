using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyModeBase
{
    public override void phase()
    {
        agent.SetDestination(new Vector3(player.transform.position.x, 0, player.transform.position.z));
    }
}
