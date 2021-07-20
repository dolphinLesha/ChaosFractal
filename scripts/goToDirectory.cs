using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goToDirectory : MonoBehaviour {

    string dir;
	
	void Start () {
        dir = this.name;
	}
	public void goToDir()
    {
        GameObject.Find("script").SendMessage("getDir", dir);
    }
	
	void Update () {
		
	}
}
