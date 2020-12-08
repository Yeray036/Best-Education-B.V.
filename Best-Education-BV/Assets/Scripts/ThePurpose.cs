using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePurpose : MonoBehaviour
{
    public GameObject gameManual;

    private void Start()
    {
        gameManual.SetActive(false);
    }

    public void OpenPurpose()
    {
        if (!gameManual.activeInHierarchy)
        {
            gameManual.SetActive(true);
        }
        else
        {
            gameManual.SetActive(false);
        }
    }
}
