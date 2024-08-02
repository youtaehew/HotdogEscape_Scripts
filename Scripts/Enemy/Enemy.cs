using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum EnemyEnum
{
    Idle,
    Chase
}

public class Enemy : MonoBehaviour
{
    #region Componets region
    public EnemyMovement MoveComp { get; protected set; }
    public Animator AnimatorComp { get; protected set; }
    public Collider ColliderComp { get; protected set; }
    public SkinnedMeshRenderer MeshRenderComp { get; protected set; }
    #endregion


    #region Setting Values
    [Header("Setting Values")]
    public float CheckDis = 7;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] public LayerMask ObstacleLayer;
    #endregion

    [HideInInspector] public Collider[] playerCheckCollider;
    [HideInInspector] public Transform targetTrm;

    public EnemyStateMachine StateMachine { get; protected set; }

    public bool CanStateChangealble = true;




    private void Awake()
    {
        MeshRenderComp = transform.Find("Visual").GetChild(0).GetComponent<SkinnedMeshRenderer>();
        MoveComp = GetComponent<EnemyMovement>();
        ColliderComp = GetComponent<Collider>();
        AnimatorComp = transform.Find("Visual").GetComponent<Animator>();
        StateMachine = new EnemyStateMachine();

        foreach (EnemyEnum stateEnum in Enum.GetValues(typeof(EnemyEnum)))
        {
            string typeName = stateEnum.ToString();
            Type t = Type.GetType($"Enemy{typeName}State");
            try
            {
                EnemyState state = Activator.CreateInstance(t, this, StateMachine, typeName) as EnemyState;
                StateMachine.AddState(stateEnum, state);
            }
            catch (Exception e)
            {
                Debug.LogError($"no State Founs [{typeName}] - {e.Message}");
            }
        }
    }
    private void Start()
    {
        StateMachine.Initalize(EnemyEnum.Idle, this);
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }
    public Collider IsPlayerInRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, CheckDis, playerLayer);

        if (cols.Length > 0)
        {
            return cols[0];
        }
        return null;
    }
    public void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //end
            ColliderComp.enabled = false;
            SceneManagement.Instance.MoveNextScene();
        }
    }
}


