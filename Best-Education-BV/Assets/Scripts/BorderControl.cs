using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderControl : MonoBehaviour
{
	
	//this script is attached to the invisible borders on the left and right side.
	//it will make sure the player stays within the x limit of the game this due to the article and question colliders.
	//if player gets out of it, it will tell the player in the middle of the screen that the user "player" has 5 seconds to get back with an arrow pointed.
	//if the player fails to do so it will reset the players position and artcile & question colliders. this because the player needs to learn things.
    public static GameObject spaceShuttleCharacter { get; set; }

    public static Vector3 initialPos { get; set; }

    public static bool restrictedArea { get; set; }

    public static List<BoxCollider> articleColliders { get; set; }

    private string borderCollision, currentBorder;

    private void Start()
    {
        spaceShuttleCharacter = GameObject.FindWithTag("SpaceShuttle").gameObject;
        initialPos = spaceShuttleCharacter.GetComponent<Transform>().position;
        restrictedArea = false;
        articleColliders = new List<BoxCollider>();
    }

    IEnumerator ResetPos()
    {
        GameObject.Find("CountdownText").GetComponent<Text>().text = $"You got 5 seconds to get back inside {borderCollision}";
        yield return new WaitForSeconds(1);
        GameObject.Find("CountdownText").GetComponent<Text>().text = $"You got 4 seconds to get back inside {borderCollision}";
        yield return new WaitForSeconds(1);
        GameObject.Find("CountdownText").GetComponent<Text>().text = $"You got 3 seconds to get back inside {borderCollision}";
        yield return new WaitForSeconds(1);
        GameObject.Find("CountdownText").GetComponent<Text>().text = $"You got 2 seconds to get back inside {borderCollision}";
        yield return new WaitForSeconds(1);
        GameObject.Find("CountdownText").GetComponent<Text>().text = $"You got 1 seconds to get back inside {borderCollision}";
        yield return new WaitForSeconds(1);
        GameObject.Find("CountdownText").GetComponent<Text>().text = $"You got 0 seconds to get back inside {borderCollision}";

        spaceShuttleCharacter.GetComponent<Transform>().position = initialPos;
        foreach (BoxCollider articleCollider in articleColliders)
        {
            articleCollider.isTrigger = true;
        }
        SpaceShuttleController.articleCounter = 0;
        SpaceShuttleController.articleDestroy = 0;
        ActivateAsteroidsCollider.ActivateAsteroidSpawner = false;
        restrictedArea = false;
        QA.activateSpaceShuttle = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentBorder = this.gameObject.tag;
        if (other.gameObject.tag == "SpaceShuttle")
        {
            restrictedArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SpaceShuttle")
        {
            restrictedArea = false;
            GameObject.Find("CountdownText").GetComponent<Text>().text = $"";
            borderCollision = "";
            currentBorder = "";
        }
    }

    private void Update()
    {
        if (restrictedArea == true)
        {
            if (currentBorder == "RightBorder")
            {
                borderCollision = "";
                borderCollision = "<==";
            }
            else
            {
                borderCollision = "";
                borderCollision = "==>";
            }
            StartCoroutine(ResetPos());
        }
        else
        {
            StopAllCoroutines();
        }
    }
}
