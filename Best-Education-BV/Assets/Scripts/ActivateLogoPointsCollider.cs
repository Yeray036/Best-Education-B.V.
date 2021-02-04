using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLogoPointsCollider : MonoBehaviour
{
	//if the user "space shuttle" enters the collider that the script is attached to. in this case will activate the LogoPoints script this will instatie the points.
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
