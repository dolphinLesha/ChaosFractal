using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onOff : MonoBehaviour {
    public Slider slider;
    bool isOn=true;

	void Start () {
        if (isOn)
            slider.value = 0;
        else
            slider.value = 1;
	}
	
	public void changeValue()
    {
        isOn = !isOn;
        if (isOn)
            slider.value = 0;
        else
            slider.value = 1;
    }

	void Update () {
		
	}
}
