using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ClickQuit : MonoBehaviour
{
    private bool canClick = false;
    [SerializeField] TextMeshProUGUI startText;
    [SerializeField] TextMeshProUGUI endText;

    private void Awake()
    {
        
    }
    private void Update()
    {
        if (!canClick) return;
        if (Input.GetMouseButtonDown(0))
        {
            startText.gameObject.SetActive(false);
            Application.Quit();
            canClick = false;
        }
    }

    public void EndAnimation()
    {
        startText = GameObject.Find("Canvas (1)").transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        endText = GameObject.Find("Canvas (1)").transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        canClick = true;
        startText.DOFade(1, 1);
        endText.DOFade(1, 1);
    }
}
