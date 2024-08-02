using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatioinFinishTrigger : MonoBehaviour
{
    private Enemy _enemy;


    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }
    public void AnimationEnd()
    {
        _enemy.AnimationEndTrigger();
    }
}
