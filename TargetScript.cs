using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

    public string targType;
    public bool isEnabled;
    GameController gc;

	// Use this for initialization
	void Start () {
        targType = "null";
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (targType == "green")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(3).gameObject.SetActive(false);
            this.transform.GetChild(4).gameObject.SetActive(true);
            this.transform.GetChild(5).gameObject.SetActive(false);
        } else
        if (targType == "red")
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(true);
            this.transform.GetChild(3).gameObject.SetActive(true);
            this.transform.GetChild(4).gameObject.SetActive(false);
            this.transform.GetChild(5).gameObject.SetActive(true);
        } else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(3).gameObject.SetActive(false);
            this.transform.GetChild(4).gameObject.SetActive(false);
            this.transform.GetChild(5).gameObject.SetActive(false);
        }

        if (targType == "green")
        {
            if (name == "targ1")
            {
                gc.gt1 = true;
            }
            if (name == "targ2")
            {
                gc.gt2 = true;
            }
            if (name == "targ3")
            {
                gc.gt3 = true;
            }
            if (name == "targ4")
            {
                gc.gt4 = true;
            }
            if (name == "targ5")
            {
                gc.gt5 = true;
            }
            if (name == "targ6")
            {
                gc.gt6 = true;
            }
            if (name == "targ7")
            {
                gc.gt7 = true;
            }
            if (name == "targ8")
            {
                gc.gt8 = true;
            }
            if (name == "targ9")
            {
                gc.gt9 = true;
            }
        } else
        if (targType != "green")
        {
            if (name == "targ1")
            {
                gc.gt1 = false;
            }
            if (name == "targ2")
            {
                gc.gt2 = false;
            }
            if (name == "targ3")
            {
                gc.gt3 = false;
            }
            if (name == "targ4")
            {
                gc.gt4 = false;
            }
            if (name == "targ5")
            {
                gc.gt5 = false;
            }
            if (name == "targ6")
            {
                gc.gt6 = false;
            }
            if (name == "targ7")
            {
                gc.gt7 = false;
            }
            if (name == "targ8")
            {
                gc.gt8 = false;
            }
            if (name == "targ9")
            {
                gc.gt9 = false;
            }
        }
    }
}
