using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected Enemy _enemy;
    protected EnemyStateMachine _stateMachine;
    protected int _animboolHash;
    protected bool _animationEndTrigger;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animboolName)    {
        _enemy = enemy;
        _stateMachine = stateMachine;
        _animboolHash = Animator.StringToHash(animboolName);
    }

    public virtual void Enter()
    {
        _enemy.AnimatorComp.SetBool(_animboolHash, true);
        _animationEndTrigger = false;
    }

    public virtual void UpdateState()
    {

    }

    public virtual void Exit()
    {
        _enemy.AnimatorComp.SetBool(_animboolHash, false);
    }

    public void AnimationEndTrigger()
    {
        _animationEndTrigger = true;
    }
}
