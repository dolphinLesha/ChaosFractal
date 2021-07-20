using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instructionMenuOpen : MonoBehaviour {

    bool isFirst = true;
    public Text inst1;

	void Start () {
		
	}
	
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.F1) && isFirst)
        {
            inst1.color = new Color(inst1.color.r, inst1.color.g, inst1.color.b, 0);
            isFirst = false;
        }
	}
}
