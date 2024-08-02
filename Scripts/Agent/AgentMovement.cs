using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float _gravity = -9.8f;

    protected CharacterController _characterController;

    #region ¼Óµµ°ü·Ã ·ÎÁ÷
    private Vector3 _velocity;
    public Vector3 Velocity => _velocity;
    private float _verticalVelocity;
    #endregion

    public bool IsGround =>
        _characterController.isGrounded;


    public float Verticalveocity => _verticalVelocity;

    public CharacterController CC => _characterController;

    public Vector3 MovementInput { get; set; }

    private Quaternion _targetRotation;

    private Agent _agent;

    public float JumpPower;





    public void Initalize(Agent agent)
    {
        _characterController = GetComponent<CharacterController>();
        _agent = agent;
    }

    private void Update()
    {
        ApplyRotation();

        Move();
        ApplyGraivity();




    }

    private void ApplyRotation()
    {
        if (MovementInput.sqrMagnitude > .3f)
        {

            Vector3 rotDir = MovementInput;
            rotDir.y = 0;
            _targetRotation = Quaternion.LookRotation(rotDir);
            float rotateSpeed = 8f;
            transform.rotation = Quaternion.Lerp(
                transform.rotation, _targetRotation, Time.deltaTime * rotateSpeed);
        }
    }

    private void ApplyGraivity()//³ªÁß¿¡ ÀÜ¶à ¹Ù²ã¾ßÇÔ
    {
        if (IsGround && _verticalVelocity <= 0)
        {
            _verticalVelocity = -4f;
        }
        else
        {
            _verticalVelocity += _gravity * Time.deltaTime;
        }
        _velocity.y = _verticalVelocity * Time.deltaTime;
    }


    public void SetMovement(Vector3 movement, bool isRotation = true)
    {
        _velocity = movement * Time.deltaTime;
    }
    public void Jump()
    {
        _verticalVelocity = JumpPower;
    }
    private void Move()
    {
        _characterController.Move(_velocity);
    }


    public void StopImmediately()
    {
        _velocity = Vector3.zero;
    }

    public void SetDetination(Vector3 destination)
    {
        Debug.Log("Set destination method is not used in agent movement");
    }


}
