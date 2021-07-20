using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stepByStepAlg : MonoBehaviour {

    public GameObject punkt;
    public Text coords;
    public Image ccodx;
    public Canvas her2;
    public GameObject ccod;
    public Image mainP;
    float x, y;

	void Start () {
		
	}
	
    public void getCoordsSlow(Vector3 vec)
    {
        x = vec.x;
        y = vec.y;
        //print(vec);
        if (x < -Screen.width / her2.scaleFactor / 2 + ccodx.rectTransform.sizeDelta.x && y >= -Screen.height / her2.scaleFactor / 2 + punkt.GetComponent<RectTransform>().sizeDelta.y  && y <= Screen.height / her2.scaleFactor / 2 - punkt.GetComponent<RectTransform>().sizeDelta.y )
        {
            punkt.transform.localPosition = new Vector2(-Screen.width / her2.scaleFactor / 2 + ccodx.rectTransform.sizeDelta.x, y);
        }
        else if (x < -Screen.width / her2.scaleFactor / 2 + ccodx.rectTransform.sizeDelta.x  && y < -Screen.height / her2.scaleFactor / 2 + punkt.GetComponent<RectTransform>().sizeDelta.y )
        {
            punkt.transform.localPosition = new Vector2(-Screen.width / her2.scaleFactor / 2 + ccodx.rectTransform.sizeDelta.x, -Screen.height / her2.scaleFactor / 2 + punkt.GetComponent<RectTransform>().sizeDelta.y );
        }
        else if (x < -Screen.width / her2.scaleFactor / 2 + ccodx.rectTransform.sizeDelta.x && y > Screen.height / her2.scaleFactor / 2 - punkt.GetComponent<RectTransform>().sizeDelta.y )
        {
            punkt.transform.localPosition = new Vector2(-Screen.width / her2.scaleFactor / 2 + ccodx.rectTransform.sizeDelta.x, Screen.height / her2.scaleFactor / 2 - punkt.GetComponent<RectTransform>().sizeDelta.y);
        }
        else if (x > Screen.width / her2.scaleFactor / 2 - ccodx.rectTransform.sizeDelta.x  && y >= -Screen.height / her2.scaleFactor / 2 + punkt.GetComponent<RectTransform>().sizeDelta.y && y <= Screen.height / her2.scaleFactor / 2 - punkt.GetComponent<RectTransform>().sizeDelta.y )
        {
            punkt.transform.localPosition = new Vector2(Screen.width / her2.scaleFactor / 2 - ccodx.rectTransform.sizeDelta.x, y);
        }
        else if (x > Screen.width / her2.scaleFactor / 2 - ccodx.rectTransform.sizeDelta.x && y < -Screen.height / her2.scaleFactor / 2 + punkt.GetComponent<RectTransform>().sizeDelta.y)
        {
            punkt.transform.localPosition = new Vector2(Screen.width / her2.scaleFactor / 2 - ccodx.rectTransform.sizeDelta.x , -Screen.height / her2.scaleFactor / 2 + punkt.GetComponent<RectTransform>().sizeDelta.y);
        }
        else if (x > Screen.width / her2.scaleFactor / 2 - ccodx.rectTransform.sizeDelta.x  && y > Screen.height / her2.scaleFactor / 2 - punkt.GetComponent<RectTransform>().sizeDelta.y)
        {
            punkt.transform.localPosition = new Vector2(Screen.width / her2.scaleFactor / 2 - ccodx.rectTransform.sizeDelta.x , Screen.height / her2.scaleFactor / 2 - punkt.GetComponent<RectTransform>().sizeDelta.y);
        }
        else if (x <= Screen.width / her2.scaleFactor / 2 - ccodx.rectTransform.sizeDelta.x  && x >= -Screen.width / her2.scaleFactor / 2 + ccodx.rectTransform.sizeDelta.x && y >= -Screen.height / her2.scaleFactor / 2 + punkt.GetComponent<RectTransform>().sizeDelta.y && y <= Screen.height / her2.scaleFactor / 2 - punkt.GetComponent<RectTransform>().sizeDelta.y)
        {
            punkt.transform.localPosition = new Vector2(x, y);
        }
        else if (x <= Screen.width / her2.scaleFactor / 2 - ccodx.rectTransform.sizeDelta.x  && x >= -Screen.width / her2.scaleFactor / 2 + ccodx.rectTransform.sizeDelta.x && y < -Screen.height / her2.scaleFactor / 2 + punkt.GetComponent<RectTransform>().sizeDelta.y)
        {
            punkt.transform.localPosition = new Vector2(x, -Screen.height / her2.scaleFactor / 2 + punkt.GetComponent<RectTransform>().sizeDelta.y);
        }
        else if (x <= Screen.width / her2.scaleFactor / 2 - ccodx.rectTransform.sizeDelta.x && x >= -Screen.width / her2.scaleFactor / 2 + ccodx.rectTransform.sizeDelta.x && y > Screen.height / her2.scaleFactor / 2 - punkt.GetComponent<RectTransform>().sizeDelta.y)
        {
            punkt.transform.localPosition = new Vector2(x, Screen.height / her2.scaleFactor/2 - punkt.GetComponent<RectTransform>().sizeDelta.y);
        }
        coords.text = "x:" + ((int)x).ToString() + " | y:" + ((int)y).ToString();
    }

    public void theEnd()
    {
        punkt.transform.localPosition = new Vector2(10000, 10000);
    }

    public void setCoord(Vector3 vec)
    {
        GameObject pop = Instantiate(ccod, mainP.transform);
        pop.transform.localPosition = new Vector2(vec.x, vec.y + 20);
        pop.name = "ccor";
        pop.GetComponentInChildren<Text>().text = "x:" + ((int)vec.x).ToString() + " | y:" + ((int)vec.y).ToString();
    }
	
	void Update () {
		
	}
}
