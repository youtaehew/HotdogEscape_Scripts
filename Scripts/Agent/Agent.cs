using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    #region 컴포넌트 목록
    public Animator AnimatorCompo { get; protected set; }
    public IMovement MovementCompo { get ; protected set; }
    public Collider ColliderComp { get; protected set; }
    public AudioSource AudioCompo { get; protected set; }
    #endregion

    public bool CanStateChangeable { get; protected set; } = true;

    public Image dieImage;
    public TextMeshProUGUI dieText;


    protected virtual void Awake()
    {
        Transform visualTrm = transform.Find("Visual");
        AnimatorCompo = visualTrm.GetComponent<Animator>();
        MovementCompo = GetComponent<IMovement>();
        ColliderComp = GetComponent<Collider>();
        AudioCompo = GetComponent<AudioSource>();   
        MovementCompo.Initalize(this);
    }



    #region Delay Callback

    public Coroutine StartDelayCallback(float  time, Action Callback)
    {
        return StartCoroutine(DelayCoroutine(time, Callback));
    }

    private IEnumerator DelayCoroutine(float time, Action Callback)
    {
        yield return new WaitForSeconds(time);
        Callback?.Invoke();
    }
    #endregion

}
