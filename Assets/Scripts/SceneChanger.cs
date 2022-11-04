using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    #region Singleton

    public static SceneChanger instance;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    #endregion

    [SerializeField] Image curtain;
    [SerializeField] string nextScene;

    private void Start()
    {
        StartCoroutine(fadeOut());
    }

    public void launchFadeIn()
    {
        StartCoroutine(fadeIn());
    }

    IEnumerator fadeIn()
    {
        float alpha = 0;
        while (alpha < 1)
        {
            curtain.color = new Color(0,0,0,alpha);
            alpha += 0.05f;
            //curtain.color = Color.Lerp(new Color(0,0,0,0), colorToFade, timeToFade);
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene(nextScene.ToString());
    }

    IEnumerator fadeOut()
    {
        float alpha = 1;
        while (alpha > 0)
        {
            curtain.color = new Color(0, 0, 0, alpha);
            alpha -= 0.05f;
            //curtain.color = Color.Lerp(new Color(0,0,0,0), colorToFade, timeToFade);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
