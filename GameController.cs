using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject greenTarg1;
    public GameObject greenTarg2;
    public GameObject greenTarg3;
    public GameObject greenTarg4;
    public GameObject greenTarg5;
    public GameObject greenTarg6;

    public bool gt1;
    public bool gt2;
    public bool gt3;
    public bool gt4;
    public bool gt5;
    public bool gt6;
    public bool gt7;
    public bool gt8;
    public bool gt9;

    public bool canInterract;
    public float timeRemaining;
    public int score; //player's score
    public static int highScore;
    public string highScoreTimeKey = MainMenu.chosenTime.ToString();
    public int level; //current set of dots to press
    public Text scoreString;
    public Text timeString;
    public GameObject greenChime;
    public GameObject redChime;
    public GameObject endScreen;
    GameObject mainCamera;
    List<GameObject> targList = new List<GameObject>();
    public List<int> PPList = new List<int>();
    RuntimePlatform platform = Application.platform;

    // Use this for initialization
    void Start () {
        mainCamera = GameObject.Find("Main Camera");
        canInterract = true;
        score = 0;
        timeRemaining = MainMenu.chosenTime;
        if (MainMenu.chosenTime == 30)
        {
            highScore = PlayerPrefs.GetInt("30");
        } else
        if (MainMenu.chosenTime == 60)
        {
            highScore = PlayerPrefs.GetInt("60");
        } else
        if (MainMenu.chosenTime == 120)
        {
            highScore = PlayerPrefs.GetInt("120");
        } else
        if (MainMenu.chosenTime == 180)
        {
            highScore = PlayerPrefs.GetInt("180");
        } else
        if (MainMenu.chosenTime == 240)
        {
            highScore = PlayerPrefs.GetInt("240");
        } else
        if (MainMenu.chosenTime == 300)
        {
            highScore = PlayerPrefs.GetInt("300");
        }
        level = 0;
        endScreen.transform.localScale = new Vector3(0, 0, 0);
        Time.timeScale = 1;
        Debug.Log(targList.Count);
        PPList.Add(0);
        LoadLevel(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (score < 0) score = 0;
        
        timeRemaining -= Time.deltaTime;
        timeString.text = "Time: " + timeRemaining.ToString("F2");
        scoreString.text = "Score: " + score;

        if(timeRemaining <= 0)
        {
            EndGame();
        }

        if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer && canInterract == true) //Note in editor, this will ALWAYS be false
        {
            if(Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    checkTouch(Input.GetTouch(0).position);
                }
            }
            if(Input.touchCount >= 2)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        checkTouch(Input.GetTouch(0).position);
                    }
                    if (Input.GetTouch(1).phase == TouchPhase.Began)
                    {
                        checkTouch(Input.GetTouch(1).position);
                    }
                }
            }
        } else
        if (platform == RuntimePlatform.WindowsEditor && canInterract == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                checkTouch(Input.mousePosition);
            }
        }

        if (gt1 == false && gt2 == false && gt3 == false && gt4 == false && gt5 == false && gt6 == false && gt7 == false && gt8 == false && gt9 == false)
        {
            LoadLevel(true);
        }
    }

    public void checkTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        Collider2D hit = Physics2D.OverlapPoint(touchPos);

        if (hit)
        {
            string targType = hit.GetComponent<TargetScript>().targType;
            Debug.Log(hit.transform.gameObject.name);
            if (targType == "green")
            {
                score = score + 5;
                hit.GetComponent<TargetScript>().targType = "null";
                greenChime.GetComponent<AudioSource>().Play();
                Instantiate(Resources.Load("TapEffect"), hit.transform);
            } else
            if (targType == "red")
            {
                if (MainMenu.loseUponRed == true)
                {
                    redChime.GetComponent<AudioSource>().Play();
                    EndGame();
                } else
                if (MainMenu.loseUponRed == false)
                {
                    score = 0;
                    redChime.GetComponent<AudioSource>().Play();
                    Instantiate(Resources.Load("RedEffect"), hit.transform);
                }
            }
        }
    }

    public void LoadLevel(bool increaseLevel)
    {
        if (increaseLevel == true)
        {
            Debug.Log("Increased Level");
            level++;
        } else
        if (increaseLevel == false)
        {
            return;
        }
        Debug.Log(level);
        foreach (GameObject target in GameObject.FindGameObjectsWithTag("Target"))
        {
            targList.Add(target);
        }
        string[] setColor = new string[] { "green", "red" };

        if (level > 0)
        {
            greenTarg1 = targList[Random.Range(0, targList.Count - 1)];
            greenTarg1.GetComponent<TargetScript>().targType = setColor[0];
            targList.Remove(greenTarg1);
        }
        if (level > 1)
        {
            GameObject redTarg = targList[Random.Range(0, targList.Count - 1)];
            redTarg.GetComponent<TargetScript>().targType = setColor[1];
            targList.Remove(redTarg);
        }
        if (level > 2)
        {
            greenTarg2 = targList[Random.Range(0, targList.Count - 1)];
            greenTarg2.GetComponent<TargetScript>().isEnabled = true;
            greenTarg2.GetComponent<TargetScript>().targType = setColor[0];
            targList.Remove(greenTarg2);
        }
        if (level > 3)
        {
            GameObject redTarg = targList[Random.Range(0, targList.Count - 1)];
            redTarg.GetComponent<TargetScript>().targType = setColor[1];
            targList.Remove(redTarg);
        }
        if (level > 4)
        {
            greenTarg3 = targList[Random.Range(0, targList.Count - 1)];
            greenTarg3.GetComponent<TargetScript>().isEnabled = true;
            greenTarg3.GetComponent<TargetScript>().targType = setColor[0];
            targList.Remove(greenTarg3);
        }
        if (level > 5)
        {
            GameObject redTarg = targList[Random.Range(0, targList.Count - 1)];
            redTarg.GetComponent<TargetScript>().targType = setColor[1];
            targList.Remove(redTarg);
        }
        if (level > 6)
        {
            greenTarg4 = targList[Random.Range(0, targList.Count - 1)];
            greenTarg4.GetComponent<TargetScript>().isEnabled = true;
            greenTarg4.GetComponent<TargetScript>().targType = setColor[0];
            targList.Remove(greenTarg4);
        }
        if (level > 7)
        {
            greenTarg5 = targList[Random.Range(0, targList.Count - 1)];
            greenTarg5.GetComponent<TargetScript>().isEnabled = true;
            greenTarg5.GetComponent<TargetScript>().targType = setColor[0];
            targList.Remove(greenTarg5);
        }
        if (level > 8)
        {
            greenTarg6 = targList[Random.Range(0, targList.Count - 1)];
            greenTarg6.GetComponent<TargetScript>().isEnabled = true;
            greenTarg6.GetComponent<TargetScript>().targType = setColor[0];
            targList.Remove(greenTarg6);
        }
    }

    public void RestartLevel()
    {
        Debug.Log("Restart");
        UnityEngine.SceneManagement.SceneManager.LoadScene("scene1");
    }

    public void GoToMM()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void EndGame()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt(MainMenu.chosenTime.ToString(), score);
            highScore = PlayerPrefs.GetInt(MainMenu.chosenTime.ToString());
        }

        highScore = PlayerPrefs.GetInt(MainMenu.chosenTime.ToString());

        foreach (GameObject target in GameObject.FindGameObjectsWithTag("Target"))
        {
            target.SetActive(false);
        }
        Time.timeScale = 0;
        canInterract = false;
        endScreen.transform.localScale = new Vector3(1, 1, 1);
        endScreen.transform.FindChild("FinalScore").GetComponent<Text>().text = score.ToString();
        endScreen.transform.FindChild("HSTitle").GetComponent<Text>().text = "High Score For " + MainMenu.chosenTime + " Seconds:";
        GameObject exitButton = GameObject.Find("Exit");
        exitButton.transform.localScale = new Vector3(0, 0, 0);

        if (PPList.Count > 0)
        {
            endScreen.transform.FindChild("HighScores").GetComponent<Text>().text = highScore.ToString();
        }
    }
}
