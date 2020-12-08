using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QA : MonoBehaviour
{
    public static string answer { get; set; }
    public static bool correctAnswer { get; set; }

    public static bool activateSpaceShuttle { get; set; }

    public Text wrongAnswer;

    public GameObject countDown;

    public GameObject[] questions;

    public Animator cameraMovements;
    public Animator astroMovement;

    private InputField fuelSwitches;
    private InputField trueText;
    private InputField falseText;

    private InputField threeText, zeroText, iText, functionOutput, modulesOutput;

    public AudioSource fuelLineAndThrustersEnabled, countdownLiftoff, wrongAnswerAudio, correctAnswerAudio;

    public void Start()
    {
        activateSpaceShuttle = false;
    }

    private void Update()
    {
        if (GameObject.Find("Question2(Clone)"))
        {
            GameObject.Find("Question2(Clone)").transform.SetParent(GameObject.FindWithTag("Canvas").transform);
            GameObject.Find("Question2(Clone)").transform.localPosition = new Vector3(228.7014f, -398.6075f, 1);
            GameObject.Find("Question2(Clone)").transform.localScale = new Vector3(1.70347f, 1.70347f, 1.70347f);
        }
        cameraMovements = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        astroMovement = GameObject.FindWithTag("Player").GetComponent<Animator>();
        if (correctAnswer == true)
        {
            if (GameObject.Find("Question2(Clone)"))
            {
                Destroy(GameObject.Find("Question2(Clone)"));
            }
            StartCoroutine(EnableQuestionThree());
        }
        if (GameObject.Find("Question3(Clone)"))
        {
            fuelSwitches = GameObject.Find("Switches").GetComponent<InputField>();
            trueText = GameObject.Find("True").GetComponent<InputField>();
            falseText = GameObject.Find("False").GetComponent<InputField>();
        }
        if (GameObject.Find("Question4(Clone)"))
        {
            threeText = GameObject.Find("ThreeText").GetComponent<InputField>();
            zeroText = GameObject.Find("ZeroText").GetComponent<InputField>();
            iText = GameObject.Find("iText").GetComponent<InputField>();
        }
        if (GameObject.Find("Question7(Clone)"))
        {
            functionOutput = GameObject.Find("FunctionOutput").GetComponent<InputField>();
        }
        if (GameObject.Find("Question8(Clone)"))
        {
            modulesOutput = GameObject.Find("ModuleOutput").GetComponent<InputField>();
        }
    }
    public void GetAnswer()
    {
        switch (gameObject.name)
        {
            case "A":
                answer = "A";
                break;
            case "B":
                answer = "B";
                break;
            case "C":
                answer = "C";
                break;
            case "D":
                answer = "D";
                break;
            case "E":
                answer = "E";
                break;
            default:
                break;
        }
    }

    public void QuestionOne()
    {
        switch (answer)
        {
            case "A":
                wrongAnswer.text = "The type always starts with a, lowercase.";
                wrongAnswerAudio.Play();
                break;
            case "B":
                wrongAnswer.text = "An array uses: [].";
                wrongAnswerAudio.Play();
                break;
            case "C":
                wrongAnswer.text = "Look closely to the type.";
                wrongAnswerAudio.Play();
                break;
            case "D":
                StartCoroutine(Question1());
                break;
            default:
                wrongAnswer.text = "No answer selected.";
                wrongAnswerAudio.Play();
                break;
        }
    }
    public void QuestionTwo()
    {
        switch (answer)
        {
            case "A":
                wrongAnswer.text = "So I want to go to level 26 and you choose 27??";
                wrongAnswerAudio.Play();
                break;
            case "B":
                wrongAnswer.text = "0 is not nothing for a computer...";
                wrongAnswerAudio.Play();
                break;
            case "C":
                correctAnswerAudio.Play();
                GameObject.Find("Fire_A").transform.localPosition = new Vector3(0, -5, 0);
                GameObject.Find("Fire_A (1)").transform.localPosition = new Vector3(0, -5, 0);
                GameObject.Find("Fire_A (2)").transform.localPosition = new Vector3(0, -5, 0);
                StartCoroutine(WaitForAnim());
                break;
            default:
                wrongAnswer.text = "No answer selected.";
                wrongAnswerAudio.Play();
                break;
        }
    }

    public void QuestionThree()
    {
        if (fuelSwitches.text == "8" && trueText.text == "true" && falseText.text == "false")
        {
            GameObject.Find("Fire_A").transform.localPosition = new Vector3(-0.071f, -1.064f, 0.043f);
            GameObject.Find("Fire_A (1)").transform.localPosition = new Vector3(0.087f, -1.064f, 0.043f);
            GameObject.Find("Fire_A (2)").transform.localPosition = new Vector3(-0.002f, -1.064f, -0.141f);
            if (GameObject.FindGameObjectWithTag("MusicPlayer"))
            {
                GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>().volume = 0.15f;
            }
            fuelLineAndThrustersEnabled.Play();
            StartCoroutine(WaitOnThrusters());
        }
        if (fuelSwitches.text != "8")
        {
            wrongAnswer.text = "Are you sure that all switches are on?";
            wrongAnswerAudio.Play();
        }
        if (trueText.text != "true")
        {
            wrongAnswer.text = "Huston we need fuel!";
            wrongAnswerAudio.Play();
        }
        if (falseText.text != "false")
        {
            wrongAnswer.text = "We can't enable the fuel, check the system!";
            wrongAnswerAudio.Play();
        }
    }

    public void QuestionFour()
    {
        if (threeText.text == "3" && zeroText.text == "0" && iText.text == "i")
        {
            if (GameObject.FindGameObjectWithTag("MusicPlayer"))
            {
                GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>().volume = 0.15f;
            }
            countdownLiftoff.Play();
            GameObject.Find("Question4(Clone)").transform.localPosition = new Vector3(-5000, -5000, 0);
            Instantiate(countDown);
            GameObject.Find("CountdownPanel(Clone)").transform.SetParent(GameObject.FindWithTag("Canvas").transform);
            GameObject.Find("CountdownPanel(Clone)").transform.localPosition = new Vector3(228.7014f, -398.6075f, 1);
            GameObject.Find("CountdownPanel(Clone)").transform.localScale = new Vector3(1.70347f, 1.70347f, 1.70347f);
            StartCoroutine(Countdown());
        }
        if (threeText.text != "3")
        {
            wrongAnswer.text = "The countdown starts from..?";
            wrongAnswerAudio.Play();
        }
        if (zeroText.text != "0")
        {
            wrongAnswer.text = "The countdown ends at..?";
            wrongAnswerAudio.Play();
        }
        if (iText.text != "i")
        {
            wrongAnswer.text = "How do we know, what the current countdown numbers is..?";
            wrongAnswerAudio.Play();
        }
    }

    public void QuestionFive()
    {
        switch (answer)
        {
            case "A":
                wrongAnswer.text = "Is numeric not a type?";
                wrongAnswerAudio.Play();
                break;
            case "B":
                wrongAnswer.text = "I don't think that numeric is a section..";
                wrongAnswerAudio.Play();
                break;
            case "C":
                wrongAnswer.text = "2 sections?? I thought there were more..";
                wrongAnswerAudio.Play();
                break;
            case "D":
                wrongAnswer.text = "Correct answer.";
                StartCoroutine(Question5());
                break;
            case "E":
                wrongAnswer.text = "I think four sections are a little bit to much.";
                wrongAnswerAudio.Play();
                break;
            default:
                wrongAnswer.text = "No answer selected.";
                wrongAnswerAudio.Play();
                break;
        }
    }

    public void QuestionSix()
    {
        switch (answer)
        {
            case "A":
                wrongAnswer.text = "Do spaces count as characters?";
                wrongAnswerAudio.Play();
                break;
            case "B":
                wrongAnswer.text = "i think your missing something...";
                wrongAnswerAudio.Play();
                break;
            case "C":
                wrongAnswer.text = "Correct answer";
                StartCoroutine(Question6());
                break;
            default:
                wrongAnswer.text = "No answer selected.";
                wrongAnswerAudio.Play();
                break;
        }
    }

    public void QuestionSeven()
    {
        if (functionOutput.text == "Pilot")
        {
            wrongAnswer.text = "Correct answer.";
            StartCoroutine(Question7());
        }
        else if (functionOutput.text == "pilot")
        {
            wrongAnswer.text = "We're going UP right?";
            wrongAnswerAudio.Play();
        }
        else
        {
            wrongAnswer.text = "Look carefully.";
            wrongAnswerAudio.Play();
        }
    }

    public void QuestionEight()
    {
        if (modulesOutput.text == "Modules")
        {
            wrongAnswer.text = "Correct answer.";
            StartCoroutine(Question8());
        }
        else if (modulesOutput.text == "modules")
        {
            wrongAnswer.text = "A string needs to be equal";
            wrongAnswerAudio.Play();
        }
        else
        {
            wrongAnswer.text = "That's a F";
            wrongAnswerAudio.Play();
        }
    }

    public void QuestionNine()
    {
        switch (answer)
        {
            case "A":
                wrongAnswer.text = "1?? Are you okay?";
                wrongAnswerAudio.Play();
                break;
            case "B":
                wrongAnswer.text = "You didn't even try :(";
                wrongAnswerAudio.Play();
                break;
            case "C":
                StartCoroutine(Question9());
                break;
            case "D":
                wrongAnswer.text = "It's not a .66 caliber ಥ_ಥ";
                wrongAnswerAudio.Play();
                break;
            default:
                wrongAnswer.text = "No answer selected.";
                wrongAnswerAudio.Play();
                break;
        }
    }

    public void QuestionTen()
    {
        switch (answer)
        {
            case "A":
                wrongAnswer.text = "We have a X and Y";
                wrongAnswerAudio.Play();
                break;
            case "B":
                wrongAnswer.text = "Correct answer!!";
                StartCoroutine(Question10());
                break;
            default:
                wrongAnswer.text = "No answer selected.";
                wrongAnswerAudio.Play();
                break;
        }
    }

    public IEnumerator WaitForAnim()
    {
        cameraMovements.Play("ElevatorAnim");
        astroMovement.Play("AstronautElevator");
        Instantiate(questions[2]);
        correctAnswer = true;
        yield return new WaitForSeconds(0.1f);
    }
    public IEnumerator EnableQuestionThree()
    {
        yield return new WaitForSeconds(10.1f);
        GameObject.Find("Question3(Clone)").transform.SetParent(GameObject.FindWithTag("Canvas").transform);
        GameObject.Find("Question3(Clone)").transform.localPosition = new Vector3(228.7014f, -398.6075f, 1);
        GameObject.Find("Question3(Clone)").transform.localScale = new Vector3(1.70347f, 1.70347f, 1.70347f);
        correctAnswer = false;
    }

    public IEnumerator WaitOnThrusters()
    {
        yield return new WaitForSeconds(4);
        Instantiate(questions[3]);
        Destroy(GameObject.Find("Question3(Clone)"), correctAnswerAudio.clip.length);
        GameObject.Find("Question4(Clone)").transform.SetParent(GameObject.FindWithTag("Canvas").transform);
        GameObject.Find("Question4(Clone)").transform.localPosition = new Vector3(228.7014f, -398.6075f, 1);
        GameObject.Find("Question4(Clone)").transform.localScale = new Vector3(1.70347f, 1.70347f, 1.70347f);
        GameObject.FindWithTag("SpaceShuttle").GetComponent<SpaceShuttleController>().rocketSound.Play();
        GameObject.FindWithTag("SpaceShuttle").GetComponent<SpaceShuttleController>().rocketSound.volume = 0.16f;
        if (GameObject.FindGameObjectWithTag("MusicPlayer"))
        {
            GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>().volume = 1f;
        }
    }

    public IEnumerator Countdown()
    {
        GameObject.Find("CountdownPanel(Clone)").GetComponent<Transform>().localPosition = Vector3.zero;
        yield return new WaitForSeconds(3.55f);
        for (int i = 3; i >= 0; i--)
        {
            GameObject.Find("CountdownText").GetComponent<Text>().text = $"{i}";
            yield return new WaitForSeconds(1);
        }
        GameObject.Find("CountdownText").GetComponent<Text>().fontSize = 110;
        GameObject.Find("CountdownText").GetComponent<Text>().text = $"Control the space shuttle with arrow keys or WASD";
        yield return new WaitForSeconds(5);
        GameObject.Find("CountdownText").GetComponent<Text>().text = $"";
        GameObject.FindWithTag("MainCamera").GetComponent<Animator>().enabled = false;
        activateSpaceShuttle = true;
        if (GameObject.FindGameObjectWithTag("MusicPlayer"))
        {
            GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>().volume = 1f;
        }
        GameObject.FindWithTag("SpaceShuttle").GetComponent<SpaceShuttleController>().rocketSound.volume = 0.65f;
    }

    IEnumerator Question1()
    {
        correctAnswerAudio.Play();
        wrongAnswer.text = "Correct answer, array uses [] and a lowercase as type.";
        yield return new WaitForSeconds(0.4f);
        Destroy(GameObject.Find("Question1"));
        Instantiate(questions[1]);
    }

    IEnumerator Question5()
    {
        correctAnswerAudio.Play();
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.4f);
        Destroy(GameObject.Find("Question5(Clone)"));
        Destroy(GameObject.Find("Question4(Clone)"));
        activateSpaceShuttle = true;
    }

    IEnumerator Question6()
    {
        correctAnswerAudio.Play();
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.4f);
        Destroy(GameObject.Find("Question6(Clone)"));
        activateSpaceShuttle = true;
        GameObject.Find("ArticleQuestion2Collider").GetComponent<BoxCollider>().isTrigger = false;
        BorderControl.articleColliders.Add(GameObject.Find("ArticleQuestion2Collider").GetComponent<BoxCollider>());
    }

    IEnumerator Question7()
    {
        correctAnswerAudio.Play();
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.4f);
        activateSpaceShuttle = true;
        Destroy(GameObject.Find("Question7(Clone)"));
    }

    IEnumerator Question8()
    {
        correctAnswerAudio.Play();
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.4f);
        activateSpaceShuttle = true;
        Destroy(GameObject.Find("Question8(Clone)"));
    }

    IEnumerator Question9()
    {
        correctAnswerAudio.Play();
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.4f);
        activateSpaceShuttle = true;
        Destroy(GameObject.Find("Question9(Clone)"));
    }

    IEnumerator Question10()
    {
        correctAnswerAudio.Play();
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.4f);
        activateSpaceShuttle = true;
        Destroy(GameObject.Find("Question10(Clone)"));
    }
}
