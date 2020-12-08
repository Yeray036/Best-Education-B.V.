using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticleHandler : MonoBehaviour
{

    public GameObject spaceShuttle;
    public GameObject[] articles;
    public GameObject questionFive;
    public GameObject questionSix;
    public GameObject questionSeven;
    public GameObject questionEight;
    public GameObject questionNine;
    public GameObject questionTen;

    // Start is called before the first frame update
    void Start()
    {
        spaceShuttle = GameObject.FindWithTag("SpaceShuttle").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == spaceShuttle.tag)
        {
            GameObject.FindWithTag("SpaceShuttle").GetComponent<SpaceShuttleController>().rocketSound.volume = 0.0f;
            if (SpaceShuttleController.articleCounter != 3 && SpaceShuttleController.articleCounter != 6 && SpaceShuttleController.articleCounter != 9 && SpaceShuttleController.articleCounter != 10 && SpaceShuttleController.articleCounter != 11 && SpaceShuttleController.articleCounter != 12)
            {
                Instantiate(articles[SpaceShuttleController.articleCounter]);
                GameObject.Find($"Article{SpaceShuttleController.articleCounter}(Clone)").transform.SetParent(GameObject.Find("Canvas").transform);
                GameObject.Find($"Article{SpaceShuttleController.articleCounter}(Clone)").transform.localPosition = new Vector3(0, 73, 1);
                GameObject.Find($"Article{SpaceShuttleController.articleCounter}(Clone)").transform.localScale = new Vector3(1, 1, 1);
            }
            Time.timeScale = 0;
            switch (SpaceShuttleController.articleCounter)
            {
                case 0:
                    GameObject.Find("ArticleOneCollider").GetComponent<BoxCollider>().isTrigger = false;
                    BorderControl.articleColliders.Add(GameObject.Find("ArticleOneCollider").GetComponent<BoxCollider>());
                    break;
                case 1:
                    GameObject.Find("ArticleTwoCollider").GetComponent<BoxCollider>().isTrigger = false;
                    BorderControl.articleColliders.Add(GameObject.Find("ArticleTwoCollider").GetComponent<BoxCollider>());
                    break;
                case 2:
                    GameObject.Find("ArticleThreeCollider").GetComponent<BoxCollider>().isTrigger = false;
                    BorderControl.articleColliders.Add(GameObject.Find("ArticleThreeCollider").GetComponent<BoxCollider>());
                    break;
                case 3:
                    if (GameObject.Find("ArticleQuestion1Collider").GetComponent<BoxCollider>().isTrigger != false)
                    {
                        GameObject.Find("ArticleQuestion1Collider").GetComponent<BoxCollider>().isTrigger = false;
                        BorderControl.articleColliders.Add(GameObject.Find("ArticleQuestion1Collider").GetComponent<BoxCollider>());
                        Instantiate(questionFive);
                        GameObject.Find("Question5(Clone)").transform.SetParent(GameObject.FindWithTag("Canvas").transform);
                        GameObject.Find("Question5(Clone)").transform.localPosition = new Vector3(228.7014f, -398.6075f, 1);
                        GameObject.Find("Question5(Clone)").transform.localScale = new Vector3(1.70347f, 1.70347f, 1.70347f);
                        SpaceShuttleController.articleCounter--;
                        break;
                    }
                    else
                    {
                        Instantiate(articles[SpaceShuttleController.articleCounter]);
                        GameObject.Find($"Article{SpaceShuttleController.articleCounter}(Clone)").transform.SetParent(GameObject.Find("Canvas").transform);
                        GameObject.Find($"Article{SpaceShuttleController.articleCounter}(Clone)").transform.localPosition = new Vector3(0, 73, 1);
                        GameObject.Find($"Article{SpaceShuttleController.articleCounter}(Clone)").transform.localScale = new Vector3(1, 1, 1);
                        break;
                    }
                case 4:
                    GameObject.Find("ArticleFourCollider").GetComponent<BoxCollider>().isTrigger = false;
                    BorderControl.articleColliders.Add(GameObject.Find("ArticleFourCollider").GetComponent<BoxCollider>());
                    break;
                case 5:
                    GameObject.Find("ArticleFiveCollider").GetComponent<BoxCollider>().isTrigger = false;
                    BorderControl.articleColliders.Add(GameObject.Find("ArticleFiveCollider").GetComponent<BoxCollider>());
                    break;
                case 6:
                    if (GameObject.Find("ArticleQuestion2Collider").GetComponent<BoxCollider>().isTrigger != false)
                    {
                        GameObject.Find("ArticleSixCollider").GetComponent<BoxCollider>().isTrigger = false;
                        BorderControl.articleColliders.Add(GameObject.Find("ArticleSixCollider").GetComponent<BoxCollider>());
                        Instantiate(questionSix);
                        GameObject.Find("Question6(Clone)").transform.SetParent(GameObject.FindWithTag("Canvas").transform);
                        GameObject.Find("Question6(Clone)").transform.localPosition = new Vector3(228.7014f, -398.6075f, 1);
                        GameObject.Find("Question6(Clone)").transform.localScale = new Vector3(1.70347f, 1.70347f, 1.70347f);
                        SpaceShuttleController.articleCounter--;
                        break;
                    }
                    else
                    {
                        Instantiate(articles[SpaceShuttleController.articleCounter]);
                        GameObject.Find($"Article{SpaceShuttleController.articleCounter}(Clone)").transform.SetParent(GameObject.Find("Canvas").transform);
                        GameObject.Find($"Article{SpaceShuttleController.articleCounter}(Clone)").transform.localPosition = new Vector3(0, 73, 1);
                        GameObject.Find($"Article{SpaceShuttleController.articleCounter}(Clone)").transform.localScale = new Vector3(1, 1, 1);
                        break;
                    }
                case 7:
                    GameObject.Find("ArticleSevenCollider").GetComponent<BoxCollider>().isTrigger = false;
                    BorderControl.articleColliders.Add(GameObject.Find("ArticleSevenCollider").GetComponent<BoxCollider>());
                    break;
                case 8:
                    GameObject.Find("ArticleEightCollider").GetComponent<BoxCollider>().isTrigger = false;
                    BorderControl.articleColliders.Add(GameObject.Find("ArticleEightCollider").GetComponent<BoxCollider>());
                    break;
                case 9:
                    if (GameObject.Find("ArticleQuestion3Collider").GetComponent<BoxCollider>().isTrigger != false)
                    {
                        GameObject.Find("ArticleQuestion3Collider").GetComponent<BoxCollider>().isTrigger = false;
                        BorderControl.articleColliders.Add(GameObject.Find("ArticleQuestion3Collider").GetComponent<BoxCollider>());
                        Instantiate(questionSeven);
                        GameObject.Find("Question7(Clone)").transform.SetParent(GameObject.FindWithTag("Canvas").transform);
                        GameObject.Find("Question7(Clone)").transform.localPosition = new Vector3(228.7014f, -398.6075f, 1);
                        GameObject.Find("Question7(Clone)").transform.localScale = new Vector3(1.70347f, 1.70347f, 1.70347f);
                        SpaceShuttleController.articleCounter--;
                        break;
                    }
                    else
                    {
                        Instantiate(articles[SpaceShuttleController.articleCounter]);
                        GameObject.Find($"Article10(Clone)").transform.SetParent(GameObject.Find("Canvas").transform);
                        GameObject.Find($"Article10(Clone)").transform.localPosition = new Vector3(0, 73, 1);
                        GameObject.Find($"Article10(Clone)").transform.localScale = new Vector3(1, 1, 1);
                        GameObject.Find("ArticleTenCollider").GetComponent<BoxCollider>().isTrigger = false;
                        BorderControl.articleColliders.Add(GameObject.Find("ArticleTenCollider").GetComponent<BoxCollider>());
                        break;
                    }
                case 10:
                    if (GameObject.Find("ArticleQuestion4Collider").GetComponent<BoxCollider>().isTrigger != false)
                    {
                        GameObject.Find("ArticleQuestion4Collider").GetComponent<BoxCollider>().isTrigger = false;
                        BorderControl.articleColliders.Add(GameObject.Find("ArticleQuestion4Collider").GetComponent<BoxCollider>());
                        Instantiate(questionEight);
                        GameObject.Find("Question8(Clone)").transform.SetParent(GameObject.FindWithTag("Canvas").transform);
                        GameObject.Find("Question8(Clone)").transform.localPosition = new Vector3(228.7014f, -398.6075f, 1);
                        GameObject.Find("Question8(Clone)").transform.localScale = new Vector3(1.70347f, 1.70347f, 1.70347f);
                        SpaceShuttleController.articleCounter--;
                        break;
                    }
                    else
                    {
                        Instantiate(articles[SpaceShuttleController.articleCounter]);
                        GameObject.Find($"Article11(Clone)").transform.SetParent(GameObject.Find("Canvas").transform);
                        GameObject.Find($"Article11(Clone)").transform.localPosition = new Vector3(0, 73, 1);
                        GameObject.Find($"Article11(Clone)").transform.localScale = new Vector3(1, 1, 1);
                        GameObject.Find("ArticleElevenCollider").GetComponent<BoxCollider>().isTrigger = false;
                        BorderControl.articleColliders.Add(GameObject.Find("ArticleElevenCollider").GetComponent<BoxCollider>());
                        break;
                    }
                case 11:
                    if (GameObject.Find("ArticleQuestion5Collider").GetComponent<BoxCollider>().isTrigger != false)
                    {
                        GameObject.Find("ArticleQuestion5Collider").GetComponent<BoxCollider>().isTrigger = false;
                        BorderControl.articleColliders.Add(GameObject.Find("ArticleQuestion5Collider").GetComponent<BoxCollider>());
                        Instantiate(questionNine);
                        GameObject.Find("Question9(Clone)").transform.SetParent(GameObject.FindWithTag("Canvas").transform);
                        GameObject.Find("Question9(Clone)").transform.localPosition = new Vector3(228.7014f, -398.6075f, 1);
                        GameObject.Find("Question9(Clone)").transform.localScale = new Vector3(1.70347f, 1.70347f, 1.70347f);
                        SpaceShuttleController.articleCounter--;
                        break;
                    }
                    else
                    {
                        Instantiate(articles[SpaceShuttleController.articleCounter]);
                        GameObject.Find($"Article12(Clone)").transform.SetParent(GameObject.Find("Canvas").transform);
                        GameObject.Find($"Article12(Clone)").transform.localPosition = new Vector3(0, 73, 1);
                        GameObject.Find($"Article12(Clone)").transform.localScale = new Vector3(1, 1, 1);
                        GameObject.Find("ArticleTwelveCollider").GetComponent<BoxCollider>().isTrigger = false;
                        BorderControl.articleColliders.Add(GameObject.Find("ArticleTwelveCollider").GetComponent<BoxCollider>());
                        break;
                    }
                case 12:
                    GameObject.Find("ArticleQuestion6Collider").GetComponent<BoxCollider>().isTrigger = false;
                    BorderControl.articleColliders.Add(GameObject.Find("ArticleQuestion6Collider").GetComponent<BoxCollider>());
                    Instantiate(questionTen);
                    GameObject.Find("Question10(Clone)").transform.SetParent(GameObject.FindWithTag("Canvas").transform);
                    GameObject.Find("Question10(Clone)").transform.localPosition = new Vector3(228.7014f, -398.6075f, 1);
                    GameObject.Find("Question10(Clone)").transform.localScale = new Vector3(1.70347f, 1.70347f, 1.70347f);
                    SpaceShuttleController.articleCounter--;
                    break;
                default:
                    break;
            }
            SpaceShuttleController.articleCounter++;
            Debug.Log("Current Article count = " + SpaceShuttleController.articleCounter);
            GameObject.FindWithTag("SpaceShuttle").GetComponent<SpaceShuttleController>().rocketSound.volume = 0.6f;
        }
    }

    public void CloseArticle()
    {
        if (GameObject.Find($"Article10(Clone)"))
        {
            Destroy(GameObject.Find($"Article10(Clone)"));
        }
        if (GameObject.Find($"Article11(Clone)"))
        {
            Destroy(GameObject.Find($"Article11(Clone)"));
        }
        if (GameObject.Find($"Article12(Clone)"))
        {
            Destroy(GameObject.Find($"Article12(Clone)"));
        }
        Destroy(gameObject);
        Destroy(GameObject.Find($"Article{SpaceShuttleController.articleDestroy}(Clone)"));
        Time.timeScale = 1;
        SpaceShuttleController.articleDestroy++;
    }
}
