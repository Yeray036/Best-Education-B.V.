using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLogoPointsCollider : MonoBehaviour
{
    public static bool ActivateLogoPointSpawner { get; set; }

    private void Start()
    {
        ActivateLogoPointSpawner = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpaceShuttle")
        {
            ActivateLogoPointSpawner = true;
        }
    }
}
