using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroids : MonoBehaviour
{
	//this script will instatie foreach asteroid on its own.
	//wich means that foreach asteroid the same methods will be activated but due to Random.range
	//we can give the X position for spawning random foreach asteroid.
	//aslo in this script it will handle the collision with the spaceshuttle it will start a impact sound and removes health from player.
    public float speed = 10.0f;
    private Rigidbody rb;
    private Vector3 screenBounds;
    public AudioSource asteroidImpact, gameOver;

    private Transform currentAsteroid;
    public float randomSpeed;

    private Transform sH;
    private PlayerData currentPlayer;
    private Player newPlayer;

    private Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        rb = this.GetComponent<Rigidbody>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        asteroidImpact.GetComponent<AudioSource>();
        gameOver.GetComponent<AudioSource>();
        currentAsteroid = this.gameObject.transform;
        sH = GameObject.FindWithTag("SpaceShuttle").gameObject.transform;
        currentPlayer = SaveSystem.LoadPlayer();
        newPlayer = new Player();
        newPlayer.username = currentPlayer.username;
        newPlayer.email = currentPlayer.email;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.left * (25 * Time.deltaTime));
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        sH = sH.gameObject.transform;
        if (GameObject.Find("HealthBar").GetComponent<Slider>().value == 0)
        {
            StartCoroutine(GameOver());
        }
        if ((gameObject.transform.position.y + 50) < sH.position.y)
        {
            Destroy(this.gameObject);
        }
        currentAsteroid.position += Vector3.down * randomSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SpaceShuttle")
        {
            StartCoroutine(AsteroidImpact());
        }
    }

    IEnumerator AsteroidImpact()
    {
        asteroidImpact.GetComponent<AudioSource>().Play();
        healthBar.value -= 5;
        newPlayer.score = currentPlayer.score - 1;
        SaveSystem.SavePlayer(newPlayer);
        GameObject.Find("PlayerScoreText").GetComponent<Text>().text = "Score: " + newPlayer.score;
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
    }

    IEnumerator GameOver()
    {
        gameOver.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.1f);
        ActivateAsteroidsCollider.ActivateAsteroidSpawner = false;
        BorderControl.spaceShuttleCharacter.GetComponent<Transform>().position = BorderControl.initialPos;
        foreach (BoxCollider articleCollider in BorderControl.articleColliders)
        {
            articleCollider.isTrigger = true;
        }
        SpaceShuttleController.articleCounter = 0;
        SpaceShuttleController.articleDestroy = 0;
        BorderControl.restrictedArea = false;
        GameObject.Find("HealthBar").GetComponent<Slider>().value = 100;
        yield return new WaitForSeconds(1f);
        QA.activateSpaceShuttle = true;
    }
}
