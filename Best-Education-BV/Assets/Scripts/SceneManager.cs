using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    //This script will manage all scene changes, method names will tell what kind of scene it will activate.
    
    public void GoToRegister()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void GoToLogin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
