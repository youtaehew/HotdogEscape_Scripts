using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClickStart : MonoBehaviour
{
    private bool canClick = false;
    [SerializeField] Image GameNameImage;
    [SerializeField] TextMeshProUGUI startText;
    private void Update()
    {
        if (!canClick) return;
        if (Input.GetMouseButtonDown(0))
        {
            
            startText.gameObject.SetActive(false);
            GameNameImage.gameObject.SetActive(false);
            SceneManagement.Instance.MoveNextScene();
            canClick = false;
        }
    }

    public void EndAnimation()
    {
        canClick = true;
        startText.DOFade(1, 1);
        GameNameImage.DOFade(1, 1);
    }
}
