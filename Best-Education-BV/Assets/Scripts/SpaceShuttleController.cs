using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShuttleController : MonoBehaviour
{
	//this script is attached to the spaceShuttle and is for controlling it as a player using WASD or Arrow keys by using getaxis method.
    public float upSpeed, leftRightSpeed;
    private float activeUpSpeed, activeHorizontalSpeed;

    public AudioSource rocketSound;

    public GameObject spaceShuttle;

    public Rigidbody rbSpace;

    public float moveVertical;

    public float moveHorizontal;

    public static int articleCounter { get; set; }
    public static int articleDestroy { get; set; }

    private PlayerData currentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rbSpace = GetComponent<Rigidbody>();
        articleCounter = 0;
        articleDestroy = 0;
        currentPlayer = SaveSystem.LoadPlayer();
        GameObject.Find("PlayerScoreText").GetComponent<Text>().text = "Score: " + currentPlayer.score;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");
        rbSpace.angularVelocity = Vector3.zero;
        if (QA.activateSpaceShuttle)
        {
            MoveSpaceShuttle();
        }
    }

    public void MoveSpaceShuttle()
    {
        activeUpSpeed = Mathf.Lerp(activeUpSpeed, moveVertical * upSpeed, 2.5f * Time.deltaTime);
        spaceShuttle.transform.Translate(transform.up * activeUpSpeed * Time.deltaTime);
        if (moveHorizontal >= 0.1f)
        {
            spaceShuttle.transform.Rotate(Vector3.back, Time.deltaTime * 45, 0);
        }
        else if (moveHorizontal <= -0.1f)
        {
            spaceShuttle.transform.Rotate(Vector3.forward, Time.deltaTime * 45, 0);
        }
    }
}
