﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePurpose : MonoBehaviour
{
	//in the main menu there is a question mark on the top right corner this is to see the game manual.
	//this script will activate the panel in the Hierarchy.
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
