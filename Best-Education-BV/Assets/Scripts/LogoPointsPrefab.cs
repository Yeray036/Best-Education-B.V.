using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoPointsPrefab : MonoBehaviour
{
	//this script will add 1 health to healthBar if player collides with prefab and also updates users score.
    public AudioSource pointHitAudio;
    private Transform sH;
    private Slider healthBar;

    private void Start()
    {
        sH = GameObject.FindWithTag("SpaceShuttle").gameObject.transform;
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
    }

    private void Update()
    {
        gameObject.transform.Rotate(Vector3.left * (25 * Time.deltaTime));
        gameObject.transform.position += Vector3.down * 5 * Time.deltaTime;
        if ((gameObject.transform.position.y + 50) < sH.position.y)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpaceShuttle")
        {
            pointHitAudio.Play();
            if (GameObject.Find("HealthBar").GetComponent<Slider>().value < 100)
            {
                healthBar.value++;
            }
            PlayerData currentPlayer = SaveSystem.LoadPlayer();

            Player newPlayer = new Player();
            newPlayer.username = currentPlayer.username;
            newPlayer.email = currentPlayer.email;
            newPlayer.score = currentPlayer.score + 1;
            SaveSystem.SavePlayer(newPlayer);

            GameObject.Find("PlayerScoreText").GetComponent<Text>().text = "Score: " + newPlayer.score;
            Destroy(this.gameObject, pointHitAudio.clip.length);
        }
    }
}
