using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickHide : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneChanger.instance.launchFadeIn();
        }
    }
}
