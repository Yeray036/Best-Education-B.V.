using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderFollow : MonoBehaviour
{
	//this script will make sure the borders follow the player y position to make sure the player stays within the borders.
	//by using this script it will make sure the fps aslo stays stable.
	
    public Transform target;
    public float speed = 500f;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.position - transform.position).normalized;
        if ((transform.position - target.position).magnitude > 0.1f)
        {
            transform.Translate(new Vector3(0, direction.y * Time.deltaTime * speed, 0));
        }
    }
}
