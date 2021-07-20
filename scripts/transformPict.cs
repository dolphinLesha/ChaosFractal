using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transformPict : MonoBehaviour {

    Vector2 first;
    Vector2 second;
    Vector2 firstz;
    Vector2 secondz;
    Vector2 firstr;
    Vector2 secondr;
    bool isOn=false;
    bool isOnz = false;
    bool isOnr = false;
    bool isZoom = false;
    bool isRotate = false;

    //public Canvas her;

    void Start () {
        
	}

    private void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&&!isZoom && !isRotate)
        {
            isOn = true;
            first = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && isZoom && !isRotate)
        {
            
            isOnz = true;
            firstz = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && isRotate && !isZoom)
        {
           // print(2);
            isOnr = true;
            firstr = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    private void OnMouseDrag()
    {
        if(isOn)
        {
            second = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            GameObject.Find("script").SendMessage("transfornPos", second - first);
            first = second;
        }
        else if(isOnz)
        {
            
            secondz = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            GameObject.Find("script").SendMessage("zoomPict", secondz - firstz);
            firstz = secondz;
        }
        else if (isOnr)
        {

            secondr = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            GameObject.Find("script").SendMessage("rotatePict", secondr - firstr);
            firstr = secondr;
        }
    }
    private void OnMouseUp()
    {
        isOn = false;
        isOnz = false;
        isOnr = false;
    }

    void Update () {
		if(Input.GetKeyDown(KeyCode.Z))
        {
            isZoom = !isZoom;
            isRotate = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            isRotate = !isRotate;
            isZoom = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject.Find("script").SendMessage("deletePoints");
        }
    }
}
