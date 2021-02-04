using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoPoints : MonoBehaviour
{
	//this script will instatiate in asteroid spawn object this script is attached to the prefab.
	//it will give the user one point and also adds 1 health point if users health is bollow 100.
    public GameObject logoObjPoints;
    public GameObject spaceShuttleBounds;
    public float spawnTimeDelay = 60;

    private float spaceShuttleY;
    private float xRangeLeft = -99f;
    private float xRangeRight = 110f;
    private float zRange = 1019.642f;

    private bool spawnPrefab;
    private Transform sH;

    private void Start()
    {
        spawnPrefab = true;
        sH = GameObject.FindWithTag("SpaceShuttle").gameObject.transform;
    }

    private void Update()
    {
        spaceShuttleY = spaceShuttleBounds.transform.position.y + 50;
        sH = sH.gameObject.transform;
        if (spawnPrefab == true)
        {
            StartCoroutine(ShouldSpawn());
        }
    }

    private void SpawnPoint()
    {
        if (ActivateLogoPointsCollider.ActivateLogoPointSpawner)
        {
            Instantiate(logoObjPoints, new Vector3(Random.Range(xRangeLeft, xRangeRight), spaceShuttleY, zRange), Quaternion.Euler(132, 90, 90));
        }
    }

    IEnumerator ShouldSpawn()
    {
        SpawnPoint();
        spawnPrefab = false;
        yield return new WaitForSeconds(spawnTimeDelay);
        spawnPrefab = true;
    }
}
