using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    PlayerData currentPlayer { get; set; }
    public GameObject finishObj;
    public AudioSource lostSoundEffect;
    public GameObject[] fireWorks;

    private void OnTriggerEnter(Collider other)
    {
        currentPlayer = SaveSystem.LoadPlayer();
        if (other.tag == "SpaceShuttle")
        {
            if (currentPlayer.score >= 150)
            {
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
                Instantiate(finishObj);
                GameObject.Find($"{finishObj.name}(Clone)").transform.SetParent(GameObject.Find("Canvas").transform);
                GameObject.Find($"{finishObj.name}(Clone)").transform.localPosition = new Vector3(0, 73, 1);
                GameObject.Find($"{finishObj.name}(Clone)").transform.localScale = new Vector3(1, 1, 1);
                foreach (GameObject effect in fireWorks)
                {
                    effect.GetComponent<ParticleSystem>().Play();
                }
            }
            else
            {
                StartCoroutine(Failed());
            }
        }
    }

    public void RestartGame()
    {
        Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene(); UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    IEnumerator Failed()
    {
        lostSoundEffect.Play();
        GameObject.Find("CountdownText").GetComponent<Text>().text = "You lost, all points will be taken. and we will reset your position";
        yield return new WaitForSeconds(10);
        Player newPlayer = new Player();
        newPlayer.username = currentPlayer.username;
        newPlayer.email = currentPlayer.email;
        newPlayer.score = 0;
        SaveSystem.SavePlayer(newPlayer);
        Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene(); UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
    }

}
