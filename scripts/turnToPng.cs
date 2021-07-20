using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnToPng : MonoBehaviour {
    public Text textB;
    public Image imB;
    bool isAuto = false;
    Color stT, stI;

    void Start()
    {
        stT = textB.color;
        stI = imB.color;
    }

    public void turnAuto()
    {
        isAuto = !isAuto;
        GameObject.Find("script").SendMessage("changeToPng", isAuto);
        if (isAuto)
        {
            imB.color = new Color(0.6f, 0.85f, 0.6f, imB.color.a);
            textB.color = new Color(1, 1, 1, 1);
        }
        else
        {
            textB.color = stT;
            imB.color = stI;
        }
    }

   
}
