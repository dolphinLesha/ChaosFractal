using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nameChange : MonoBehaviour {
    RectTransform trans;
    bool isTrans = true;
    bool isTransDir = true;
    float xPop = 0.85f;
    bool isFirst = true;
	
	void Start () {
        trans = this.GetComponent<RectTransform>();
	}
	
    public void getCh(bool isOk)
    {
        this.GetComponent<Text>().color = new Color(0, 0, 0, 0);
        isTrans = isOk;
        isFirst = isOk;
    }
	
	void Update () {
		if(isTrans)
        {
            if(isTransDir)
            {
                xPop = Mathf.MoveTowards(xPop, 1.15f, Time.deltaTime / 15f);
                if(xPop >= 1.15f)
                {
                    isTransDir = !isTransDir;
                }
            }
            else
            {
                xPop = Mathf.MoveTowards(xPop, 0.85f, Time.deltaTime / 15f);
                if (xPop == 0.85f)
                {
                    isTransDir = !isTransDir;
                }
            }
            this.GetComponent<Text>().color = new Color(xPop-0.25f, xPop - 0.25f, xPop - 0.25f, 1);
            trans.localScale =new Vector3(xPop,xPop,0);
        }
        
    }
}
