using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseFunction : MonoBehaviour {

	
	void Start () {
		
	}
	
    public void chosen()
    {
        GameObject.Find("script").SendMessage("functionChoose", int.Parse(this.name));
    }
	
	void Update () {
		
	}
}
