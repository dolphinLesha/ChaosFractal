using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goToDirectoryOpen : MonoBehaviour {

    string dir;
	
	void Start () {
        dir = this.GetComponentInChildren<Text>().text;
	}
	
    public void goToDir()
    {
        GameObject.Find("script").SendMessage("iGetPictures", dir);
    }
	
	void Update () {
		
	}
}
