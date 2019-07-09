using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text DisplayTime;
    public Text LUR;
    public static float chosenTime;
    public static bool loseUponRed;

    // Use this for initialization
    void Start () {
        chosenTime = 60;
        DisplayTime = GameObject.Find("TimerText").GetComponent<Text>();
        loseUponRed = true;
    }
	
	// Update is called once per frame
	void Update () {
        DisplayTime.text = chosenTime.ToString();
	}

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("scene1");
    }

    public void ClearHS(int value)
    {
        GameObject dialogue = GameObject.Find("AreYouSure");
        //0 = open GUI. 1 = Close GUI. 2 = Del High Scores
        switch (value)
        {
            case 0:
                dialogue.transform.localScale = new Vector3(1, 1, 1);
                break;
            case 1:
                dialogue.transform.localScale = new Vector3(0, 0, 0);
                break;
            case 2:
                dialogue.transform.localScale = new Vector3(0, 0, 0);
                PlayerPrefs.DeleteAll();
                break;
        }
    }

    public void IncreaseTime()
    {
        if (chosenTime < 300 && chosenTime != 30)
        {
            chosenTime = chosenTime + 60;
        } else
        if (chosenTime == 30)
        {
            chosenTime = chosenTime + 30;
        } else
        {
            return;
        }
    }

    public void DecreaseTime()
    {
        if (chosenTime > 60)
        {
            chosenTime = chosenTime - 60;
        } else
        if (chosenTime == 60)
        {
            chosenTime = chosenTime - 30;
        } else
        {
            return;
        }
    }

    public void LoseUponRed()
    {
        if (loseUponRed == true)
        {
            loseUponRed = false;
        } else 
        if (loseUponRed == false)
        {
            loseUponRed = true;
        }
    }
}
