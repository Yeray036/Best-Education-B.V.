using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public Animator cameraMovements;
    public Animator astroMovement;
	
	//this script is needed to switch between animation or else it will get follow issues using the animation movement.

    // Start is called before the first frame update
    void Start()
    {
        cameraMovements = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        astroMovement = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }
}
