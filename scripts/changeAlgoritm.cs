using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeAlgoritm : MonoBehaviour {

    public Slider algoritm;
    public Text now;
    public Image isToPng;
    string[] names = { "slow", "normal", "fast" };

    void Start () {
		
	}
	
    public void setAlgo()
    {
        now.text = names[(int)algoritm.value];
        if(algoritm.value == 2)
        {
            isToPng.rectTransform.offsetMin = new Vector2(0, 0);
            isToPng.rectTransform.offsetMax = new Vector2(0, 0);
        }
        else
        {
            isToPng.rectTransform.offsetMin = new Vector2(10000, 10000);
            isToPng.rectTransform.offsetMax = new Vector2(10000, 10000);
        }
        GameObject.Find("script").SendMessage("changeAlgo", (int)algoritm.value);
    }
	
	void Update () {
		
	}
}
