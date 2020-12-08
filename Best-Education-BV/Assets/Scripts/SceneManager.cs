using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    //This script will manage all scene changes, method names will tell what kind of scene it will activate.
    public RawImage blackFade;
    public Animator animFade;

    private void Update()
    {
        if (blackFade.color.a == 0)
        {
            blackFade.enabled = false;
        }
    }

    public void GoToRegister()
    {
        StartCoroutine(Fading(2));
    }

    public void GoToLogin()
    {
        StartCoroutine(Fading(1));
    }

    public void ReturnToMainMenu()
    {
        StartCoroutine(Fading(0));
    }

    IEnumerator Fading(int currentScene)
    {
        animFade.SetBool("Fade", true);
        yield return new WaitUntil(() => blackFade.color.a == 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }
}
