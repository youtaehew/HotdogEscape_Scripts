using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.AudioCompo.Play();
        _player.MovementCompo.StopImmediately();
        _player.MovementCompo.Jump();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!_player.MovementCompo.IsGround)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }
}
