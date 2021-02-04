using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAsteroids : MonoBehaviour
{
	//this script will instatiate the Asteroids at a random location on the X axis. and also falls down in a random speed.
	//the random speed is different between the 3 asteroids prefab, the higher range the smaller the asteroids wich means more speed down.
    public GameObject[] asteroids;
    public GameObject spaceShuttleBounds;
    public float spawnTimeDelay = 1;

    private float spaceShuttleY;
    private float xRangeLeft = -99f;
    private float xRangeRight = 110f;
    private float zRange = 1019.642f;
    private int randomAsteroid;

    private bool spawnPrefab;

    private void Start()
    {
        spawnPrefab = true;
    }

    private void Update()
    {
        randomAsteroid = Random.Range(0, 3);
        spaceShuttleY = spaceShuttleBounds.transform.position.y + 50;
        if (spawnPrefab == true)
        {
            StartCoroutine(ShouldSpawn());
        }
    }

    private void SpawnAsteroid()
    {
        if (ActivateAsteroidsCollider.ActivateAsteroidSpawner)
        {
            GameObject gameObject = Instantiate(asteroids[randomAsteroid], new Vector3(Random.Range(xRangeLeft, xRangeRight), spaceShuttleY, zRange), transform.rotation);
            if (randomAsteroid == 0)
            {
                gameObject.GetComponent<Asteroids>().randomSpeed = Random.Range(20, 25);
            }
            else if (randomAsteroid == 1)
            {
                gameObject.GetComponent<Asteroids>().randomSpeed = Random.Range(15, 20);
            }
            else
            {
                gameObject.GetComponent<Asteroids>().randomSpeed = Random.Range(10, 15);
            }
        }
    }

    IEnumerator ShouldSpawn()
    {
        SpawnAsteroid();
        spawnPrefab = false;
        yield return new WaitForSeconds(spawnTimeDelay);
        spawnPrefab = true;
    }

}
