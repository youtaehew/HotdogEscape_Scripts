using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallFlatState : PlayerState
{
    public PlayerFallFlatState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.StopImmediately();
        _player.StartCoroutine(StunTime());
    }

    IEnumerator StunTime()
    {
        yield return new WaitForSeconds(3f);
        if (_player.MovementCompo.IsGround)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
        else
        {
            _stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }
}
