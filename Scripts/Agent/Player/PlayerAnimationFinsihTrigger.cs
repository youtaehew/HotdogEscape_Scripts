using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimationFinsihTrigger : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource audio;
    private void AnimationEnd()
    {
        _player.StateMachine.CurrentState.AnimationFinishTrigger();
    }

    public void Die()
    {
        audio.Play();
        Sequence seq = DOTween.Sequence();
        seq.Append(_player.dieImage.DOFade(1, 4));
        seq.Join(_player.dieText.DOFade(1, 4));
        seq.OnComplete(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        
    }
}
