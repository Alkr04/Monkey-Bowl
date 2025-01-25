using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyModeBase
{
    public override void phase()
    {
        agent.SetDestination(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }
}
