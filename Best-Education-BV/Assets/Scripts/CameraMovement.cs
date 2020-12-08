using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public Animator cameraMovements;
    public Animator astroMovement;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovements = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        astroMovement = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }
}
