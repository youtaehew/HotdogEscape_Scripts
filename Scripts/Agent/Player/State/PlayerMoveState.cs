using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    private Vector3 moveDir;
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.MovementEvent += HandleMoveEvent;
    }

    public override void Exit()
    {
        base.Exit();
        _player.MovementCompo.StopImmediately();
        _player.PlayerInput.MovementEvent -= HandleMoveEvent;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        base.UpdateState();
        var right = Camera.main.transform.right;
        right.y = 0;
        var forward = Quaternion.AngleAxis(-90, Vector3.up) * right;
        Vector3 velocity = (moveDir.x * right) + ((moveDir.z * forward));
        velocity *= _player.CurrentSpeed;
        _player.MovementCompo.MovementInput = velocity;
        velocity.y = _player.MovementCompo.Verticalveocity;
        _player.MovementCompo.SetMovement(velocity);
    }

    private void HandleMoveEvent(Vector3 movement)
    {
        float inputThreshold = 0.05f;
        if (movement.sqrMagnitude < inputThreshold)
        {
            _player.MovementCompo.MovementInput = Vector3.zero;
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _stateMachine.ChangeState(PlayerStateEnum.Run);
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _stateMachine.ChangeState(PlayerStateEnum.Walk);
            }

            moveDir = movement;
        }
    }

}
