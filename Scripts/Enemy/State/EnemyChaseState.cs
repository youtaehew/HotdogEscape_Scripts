using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyChaseState : EnemyState
{
    private Vector3 _targetDestinaion;
    public EnemyChaseState(Enemy enemy, EnemyStateMachine stateMachine, string animboolName) : base(enemy, stateMachine, animboolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        float dis = (_targetDestinaion - _enemy.transform.position).magnitude;
        if (dis > 0.1f)
        {
            SetDestination(_enemy.targetTrm.position);
        }
    }

    private void SetDestination(Vector3 pos)
    {
        _targetDestinaion = pos;
        _enemy.MoveComp.SetDestination(pos);
    }
}
