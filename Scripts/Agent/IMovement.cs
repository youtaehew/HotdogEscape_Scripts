using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    public Vector3 Velocity { get; }
    public bool IsGround { get; }
    public void Initalize(Agent agent);
    public void SetMovement(Vector3 movement, bool isRotation = true);
    public void StopImmediately();
    public void SetDetination(Vector3 destination);

    public float Verticalveocity { get; }
    public CharacterController CC { get; }

    public Vector3 MovementInput { get; set; }


    public void Jump();

}
