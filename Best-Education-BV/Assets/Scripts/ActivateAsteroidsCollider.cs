using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAsteroidsCollider : MonoBehaviour
{
	//If user "space shuttle" enters the collider that the script is attached to. it will activate the DeployAsteroids script.
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
