using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goToPictureOpen : MonoBehaviour {

    string picture;

	void Start () {
        picture = this.GetComponentInChildren<Text>().text;
	}
	
    public void chosenPicture()
    {
        GameObject.Find("script").SendMessage("iOpenPict", picture);
    }
	
	void Update () {
		
	}
}
