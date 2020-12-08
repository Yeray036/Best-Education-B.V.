using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAsteroidsCollider : MonoBehaviour
{
    public static bool ActivateAsteroidSpawner { get; set; }

    private void Start()
    {
        ActivateAsteroidSpawner = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpaceShuttle")
        {
            ActivateAsteroidSpawner = true;
        }
    }
}
