using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;
    private float xAxis, zAxis;
    private Quaternion targetRotation;

    void Start()
    {
        zAxis = Random.Range(90, 180);
        xAxis = Random.Range(45, 90);
        targetRotation = transform.rotation;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, (targetRotation *= Quaternion.AngleAxis(60, Vector3.down)), 10 * 2 * Time.deltaTime);
            //Quaternion.Euler(xAxis * Time.deltaTime + transform.rotation.eulerAngles.x, 0, zAxis * Time.deltaTime + transform.rotation.eulerAngles.z);
    }
}