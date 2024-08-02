using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.JumpEvent += HandleJump;
    }

    public override void Exit()
    {
        _player.PlayerInput.JumpEvent -= HandleJump;
        base.Exit();
    }

    private void HandleJump()
    {
        _stateMachine.ChangeState(PlayerStateEnum.Jump);
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
