using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class iconCreate1 : MonoBehaviour {

    Texture2D target;
	
	void Start () {
		
	}
	

    public void createPict(Vector2 trans)
    {
        target = new Texture2D((int)(trans.x), (int)(trans.y));
        if(trans.x/2>trans.y/2)
        {
            for (int e = 0; e < 6; e++)
            {
                for (int i = 0; i >= -(int)trans.y; i--)
                {
                    int her = -(int)(Mathf.Sqrt(Mathf.Pow((int)(trans.y / 2) - e, 2) - i * i)) + (int)(trans.y / 2);
                    target.SetPixel(i + (int)(trans.y / 2), her, new Color(1, 1, 1));
                    target.SetPixel(i + (int)(trans.y / 2), (int)(2 * trans.y) - her, new Color(1, 1, 1));
                }
            }
        }
        else
        {
            for (int i = 0; i <= (int)trans.x; i++)
            {
                target.SetPixel(i, (int)(Mathf.Sqrt(Mathf.Abs(Mathf.Pow(trans.x / 2, 2) - i * i))), new Color(1, 1, 1));
                target.SetPixel(i, (int)(2 * trans.y) - (int)(Mathf.Sqrt(Mathf.Abs(Mathf.Pow(trans.x / 2, 2) - i * i))), new Color(1, 1, 1));
            }
            for (int i = 1; i < (int)trans.x; i++)
            {
                target.SetPixel(i, (int)(Mathf.Sqrt(Mathf.Abs(Mathf.Pow(trans.x / 2, 2) - i * i))), new Color(1, 1, 1));
                target.SetPixel(i, (int)(2 * trans.y) - (int)(Mathf.Sqrt(Mathf.Abs(Mathf.Pow(trans.x / 2, 2) - i * i))), new Color(1, 1, 1));
            }
        }
        target.Apply();
        GameObject.Find("script").SendMessage("pngForObj",Sprite.Create(target, new Rect(0, 0, target.width, target.height), new Vector2(0, 0)));
    }
	
	void Update () {
		
	}
}
