using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sequence = DG.Tweening.Sequence;


public enum PlayerStateEnum
{
    Idle,
    Walk,
    Run,
    Jump,
    Fall,
    FallFlat,
    Die
}

public class Player : Agent
{
    [Header("Setting value")]
    public float WalkSpeed = 2f;
    public float RunSpeed = 4f;
    public float JumpPower = 5f;

    public float JumpMaxTime = 1;

    public float CurrentSpeed = 0;

    public bool isDead;


    public PlayerStateMachine StateMachine { get; private set; }
    [SerializeField]
    private
        PlayerInput _playerInput;
    public PlayerInput PlayerInput => _playerInput;
    
    

    protected override void Awake()
    {
        base.Awake();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StateMachine = new PlayerStateMachine();

        foreach (PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = stateEnum.ToString();

            try
            {
                Type t = Type.GetType($"Player{typeName}State");
                PlayerState state = Activator.CreateInstance(t, this, StateMachine, typeName) as PlayerState;

                StateMachine.AddState(stateEnum, state);

            }
            catch (Exception e)
            {
                Debug.LogError(typeName + "\n");
                Debug.LogError(e.Message);
            }
        }
    }

    protected void Start()
    {
        StateMachine.Initalize(PlayerStateEnum.Idle, this);
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
        if (isDead)
        {
            StateMachine.ChangeState(PlayerStateEnum.Die);
        }
    }

    public void PlayerDie()//ÀÌ°É·Î Á×´Â°Å ÇÏ¸é µÊ
    {
        isDead = true;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            PlayerDie();
        }
    }

}
