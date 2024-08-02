using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animboolName) : base(enemy, stateMachine, animboolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Collider player = _enemy.IsPlayerInRange();
        if (player != null)
        {
            _enemy.targetTrm = player.transform;
            _stateMachine.ChangeState(EnemyEnum.Chase);
        }
    }
}
