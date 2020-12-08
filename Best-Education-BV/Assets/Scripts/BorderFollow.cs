using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderFollow : MonoBehaviour
{
    public Transform target;

    public float speed = 150f;
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
