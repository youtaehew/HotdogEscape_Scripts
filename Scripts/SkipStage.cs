using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipStage : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManagement.Instance.MoveNextScene();
        }
    }
}
