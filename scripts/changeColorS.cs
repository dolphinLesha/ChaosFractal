using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColorS : MonoBehaviour {

    public Slider redSl;
    public Slider greenSl;
    public Slider blueSl;
    public Image redHan, greenHan, blueHan;
    public Text redT, greenT, blueT;
    public Image colored;
    Color col;

    void Start () {
		
	}

    public void voidSetStartColor(Color colo)
    {
        redSl.value = colo.r;
        greenSl.value = colo.g;
        blueSl.value = colo.b;
        redHan.color = new Color(redSl.value, 0, 0);
        redT.color = new Color(1 - redSl.value, 1 - redSl.value, 1 - redSl.value);
        greenHan.color = new Color(0, greenSl.value, 0);
        greenT.color = new Color(1 - greenSl.value, 1 - greenSl.value, 1 - greenSl.value);
        blueHan.color = new Color(0, 0, blueSl.value);
        blueT.color = new Color(1 - blueSl.value, 1 - blueSl.value, 1 - blueSl.value);
        col = new Color(redSl.value, greenSl.value, blueSl.value);
        colored.color = col;
    }

    public void herach()
    {
        if(this.name=="redSl")
        {
            redHan.color = new Color(redSl.value, 0, 0);
            redT.color = new Color(1 - redSl.value, 1 - redSl.value, 1 - redSl.value);
        }
        if(this.name == "greenSl")
        {
            greenHan.color = new Color(0, greenSl.value, 0);
            greenT.color = new Color(1 - greenSl.value, 1 - greenSl.value, 1 - greenSl.value);
        }
        if (this.name == "blueSl")
        {
            blueHan.color = new Color(0,0, blueSl.value);
            blueT.color = new Color(1 - blueSl.value, 1 - blueSl.value, 1 - blueSl.value);
        }
        col = new Color(redSl.value, greenSl.value, blueSl.value); 
        colored.color = col;
    }

    public void apply()
    {
        // GameObject.Find("script").SendMessage("changeColoredP",col);
        print(col);
        GameObject.Find("script").SendMessage("applyChangedColor",col);
    }
	
	
}
