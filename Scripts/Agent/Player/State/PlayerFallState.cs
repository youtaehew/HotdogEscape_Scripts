using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.MovementEvent += HandleMovement;
    }



    public override void Exit()
    {
        base.Exit();
        _player.PlayerInput.MovementEvent -= HandleMovement;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_player.MovementCompo.IsGround)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    private void HandleMovement(Vector3 movement)
    {
        var right = Camera.main.transform.right;
        right.y = 0;
        var forward = Quaternion.AngleAxis(-90, Vector3.up) * right;
        Vector3 velocity = (movement.x * right) + ((movement.z * forward));
        velocity *= _player.CurrentSpeed * .5f;
        _player.MovementCompo.MovementInput = velocity;
        velocity.y = _player.MovementCompo.Verticalveocity;
        _player.MovementCompo.SetMovement(velocity, true);

    }
}
