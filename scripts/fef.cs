
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;
//using UnityEditor;


public class fef : MonoBehaviour {

    public Image point1;
    int function = 1;

    public Text isColorP;
    bool isColourPoints = false;

    screenShotS fuck;
    
    
    

    public Image context;
    public GameObject fun;
    public GameObject setKoef;

    void setCurrentFunctions()
    {
        int curAm = PlayerPrefs.GetInt("ammountOfFunctions");
        for(int i=funcs.Count+1;i<=curAm;i++)
        {
            int len = PlayerPrefs.GetInt("koefLen" + i.ToString());
            a[i] = new float[len];
            b[i] = new float[len];
            c[i] = new float[len];
            d[i] = new float[len];
            e[i] = new float[len];
            f[i] = new float[len];
            for (int k=0;k<len;k++)
            {
                a[i][k] = PlayerPrefs.GetFloat("koef" + i.ToString() + "a" + k.ToString());
                b[i][k] = PlayerPrefs.GetFloat("koef" + i.ToString() + "b" + k.ToString());
                c[i][k] = PlayerPrefs.GetFloat("koef" + i.ToString() + "c" + k.ToString());
                d[i][k] = PlayerPrefs.GetFloat("koef" + i.ToString() + "d" + k.ToString());
                e[i][k] = PlayerPrefs.GetFloat("koef" + i.ToString() + "e" + k.ToString());
                f[i][k] = PlayerPrefs.GetFloat("koef" + i.ToString() + "f" + k.ToString());
            }
            GameObject temp = Instantiate(fun, context.transform);
            temp.name = (i).ToString();
            temp.transform.localPosition = new Vector2(temp.GetComponent<RectTransform>().sizeDelta.x/2+5, -17 - temp.GetComponent<RectTransform>().sizeDelta.y*(i-1));
            temp.GetComponent<Text>().text = PlayerPrefs.GetString("fun" + i.ToString() + "name");
            functions.Add(PlayerPrefs.GetString("fun" + i.ToString() + "name"));
            funcs.Add(temp.GetComponent<Text>());
        }
        context.rectTransform.sizeDelta = new Vector2(context.rectTransform.sizeDelta.x, 29 * curAm+10);
        functionChoose(function);
    }

    public Image per;
    public Text debMessN;
    public Text debMessM;
    public Text debMessB;

    void setMessage(string name,string message, string okButton)
    {
        per.transform.localPosition = new Vector2(0, 0);
        debMessN.text = name;
        debMessM.text = message;
        debMessB.text = okButton;
    }

    public InputField inpNameCreation;
    public void aSaveCreation()
    {
        int curAmF = PlayerPrefs.GetInt("ammountOfFunctions") + 1;
        if(inpNameCreation.text=="")
        {
            
            setMessage("Hey!", "firstly input the name of your creation)", "Oh, yes, ok))");
            return;
        }
        //print(curAmF);
        a[curAmF] = new float[koef.Count];
        b[curAmF] = new float[koef.Count];
        c[curAmF] = new float[koef.Count];
        d[curAmF] = new float[koef.Count];
        e[curAmF] = new float[koef.Count];
        f[curAmF] = new float[koef.Count];
        for (int i = 0; i < koef.Count; i++)
        {
            InputField[] plHol = koef[i].GetComponentsInChildren<InputField>();
            for (int e = 0; e < koHel.Length; e++)
            {
                if (plHol[e].text == "")
                {
                    setMessage("Hey!", "firstly input all coefficients", "Oh, yes, ok");
                    return;
                }
            }

            a[curAmF][i] = float.Parse(plHol[0].text);
            b[curAmF][i] = float.Parse(plHol[1].text);
            c[curAmF][i] = float.Parse(plHol[2].text);
            d[curAmF][i] = float.Parse(plHol[3].text);
            e[curAmF][i] = float.Parse(plHol[4].text);
            f[curAmF][i] = float.Parse(plHol[5].text);
            PlayerPrefs.SetFloat("koef" + curAmF.ToString() + "a" + i.ToString(), a[curAmF][i]);
            PlayerPrefs.SetFloat("koef" + curAmF.ToString() + "b" + i.ToString(), b[curAmF][i]);
            PlayerPrefs.SetFloat("koef" + curAmF.ToString() + "c" + i.ToString(), c[curAmF][i]);
            PlayerPrefs.SetFloat("koef" + curAmF.ToString() + "d" + i.ToString(), d[curAmF][i]);
            PlayerPrefs.SetFloat("koef" + curAmF.ToString() + "e" + i.ToString(), e[curAmF][i]);
            PlayerPrefs.SetFloat("koef" + curAmF.ToString() + "f" + i.ToString(), f[curAmF][i]);
        }
        PlayerPrefs.SetInt("koefLen" + curAmF.ToString(),koef.Count);
        PlayerPrefs.SetInt("ammountOfFunctions", curAmF);
        PlayerPrefs.SetString("fun" + curAmF.ToString() + "name", inpNameCreation.text);
        setCurrentFunctions();
    }

    List<GameObject> koef = new List<GameObject>();
    public Image createFractalIm;
    string[] koHel = { "a", "b", "c", "d", "e", "f" };

    public void aOpenSelectCre()
    {
        resolutionPng.text = autoResolution.ToString();
        pathDirection.text = autoPath;
        createFractalIm.transform.localPosition = new Vector2(0, 0);
        //createFractalIm.rectTransform.sizeDelta = new Vector2(Screen.height / her2.scaleFactor, Screen.height / her2.scaleFactor);
        swapMenu();
    }
    public void aReturn()
    {
        createFractalIm.transform.localPosition = new Vector2(10000, 10000);
        swapMenu();
    }

    void instCreateFractal()
    {
        GameObject temp = Instantiate(setKoef, createFractalIm.transform);
        koef.Add(temp);
        InputField[] plHol = temp.GetComponentsInChildren<InputField>();
        for(int i=0;i<koHel.Length;i++)
        {
            plHol[i].placeholder.GetComponent<Text>().text = "put " + koHel[i] + koef.Count.ToString();
        }
        temp.name = "cell" + (koef.Count - 1).ToString();
        temp.transform.localPosition = new Vector2(-7, -60 * (koef.Count - 1));
        temp = Instantiate(setKoef, createFractalIm.transform);
        koef.Add(temp);
        plHol = temp.GetComponentsInChildren<InputField>();
        for (int i = 0; i < koHel.Length; i++)
        {
            plHol[i].placeholder.GetComponent<Text>().text = "put " + koHel[i] + koef.Count.ToString();
        }
        temp.name = "cell" + (koef.Count - 1).ToString();
        temp.transform.localPosition = new Vector2(-7, -60 * (koef.Count - 1));
        if (koef.Count <= 2)
        {
            addB.transform.localPosition = new Vector2(0, -60 * (koef.Count - 2));
            deleteB.transform.localPosition = new Vector2(10000, -60 * (koef.Count - 2));
        }
    }
    public Image addB;
    public Image deleteB;
    public void addKoef()
    {
        if (koef.Count >= 5)
            return; 
        GameObject temp = Instantiate(setKoef, createFractalIm.transform);
        koef.Add(temp);
        InputField[] plHol = temp.GetComponentsInChildren<InputField>();
        for (int i = 0; i < koHel.Length; i++)
        {
            plHol[i].placeholder.GetComponent<Text>().text = "put " + koHel[i] + koef.Count.ToString();
        }
        temp.name = "cell" + (koef.Count - 1).ToString();
        temp.transform.localPosition = new Vector2(-7, -60 * (koef.Count - 1));
        addB.transform.localPosition = new Vector2(-55, -60 * (koef.Count - 2));
        deleteB.transform.localPosition = new Vector2(-35 + addB.rectTransform.sizeDelta.x, -60 * (koef.Count - 2));
        if (koef.Count >= 5)
        {
            addB.transform.localPosition = new Vector2(10000, -60 * (koef.Count - 2));
            deleteB.transform.localPosition = new Vector2(0, -60 * (koef.Count - 2));
        }
    }
    public void aDelKoef()
    {
        if (koef.Count <= 2)
            return;
        Destroy(GameObject.Find("cell" + (koef.Count - 1).ToString()));
        koef.RemoveAt(koef.Count - 1);
        addB.transform.localPosition = new Vector2(-55, -60 * (koef.Count - 2));
        deleteB.transform.localPosition = new Vector2(-35 + addB.rectTransform.sizeDelta.x, -60 * (koef.Count - 2));
        if (koef.Count <=2)
        {
            addB.transform.localPosition = new Vector2(0, -60 * (koef.Count - 2));
            deleteB.transform.localPosition = new Vector2(10000, -60 * (koef.Count - 2));
        }
    }
    string pathOfCreated;
    public void aRandomize()
    {
        for(int i=0;i<koef.Count;i++)
        {
            InputField[] plHol = koef[i].GetComponentsInChildren<InputField>();
            for (int e = 0; e < koHel.Length-2; e++)
            {
                plHol[e].text = (UnityEngine.Random.Range(-0.9f,0.9f)).ToString();
            }
            for (int e = koHel.Length - 2; e < koHel.Length; e++)
            {
                plHol[e].text = (UnityEngine.Random.Range(-1.5f, 1.5f)).ToString();
            }
        }
    }

    public void aBuild()
    {
        int curAmF = PlayerPrefs.GetInt("ammountOfFunctions")+1;
        //print(curAmF);
        a[curAmF] = new float[koef.Count];
        b[curAmF] = new float[koef.Count];
        c[curAmF] = new float[koef.Count];
        d[curAmF] = new float[koef.Count];
        e[curAmF] = new float[koef.Count];
        f[curAmF] = new float[koef.Count];
        for (int i = 0; i < koef.Count; i++)
        {
            InputField[] plHol = koef[i].GetComponentsInChildren<InputField>();
            for (int e = 0; e < koHel.Length; e++)
            {
                if(plHol[e].text == "")
                {
                    setMessage("Hey!", "firstly input all coefficients", "Oh, yes, ok");
                    return;
                }
            }
            
            a[curAmF][i] = float.Parse(plHol[0].text);
            b[curAmF][i] = float.Parse(plHol[1].text);
            c[curAmF][i] = float.Parse(plHol[2].text);
            d[curAmF][i] = float.Parse(plHol[3].text);
            e[curAmF][i] = float.Parse(plHol[4].text);
            f[curAmF][i] = float.Parse(plHol[5].text);
            function = curAmF;
            deletePoints();
            countVero(a[function], b[function], c[function], d[function]);
            isName = false;
            GameObject.Find("name").SendMessage("getCh", isName);
            isWantSave = false;
            returnFromPng();
        }
    }

    public Image openIm;

    
    public void aOpenCreated()
    {
        if(!File.Exists(pathOfSaving))
        {
            setMessage("Hmm", "The image, you've just created was renamed/deleted/moved", "Oh, yes, ok");
        }
        else
        {
            byte[] data = File.ReadAllBytes(pathOfSaving);
            Texture2D result = new Texture2D((int)(Screen.height/her2.scaleFactor), (int)(Screen.height / her2.scaleFactor));
            result.LoadImage(data);
            openIm.sprite = Sprite.Create(result,new Rect(0,0,result.width,result.height),new Vector2(0,0));
            openIm.transform.localPosition = new Vector2(0, 0);
            openIm.rectTransform.sizeDelta = new Vector2(Screen.height / her2.scaleFactor, Screen.height / her2.scaleFactor);
        }
    }
    public void aBackFromOpen()
    {
        openIm.transform.localPosition = new Vector2(10000, 10000);
    }
    bool isFirst = true;
    void Start () {

        autoPath = PlayerPrefs.GetString("autoPathS");
        autoResolution = PlayerPrefs.GetInt("autoResS");
        pathOfSaving = autoPath;
        
        setAutoPath.text = autoPath;
        if (autoResolution != 0)
        {
            setAutoResolution.text = autoResolution.ToString();
            resolutionOfPng = autoResolution;
        }
        else { }
        //PlayerPrefs.SetInt("ammountOfFunctions", 12);
        functions.Add("");
        functions.Add("tryangle");
        functions.Add("barnsley fern");
        functions.Add("dragon fractal");
        functions.Add("genPict");
        functions.Add("crystal fractal");
        functions.Add("cute fern fractal");
        functions.Add("tree fractal");
        functions.Add("the pool of Newton");
        functions.Add("Mandelbrot set");
        functions.Add("list fractal");
        functions.Add("black hole fractal");
        functions.Add("plexus fractal");
        setCurrentFunctions();
        per.rectTransform.sizeDelta = new Vector2(Screen.width / her2.scaleFactor, Screen.height / her2.scaleFactor);
        per2.rectTransform.sizeDelta = new Vector2(Screen.width / her2.scaleFactor, Screen.height / her2.scaleFactor);
        pictOpen.rectTransform.sizeDelta = new Vector2(Screen.width / her2.scaleFactor, Screen.height / her2.scaleFactor);
        instCreateFractal();
        deltaSX = 185/2;
        deltaSY = 195/2;
        //print(deltaSX);
        //colorSettings.GetComponent<RectTransform>().offsetMin = new Vector2(deltaSX, deltaSY);
        //colorSettings.GetComponent<RectTransform>().offsetMax = new Vector2(-deltaSX, -deltaSY);

        {
            a[0] = new float[0];
            a[1] = new float[0];
            a[2] = new float[4];
            a[2][0] = 0f;
            a[2][1] = 0.2f;
            a[2][2] = -0.15f;
            a[2][3] = 0.85f;
            a[3] = new float[2];
            a[3][0] = Mathf.Cos(Mathf.PI / 4) / Mathf.Sqrt(2);
            a[3][1] = Mathf.Cos(3 * Mathf.PI / 4) / Mathf.Sqrt(2);
            a[4] = new float[0];
            a[5] = new float[4];
            a[5][0] = 0.255f;
            a[5][1] = 0.255f;
            a[5][2] = 0.255f;
            a[5][3] = 0.37f;
            a[6] = new float[4];
            a[6][0] = 0;
            a[6][1] = 0.2f;
            a[6][2] = -0.15f;
            a[6][3] = 0.85f;
            a[7] = new float[5];
            a[7][0] = 0.195f;
            a[7][1] = 0.4620f;
            a[7][2] = -0.0580f;
            a[7][3] = -0.0350f;
            a[7][4] = -0.6370f;
            a[10] = new float[2];
            a[10][0] = 0.4f;
            a[10][1] = -0.8f;
            a[11] = new float[2];
            a[11][0] = 0.73f;
            a[11][1] = 0.33f;
            a[12] = new float[3];
            a[12][0] = 0.73f;
            a[12][1] = 0.33f;
            a[12][2] = 0.21f;

            b[0] = new float[0];
            b[1] = new float[0];
            b[2] = new float[4];
            b[2][0] = 0f;
            b[2][1] = -0.25f;
            b[2][2] = 0.3f;
            b[2][3] = 0.05f;
            b[3] = new float[2];
            b[3][0] = -Mathf.Sin(Mathf.PI / 4) / Mathf.Sqrt(2);
            b[3][1] = -Mathf.Sin(3 * Mathf.PI / 4) / Mathf.Sqrt(2);
            b[4] = new float[0];
            b[5] = new float[4];
            b[5][0] = 0f;
            b[5][1] = 0f;
            b[5][2] = 0f;
            b[5][3] = -0.642f;
            b[6] = new float[4];
            b[6][0] = 0;
            b[6][1] = -0.26f;
            b[6][2] = 0.28f;
            b[6][3] = 0.04f;
            b[7] = new float[5];
            b[7][0] = -0.4880f;
            b[7][1] = 0.4140f;
            b[7][2] = -0.0700f;
            b[7][3] = 0.0700f;
            b[7][4] = 0;
            b[10] = new float[2];
            b[10][0] = -0.3733f;
            b[10][1] = -0.1867f;
            b[11] = new float[2];
            b[11][0] = 0.6543f;
            b[11][1] = 0.1867f;
            b[12] = new float[3];
            b[12][0] = -0.6543f;
            b[12][1] = 0.1867f;
            b[12][2] = 0.34f;

            c[0] = new float[0];
            c[1] = new float[0];
            c[2] = new float[4];
            c[2][0] = 0f;
            c[2][1] = 0.2f;
            c[2][2] = 0.25f;
            c[2][3] = -0.05f;
            c[3] = new float[2];
            c[3][0] = Mathf.Sin(Mathf.PI / 4) / Mathf.Sqrt(2);
            c[3][1] = Mathf.Sin(3 * Mathf.PI / 4) / Mathf.Sqrt(2);
            c[4] = new float[0];
            c[5] = new float[4];
            c[5][0] = 0f;
            c[5][1] = 0f;
            c[5][2] = 0f;
            c[5][3] = 0.642f;
            c[6] = new float[4];
            c[6][0] = 0;
            c[6][1] = 0.23f;
            c[6][2] = 0.26f;
            c[6][3] = -0.04f;
            c[7] = new float[5];
            c[7][0] = 0.3440f;
            c[7][1] = -0.2520f;
            c[7][2] = 0.4530f;
            c[7][3] = -0.4690f;
            c[7][4] = -0;
            c[10] = new float[2];
            c[10][0] = 0.06f;
            c[10][1] = 0.1371f;
            c[11] = new float[2];
            c[11][0] = -0.85f;
            c[11][1] = 0.132f;
            c[12] = new float[3];
            c[12][0] = 0.25f;
            c[12][1] = 0.132f;
            c[12][2] = 0.78f;

            d[0] = new float[0];
            d[1] = new float[0];
            d[2] = new float[4];
            d[2][0] = 0.15f;
            d[2][1] = 0.2f;
            d[2][2] = 0.25f;
            d[2][3] = 0.85f;
            d[3] = new float[2];
            d[3][0] = Mathf.Cos(Mathf.PI / 4) / Mathf.Sqrt(2);
            d[3][1] = Mathf.Cos(3 * Mathf.PI / 4) / Mathf.Sqrt(2);
            d[4] = new float[0];
            d[5] = new float[4];
            d[5][0] = 0.255f;
            d[5][1] = 0.255f;
            d[5][2] = 0.255f;
            d[5][3] = 0.37f;
            d[6] = new float[4];
            d[6][0] = 0.16f;
            d[6][1] = 0.22f;
            d[6][2] = 0.24f;
            d[6][3] = 0.85f;
            d[7] = new float[5];
            d[7][0] = 0.4430f;
            d[7][1] = 0.3610f;
            d[7][2] = -0.1110f;
            d[7][3] = 0.0220f;
            d[7][4] = 0.5010f;
            d[10] = new float[2];
            d[10][0] = 0.6f;
            d[10][1] = 0.8f;
            d[11] = new float[2];
            d[11][0] = 0.3245f;
            d[11][1] = -0.84f;
            d[12] = new float[3];
            d[12][0] = 0.3245f;
            d[12][1] = -0.84f;
            d[12][2] = -0.23f;

            e[0] = new float[0];
            e[1] = new float[0];
            e[2] = new float[4];
            e[2][0] = 0f;
            e[2][1] = 0f;
            e[2][2] = 0f;
            e[2][3] = 0f;
            e[3] = new float[2];
            e[3][0] = 0;
            e[3][1] = 1;
            e[4] = new float[0];
            e[5] = new float[4];
            e[5][0] = 0.3726f;
            e[5][1] = 0.1146f;
            e[5][2] = 0.6306f;
            e[5][3] = 0.6356f;
            e[6] = new float[4];
            e[6][0] = 0;
            e[6][1] = 0;
            e[6][2] = 0;
            e[6][3] = 0;
            e[7] = new float[5];
            e[7][0] = 0.4431f;
            e[7][1] = 0.2511f;
            e[7][2] = 0.5976f;
            e[7][3] = 0.4884f;
            e[7][4] = 0.8562f;
            e[10] = new float[2];
            e[10][0] = 0.3533f;
            e[10][1] = 1.1f;
            e[11] = new float[2];
            e[11][0] = 0f;
            e[11][1] = -0.1f;
            e[12] = new float[3];
            e[12][0] = 0.3f;
            e[12][1] = 0f;
            e[12][2] = 1.2f;

            f[0] = new float[0];
            f[1] = new float[0];
            f[2] = new float[4];
            f[2][0] = 0f;
            f[2][1] = 1.5f;
            f[2][2] = 0.45f;
            f[2][3] = 1.5f;
            f[3] = new float[2];
            f[3][0] = 0;
            f[3][1] = 0;
            f[4] = new float[0];
            f[5] = new float[4];
            f[5][0] = 0.6712f;
            f[5][1] = 0.2232f;
            f[5][2] = 0.2232f;
            f[5][3] = -0.0061f;
            f[6] = new float[4];
            f[6][0] = 0;
            f[6][1] = 1.6f;
            f[6][2] = 0.44f;
            f[6][3] = 1.6f;
            f[7] = new float[5];
            f[7][0] = 0.2452f;
            f[7][1] = 0.5692f;
            f[7][2] = 0.0969f;
            f[7][3] = 0.5069f;
            f[7][4] = 0.2513f;
            f[10] = new float[2];
            f[10][0] = 0;
            f[10][1] = 0.1f;
            f[11] = new float[2];
            f[11][0] = 0.23f;
            f[11][1] = -0.463f;
            f[12] = new float[3];
            f[12][0] = 0f;
            f[12][1] = -0.5f;
            f[12][2] = 0f;
        }
        
            function = UnityEngine.Random.Range(1, funcs.Count + 1);
        if(function == 4 || function == 8 || function == 9 || function == 1)
        {
            function = 12;
        }
        maxAmmountOfPoints = 500000;
        Masch = 300;
        countVero(a[function], b[function], c[function], d[function]);
        target = new Texture2D((int)(Screen.width / her2.scaleFactor), (int)(Screen.height / her2.scaleFactor));
        currentOfpoints = 0;
        genFastUniversalFunction();
        function = 1;
        maxAmmountOfPoints = 2500;
        Masch = 20;
        functionChoose(1);

        isFinished.color = new Color(isFinished.color.r, isFinished.color.g, isFinished.color.b, 0);

        maxPoints = (int)maxP.value;
        speed = (1 - speedSlider.value);
        if (speed == 0)
        {
            speed = 0.000001f;
        }
    }

    public Image isAutoScale;
    public void pngForObj(Sprite her)
    {
        isAutoScale.sprite = her;
    }

    bool isAutoScaleB=false;
    public void changeAutoScale(bool isA)
    {
        isAutoScaleB = isA;
    }

    public InputField scaleInp;
    public InputField sizeInp;

    public void changeScale()
    {
        if (scaleInp.text != "")
        {
            Masch = float.Parse(scaleInp.text);
        }
        scaleInp.text = "";
    }
    public InputField chScale2;
    public void changeScale2()
    {
        if (chScale2.text != "")
        {
            Masch = float.Parse(chScale2.text);
        }
        
    }

    float sizeP=2;
    public void changeSize()
    {
        if (sizeInp.text != "")
        {
            sizeP = float.Parse(sizeInp.text);
            //print(sizeP);
        }
        sizeInp.text = "";
    }

    bool isName = true;
    int currentAlgo = 0;

    public void startGen()
    {
        
        isGenerating = true;
        swapMenu();
        isFinished.color = new Color(isFinished.color.r, isFinished.color.g, isFinished.color.b, 0);
        if (function == 1)
        {
            isName = false;
            GameObject.Find("name").SendMessage("getCh", isName);
            if (phase == maxPoints)
            {
                if(currentAlgo==2)
                {
                    target = new Texture2D((int)(Screen.width / her2.scaleFactor), (int)(Screen.height / her2.scaleFactor));
                    try
                    {
                        maxAmmountOfPoints = int.Parse(maxAmOfPoints.text);
                        if (maxAmmountOfPoints < 0)
                            maxAmmountOfPoints = 200000;
                    }
                    catch
                    {
                        maxAmmountOfPoints = 200000;
                    }
                    phase = 0;
                    currentOfpoints = 0;
                    generateTreygolnik();
                }
                else if(currentAlgo ==1)
                {
                    try
                    {
                        maxAmmountOfPoints = int.Parse(maxAmOfPoints.text);
                        if (maxAmmountOfPoints < 0)
                            maxAmmountOfPoints = 5000;
                    }
                    catch
                    {
                        maxAmmountOfPoints = 5000;
                    }
                    phase = 0;
                    isGen = true;
                    StartCoroutine("generating");
                }
                else if(currentAlgo==0)
                {
                    //for(int i=1;i<=maxPoints;i++)
                    //{
                    //    GameObject.Find("stepByStep").SendMessage("setCoord",GameObject.Find("point"+i.ToString()).GetComponent<Transform>().transform.localPosition);
                    //}
                    slowTreygolnik();
                }
            }
            else
            {
                if(currentAlgo == 3)
                {
                    
                    phase = 0;
                    returnFromPng();
                }
            }
        }
        else if (function == 4)
        {
            isPict = true;
            deletePoints();
            isName = false;
            GameObject.Find("name").SendMessage("getCh", isName);
            isGen = true;
            StartCoroutine("genPict");
        }
        else if (function == 8 || function == 9)
        {
            if (currentAlgo == 3)
            {
                deletePoints();
                isName = false;
                GameObject.Find("name").SendMessage("getCh", isName);
                returnFromPng();
            }
            else
            {
                setMessage("))))", "choose [to png] option", "ok");
                swapMenu();
            }
        }
        else
        {
            print(1);
            deletePoints();
            print(currentAlgo);
            countVero(a[function], b[function], c[function], d[function]);
            isName = false;
            GameObject.Find("name").SendMessage("getCh", isName);
            if (currentAlgo == 1)
            {
                try
                {
                    maxAmmountOfPoints = int.Parse(maxAmOfPoints.text);
                    if (maxAmmountOfPoints < 0)
                        maxAmmountOfPoints = 5000;
                }
                catch
                {
                    maxAmmountOfPoints = 5000;
                }
                isGen = true;
                StartCoroutine("universalFunction");
            }
            else if (currentAlgo == 0)
            {
                print(2);
                genSlowUniversalFunction();
                genSlowUniversalFunction();
                genSlowUniversalFunction();
                genSlowUniversalFunction();
            }
            else if (currentAlgo == 2)
            {
                try
                {
                    maxAmmountOfPoints = int.Parse(maxAmOfPoints.text);
                    if (maxAmmountOfPoints < 0)
                        maxAmmountOfPoints = 200000;
                }
                catch
                {
                    maxAmmountOfPoints = 200000;
                }
                target = new Texture2D((int)(Screen.width / her2.scaleFactor), (int)(Screen.height / her2.scaleFactor));
                currentOfpoints = 0;
                genFastUniversalFunction();
            }
            else if (currentAlgo == 3)
            {
                returnFromPng();
            }
        }
    }
    List<string> functions = new List<string>();
    bool isGenerating=false;
    bool isToPNG = false;
    public Text istoPNG;

    public void changeAlgo(int num)
    {
        if(currentAlgo!=num)
        currentAlgo = num;
        
    }

    public void changeToPng(bool rez)
    {
        if(rez)
        {
            currentAlgo = 3;
        }
        else
        {
            currentAlgo = 2;
        }
    }

    const int iter = 50;
    const float min = 0.000001f;
    const float max = 1000000;


    void Draw(int mx1, int my1)
    {
        float n, mx, my;
        float p;
        complex z, t, d = new complex();

        mx = mx1 / 2;
        my = my1 / 2;

        for (float y = -my; y < my; y++)
            for (float x = -mx; x < mx; x++)
            {
                n = 0;
                z.x = x * 0.005f;
                z.y = y * 0.005f;
                d = z;

                while ((Mathf.Pow((float)z.x, 2) + Mathf.Pow((float)z.y, 2) < max) && (Mathf.Pow((float)d.x, 2) + Mathf.Pow((float)d.y, 2) > min) && (n < iter))
                {
                    t = z;
                    p = Mathf.Pow(Mathf.Pow((float)t.x, 2) + Mathf.Pow((float)t.y, 2), 2);
                    z.x = 2 / 4 * t.x + (Mathf.Pow((float)t.x, 2) - Mathf.Pow((float)t.y, 2)) / (3 * p);
                    z.y = 2 / 4 * t.y * (1 - t.x / p);
                    d.x = Mathf.Abs((float)t.x - (float)z.x);
                    d.y = Mathf.Abs((float)t.y - (float)z.y);
                    n++;
                }
                target.SetPixel((int)(mx + x), (int)(my + y), new Color(((n * 12) % 100) / 100, ((0.12f*n) % 100) /100, ((n * 78) % 100) / 100));
            }
        target.Apply();
        
        byte[] bytes = target.EncodeToPNG();

        try
        {
            File.WriteAllBytes(pathOfSaving, bytes);
        }
        catch
        {
            setMessage(":(", "the path was invalid", "ok");
        }
        isFinished.color = new Color(isFinished.color.r, isFinished.color.g, isFinished.color.b, 1);
        isName = true;
        GameObject.Find("name").SendMessage("getCh", isName);
    }

    public void countVero(float[] a,float[] b,float[] c,float[] d)
    {

        float sum=0;
        for(int i = 0;i<a.Length;i++)
        {
            sum +=Mathf.Abs((a[i] * d[i]) - (b[i] * c[i]));
        }
        for (int i = 0; i < a.Length; i++)
        {
            vero[i] = Mathf.Abs((a[i] * d[i]) - (b[i] * c[i]))/sum*100;
        }
    }

    public void stopGen()
    {
        isGen = !isGen;
        if (isGenerating)
        {
            if (function == 1)
                StartCoroutine("generating");
            else
                StartCoroutine("universalFunction");
        }
    }

    

    public void deletePoints()
    {
        try
        {
            Destroy(GameObject.Find("hint"));
        }
        catch { };
        isChooseP = false;
        GameObject.Find("stepByStep").SendMessage("theEnd");
        
        if (isGen)
        {
            isGenerating = false;
            stopGen();
        }
        if(function!=4)
        for (int i = 0; i < points.Count; i++)
        {
            Destroy(GameObject.Find("point" + (i + 1).ToString()));
        }
        else
        {
            for (int i = 0; i < points.Count; i++)
            {
                Destroy(GameObject.Find("pict" + i.ToString()));
            }
        }
        points.Clear();
        target = new Texture2D((int)(Screen.width / her2.scaleFactor), (int)(Screen.height / her2.scaleFactor));
        mainP.sprite = null;
        amPoints.text = points.Count.ToString() + " points now";
        isName = true;
        GameObject.Find("name").SendMessage("getCh", isName);
    }

    struct point
    {
       public float x;
       public float y;
       public point(float x1,float y1)
        {
            x = x1;
            y = y1;
        }
    }
    float Masch = 3f;

    void universal(float xP, float yP, float a,float b,float c,float d,float e,float f, out float x, out float y)
    {
        x = xP * a + yP * b + e;
        y = xP * c + yP * d + f;

    }

    int maxPreobr = 120;
    bool isPict = false;

    Color[] colors1 = { new Color(0.3f, 0.5f, 0.1f), new Color(0.1f, 0.7f, 0.7f), new Color(0.5f, 0.9f, 1f), new Color(0.9f, 0.1f, 0.23f), new Color(0.345f, 0.789f, 0.145f) };

    void pictPreobr(Image previous,out Image current)
    {
        current = Instantiate(pict, mainP.transform);
        
        float t = previous.rectTransform.sizeDelta.x - previous.rectTransform.sizeDelta.x*0.1f;
        float t1 = previous.rectTransform.sizeDelta.y * t / previous.rectTransform.sizeDelta.x ;
        current.rectTransform.sizeDelta = new Vector2(t, t1);
        //current.transform.localEulerAngles = new Vector3(0, 0,90);
        
        if(points.Count%2!=0)
        {
            current.color=new Color(0,0,0);
        }

    }

    void masshtabF(float xP, float yP, out float x, out float y)
    {
        x = xP * Masch;
        y = yP * Masch;
    }
    void masshtabRetF(float xP, float yP, out float x, out float y)
    {
        x = xP / Masch;
        y = yP / Masch;
    }

    void perenosF(float xP, float yP,float xTr,float yTr, out float x, out float y)
    {
        x = xP +xTr;
        y = yP + yTr;
    }

    public Image mainP;
    int phase = 0;
    bool isChooseP = false;
    int maxPoints=3;
    public Slider maxP;
    List<Image> points = new List<Image>();


    bool isSwapMenu = false;
    bool isSwapMenuD = false;
    float yMenu = -750f;
    public void swapMenu()
    {
        speedFlex = 1f;
        isSwapMenuD = !isSwapMenuD;
        
        isSwapMenu = true;
        
    }
    public Image hint;
    Image hintTemp;

    public void startPutPoints()
    {
        deletePoints();
        hintTemp = Instantiate(hint, mainP.transform);
        hintTemp.name = "hint";
        phase = 0;
        hintTemp.GetComponentInChildren<Text>().text = "choose the position of " + (phase + 1).ToString() + " point";
        
        swapMenu();
        
        
        isChooseP = true;
    }

    public Text maxPT;
    public void changeMaxPoints()
    {
        maxPoints = (int)maxP.value;
        maxPT.text = maxPoints.ToString();
    }

    public void changeSpeed()
    {
        speed = (1 - speedSlider.value);
        if (speed == 0)
        {
            speed = 0.000001f;
        }
    }
    bool isGen = false;
    float speed=0.5f;
    public Slider speedSlider;
    int maxAmmountOfPoints = 2500;

    //public void test1()
    //{
    //    isGen = true;
    //    StartCoroutine("generating");
    //}
    float[] vero = new float[10];
    int currentVero = 0;
    public InputField veroInp;
    public InputField veroCurrentInp;

    public void setCurrentVero()
    {
        currentVero = int.Parse(veroCurrentInp.text)-1;
        if (currentVero < 0)
            currentVero = 0;
    }
    public List<Text> funcs;

    public void functionChoose(int rej)
    {
        function = rej;
        for(int i=0;i<funcs.Count;i++)
        {
           if(i==rej-1)
           {
                funcs[i].color = new Color(0.0972f, 0.947f, 0.9705f);
            }
           else
           {
                funcs[i].color = new Color(0.95f, 0.95f, 0.95f);
            }
        }
    }
    public Text settedVero;
    bool isSettedVero=false;
    float aSettedVero=1;

    public InputField maxAmOfPoints;
    public Text amPoints;

    public void setMaxOfPoints()
    {
        maxAmmountOfPoints = int.Parse(maxAmOfPoints.text);
        if(maxAmmountOfPoints<0)
        {
            maxAmmountOfPoints = 2500;
        }
    }

    public void setVero()
    {
        aSettedVero = 1;
        settedVero.color = new Color(settedVero.color.r, settedVero.color.g, settedVero.color.b, 1);
        settedVero.text = "the probability of " + (currentVero + 1).ToString() + " was setted";
        isSettedVero = true;
        vero[currentVero] = int.Parse(veroInp.text);
        veroInp.text = "";
        currentVero++;
        veroCurrentInp.text = (currentVero+1).ToString();
        //print(vero[currentVero]);
        //print(currentVero);
    }
    Image changeSizeP(Image temp)
    {
        temp.rectTransform.sizeDelta = new Vector2(sizeP, sizeP);
        return temp;
    }

    

    float[][] a = new float[50][];
    float[][] b = new float[50][];
    float[][] c = new float[50][];
    float[][] d = new float[50][];
    float[][] e = new float[50][];
    float[][] f = new float[50][];

    int iterationsForSpeed = 1;
    public InputField iterationInp;
    public void iSetIterations()
    {
        if(iterationInp.text!="")
        {
            iterationsForSpeed = Mathf.Abs(int.Parse(iterationInp.text));
        }
    }
    int unOptAmPoints=0;
    IEnumerator universalFunction()
    {
        while(isGen)
        {
            for(int i = 0;i<iterationsForSpeed;i++)
            {
                Image her = Instantiate(point1, mainP.transform);
                her.color = new Color(0, 0, 0);
                if (points.Count == 0)
                {
                    her.transform.localPosition = new Vector2(UnityEngine.Random.Range(Screen.width / -2, Screen.width / 2), UnityEngine.Random.Range(Screen.height / -2, Screen.height / 2));
                    unOptAmPoints++;
                }
                else
                {
                    if (points.Count > 2)
                    {
                        float x1, y1;
                        masshtabF(points[points.Count - 2].transform.localPosition.x, points[points.Count - 2].transform.localPosition.y, out x1, out y1);
                        points[points.Count - 2].transform.localPosition = new Vector2(x1,y1);
                        //GameObject.Find("point" + (points.Count - 2).ToString()).GetComponent<Image>().color = new Color(1 - Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2), 1 - Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.x) / (Screen.width / her2.scaleFactor / 2), Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2));
                    }
                    float r = UnityEngine.Random.Range(0f, 100f);

                    float x = 0, y = 0;
                    float xer = points[points.Count - 1].transform.localPosition.x,yer = points[points.Count - 1].transform.localPosition.y;
                    if (r >= 0 && r < vero[0])
                    {
                        universal(xer,yer, a[function][0], b[function][0], c[function][0], d[function][0], e[function][0], f[function][0], out x, out y);
                    }
                    else if (r >= vero[0] && r < vero[1] + vero[0])
                    {
                        universal(xer, yer, a[function][1], b[function][1], c[function][1], d[function][1], e[function][1], f[function][1], out x, out y);
                    }
                    else if (r >= vero[1] + vero[0] && r < vero[2] + vero[1] + vero[0])
                    {
                        universal(xer, yer, a[function][2], b[function][2], c[function][2], d[function][2], e[function][2], f[function][2], out x, out y);
                    }
                    else if (r >= vero[2] + vero[1] + vero[0] && r < vero[2] + vero[1] + vero[0] + vero[3])
                    {
                        universal(xer, yer, a[function][3], b[function][3], c[function][3], d[function][3], e[function][3], f[function][3], out x, out y);
                    }
                    else if (r >= +vero[3] + vero[2] + vero[1] + vero[0] && r < vero[2] + vero[1] + vero[0] + vero[3] + vero[4])
                    {
                        universal(xer, yer, a[function][4], b[function][4], c[function][4], d[function][4], e[function][4], f[function][4], out x, out y);
                    }
                    her.transform.localPosition = new Vector2(x, y);
                    unOptAmPoints++;
                }
                
                her = changeSizeP(her);
                her.name = "point" + (points.Count + 1).ToString();
                points.Add(her);
                amPoints.text = unOptAmPoints.ToString() + " points now";
                //if(points.Count%400==0)
                //{
                //    Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                //    tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
                //    tex.Apply();
                //    mainP.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
                //    for(int e=1;e<397;e++)
                //    {
                //        Destroy(GameObject.Find("point" + (e + 1).ToString()));
                //        points.RemoveAt(1);
                //    }
                //}
                if (unOptAmPoints > maxAmmountOfPoints)
                {
                    isGenerating = false;
                    isFinished.color = new Color(isFinished.color.r, isFinished.color.g, isFinished.color.b, 1);
                    isGen = false;
                    StopCoroutine("universalFunction");
                }

            }
            yield return new WaitForSeconds(speed);
        }
    }

    void genFastUniversalFunction()
    {
        currentOfpoints = 0;
        for (int i = 0; i < target.width; i++)
        {
            for (int e = 0; e < target.height; e++)
            {
                target.SetPixel(i, e, new Color(1, 1, 1));
            }
        }
        previousX = UnityEngine.Random.Range(Screen.width / -2, Screen.height / 2);
        previousY = UnityEngine.Random.Range(Screen.width / -2, Screen.height / 2);
        target.SetPixel((int)previousX, (int)previousY, new Color(1, 0, 0));
        currentOfpoints++;
        for (int i = 1; i < maxAmmountOfPoints; i++)
        {
            float r = UnityEngine.Random.Range(0f, 100f);

            float x = 0, y = 0;
            float xer = previousX, yer = previousY;
            if (r >= 0 && r < vero[0])
            {
                universal(xer, yer, a[function][0], b[function][0], c[function][0], d[function][0], e[function][0], f[function][0], out x, out y);
            }
            else if (r >= vero[0] && r < vero[1] + vero[0])
            {
                universal(xer, yer, a[function][1], b[function][1], c[function][1], d[function][1], e[function][1], f[function][1], out x, out y);
            }
            else if (r >= vero[1] + vero[0] && r < vero[2] + vero[1] + vero[0])
            {
                universal(xer, yer, a[function][2], b[function][2], c[function][2], d[function][2], e[function][2], f[function][2], out x, out y);
            }
            else if (r >= vero[2] + vero[1] + vero[0] && r < vero[2] + vero[1] + vero[0] + vero[3])
            {
                universal(xer, yer, a[function][3], b[function][3], c[function][3], d[function][3], e[function][3], f[function][3], out x, out y);
            }
            else if (r >= +vero[3] + vero[2] + vero[1] + vero[0] && r < vero[2] + vero[1] + vero[0] + vero[3] + vero[4])
            {
                universal(xer, yer, a[function][4], b[function][4], c[function][4], d[function][4], e[function][4], f[function][4], out x, out y);
            }
            float x1, y1;
            masshtabF(x, y, out x1, out y1);
            x1 += target.width / 2;
            y1 += target.height / 2;
            x1 -= 0.5f * Masch;
            y1 -= 0.5f * Masch;
            target.SetPixel((int)(x1), (int)(y1), new Color(1 - x1 / (Screen.width / her2.scaleFactor), y1 / (Screen.height / her2.scaleFactor), x1 / (Screen.width / her2.scaleFactor)));
            previousX = x; previousY = y;
        }
        target.Apply();
        mainP.sprite = Sprite.Create(target, new Rect(0, 0, target.width, target.height), new Vector2(0, 0));
        amPoints.text = maxAmmountOfPoints.ToString() + " points now";
        isFinished.color = new Color(isFinished.color.r, isFinished.color.g, isFinished.color.b, 1);
    }

    public void sNextStep()
    {
        if (function == 1)
            slowTreygolnik();
        else
            genSlowUniversalFunction();
    }

    void genSlowUniversalFunction()
    {
        
            Image her = Instantiate(point1, mainP.transform);
            
            if (points.Count == 0)
            {
                her.transform.localPosition = new Vector2(UnityEngine.Random.Range(Screen.width / -2, Screen.width / 2), UnityEngine.Random.Range(Screen.height / -2, Screen.height / 2));
            }
            else
            {
                if (points.Count > 2)
                {
                    float x1, y1;
                    masshtabF(points[points.Count - 2].transform.localPosition.x, points[points.Count - 2].transform.localPosition.y, out x1, out y1);
                    points[points.Count - 2].transform.localPosition = new Vector2(x1, y1);
                    GameObject.Find("point" + (points.Count - 2).ToString()).GetComponent<Image>().color = new Color(1 - Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2), 1 - Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.x) / (Screen.width / her2.scaleFactor / 2), Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2));
                GameObject.Find("stepByStep").SendMessage("getCoordsSlow", points[points.Count - 2].transform.localPosition);
                }
            
                float r = UnityEngine.Random.Range(0f, 100f);

                float x = 0, y = 0;
                float xer = points[points.Count - 1].transform.localPosition.x, yer = points[points.Count - 1].transform.localPosition.y;
                if (r >= 0 && r < vero[0])
                {
                    universal(xer, yer, a[function][0], b[function][0], c[function][0], d[function][0], e[function][0], f[function][0], out x, out y);
                }
                else if (r >= vero[0] && r < vero[1] + vero[0])
                {
                    universal(xer, yer, a[function][1], b[function][1], c[function][1], d[function][1], e[function][1], f[function][1], out x, out y);
                }
                else if (r >= vero[1] + vero[0] && r < vero[2] + vero[1] + vero[0])
                {
                    universal(xer, yer, a[function][2], b[function][2], c[function][2], d[function][2], e[function][2], f[function][2], out x, out y);
                }
                else if (r >= vero[2] + vero[1] + vero[0] && r < vero[2] + vero[1] + vero[0] + vero[3])
                {
                    universal(xer, yer, a[function][3], b[function][3], c[function][3], d[function][3], e[function][3], f[function][3], out x, out y);
                }
                else if (r >= +vero[3] + vero[2] + vero[1] + vero[0] && r < vero[2] + vero[1] + vero[0] + vero[3] + vero[4])
                {
                    universal(xer, yer, a[function][4], b[function][4], c[function][4], d[function][4], e[function][4], f[function][4], out x, out y);
                }
                her.transform.localPosition = new Vector2(x, y);

            }
            her = changeSizeP(her);
            her.name = "point" + (points.Count + 1).ToString();
            points.Add(her);
            amPoints.text = points.Count.ToString() + " points now";
            if (points.Count > maxAmmountOfPoints)
            {
            GameObject.Find("stepByStep").SendMessage("theEnd");
                isGenerating = false;
                isFinished.color = new Color(isFinished.color.r, isFinished.color.g, isFinished.color.b, 1);
                isGen = false;
            }

        
    }

    bool dontPut = false;

    public void dReturn()
    {
        per.transform.localPosition = new Vector2(1000, 10000);
    }

    public void setForPng()
    {
        
        if (ammountForPng.text != "")
        {
            maxAmmountOfPoints = Mathf.Abs(int.Parse(ammountForPng.text));
        }
        else
        {
            maxAmmountOfPoints = 10000000;
        }
        if(pathDirection.text=="" && resolutionPng.text != "")
        {
            setMessage("Hmmm", "My voice in my head tells, that you have inputed the empty path(", "Hmm, maybe you're right)");
            return;
        }
        else if(pathDirection.text == "" && resolutionPng.text == "")
        {
            setMessage("Hmmm", "Now you have inputed empty path and resolution, go away!", "Oh, yes, sorry");
            return;
        }
        else if(resolutionPng.text == "" && pathDirection.text != "")
        {
            setMessage("Hmmm", "So, you have inputed empty resolution, i'm dissapointed", "Hey, I'll change)");
            return;
        }
        if(function==1)
        {
            pathOfSaving = pathDirection.text;
            generateTreygolnikToPng();
        }
        else if(function==8)
        {
            pathOfSaving = pathDirection.text;
            Draw(resolutionOfPng,resolutionOfPng);
        }
        else if (function == 9)
        {
            pathOfSaving = pathDirection.text;
            W = resolutionOfPng;
            H = resolutionOfPng;
            L = resolutionOfPng / 2 - resolutionOfPng/30;
            mande();
        }
        else
        {
            pathOfSaving = pathDirection.text;
            genfastUniveralToPng();
        }
        
    }

    string pathOfSaving;
    int resolutionOfPng;
    bool isWantSave = false;
    public Image saveDial;

    public void returnFromPng()
    {
        isWantSave = !isWantSave;
        pathDirection.text = autoPath;
        resolutionPng.text = autoResolution.ToString();
        pathOfCreated = pathDirection.text;
        if (isWantSave)
            saveDial.transform.localPosition = new Vector2(0, 0);
        else
            saveDial.transform.localPosition = new Vector2(10000, 10000);
    }

    public Image per2;
    public Text dirName;
    public Image context2;
    string currentPath="";
    //List<Text> directories = new List<Text>();
    public Text fulPath;
    public InputField nameOfCreation;
    List<string> directNames = new List<string>();

    public void backDirectory()
    {
        if (currentPath == "C:/")
            return;
        for(int i=currentPath.Length-2;i>0;i--)
        {
            if(currentPath[i]=='/')
            {
              string h = currentPath.Substring(0, i);
              currentPath = "";
              getDir(h);
                return;
            }
        }
    }
    bool isAutoSavingsPath = false;
    public void confirmDir()
    {
        if(nameOfCreation.text=="")
        {
            setMessage("Tak!", "Please, input name >(", "oki");
            return;
        }
        per2.transform.localPosition = new Vector2(10000, 10000);
        pathOfSaving = currentPath + nameOfCreation.text + ".png";
        if (!isAutoSavingsPath)
            pathDirection.text = pathOfSaving;
        else
        {
            setAutoPath.text = pathOfSaving;
            autoPath = setAutoPath.text;
            PlayerPrefs.SetString("autoPathS", autoPath);
        }
    }
    
    public void getDir(string dirNameCur)
    {
        
        per2.transform.localPosition = new Vector2(0, 0);
        for(int i = 0;i<directNames.Count;i++)
        {
            Destroy(GameObject.Find(directNames[i]));
        }
        directNames.Clear();
        //directories.Clear();
        currentPath += dirNameCur + "/";
        DirectoryInfo di = new DirectoryInfo(currentPath);
        DirectoryInfo[] dirs = di.GetDirectories();
        for(int i=0;i<dirs.Length;i++)
        { 
            directNames.Add(dirs[i].Name);
            Text temp = Instantiate(dirName, context2.transform);
            temp.name = directNames[i];
            temp.text = directNames[i];
            temp.transform.localPosition = new Vector2(temp.rectTransform.sizeDelta.x/2+10, -15 - temp.rectTransform.sizeDelta.y * i);
        }
        fulPath.text = currentPath;
        context2.rectTransform.sizeDelta = new Vector2(context2.rectTransform.sizeDelta.x, 34 * directNames.Count);
    }

    public void canselDir()
    {
        per2.transform.localPosition = new Vector2(10000, 10000);
    }

    public void choosePathOfPng()
    {
        isAutoSavingsPath = false;
        try
       {
            currentPath = "";
            getDir("C:");
       }
       catch
       {
          
       }
       pathDirection.text = pathOfSaving;
    }

    public Image pictOpen;
    public Text curPath;
    string curePath;
    string pathOfOpen;
    List<string> fileNames = new List<string>();
    public Image direct;
    public Image filePng;
    public Image context3;
    public InputField searchInp;
    string posSearch = "*.png";

    public void iOpenPicture()
    {
        isSwapMenuD = true;
        swapMenu();
        pictOpen.transform.localPosition = new Vector2(0, 0);
        iGetPictures("C:");
    }
    public void iGetPictures(string path)
    {
        for (int i = 0; i < directNames.Count; i++)
        {
            Destroy(GameObject.Find(directNames[i]));
        }
        directNames.Clear();
        for (int i = 0; i < fileNames.Count; i++)
        {
            Destroy(GameObject.Find(fileNames[i]));
        }
        fileNames.Clear();
        

        curePath += path + "/";
        DirectoryInfo di = new DirectoryInfo(curePath);
        DirectoryInfo[] dirs = di.GetDirectories();
        for (int i = 0; i < dirs.Length; i++)
        {
            directNames.Add(dirs[i].Name);
            Image temp = Instantiate(direct, context3.transform);
            temp.name = directNames[i];
            temp.GetComponentInChildren<Text>().text = directNames[i];
            temp.transform.localPosition = new Vector2(temp.transform.localPosition.x + temp.rectTransform.sizeDelta.x*(i%5),temp.transform.localPosition.y - temp.rectTransform.sizeDelta.y * (i/5));
        }

        List<string> fileNames2 = Directory.GetFiles(curePath, posSearch).ToList<string>();
        for (int i = 0; i < fileNames2.Count; i++)
        {
            fileNames.Add(fileNames2[i].Substring(curePath.Length, fileNames2[i].Length - curePath.Length));
        }
        byte[] data;
        for (int i = dirs.Length; i < dirs.Length+fileNames.Count; i++)
        {
            Image temp = Instantiate(filePng, context3.transform);
            temp.name = fileNames[i- dirs.Length];
            temp.GetComponentInChildren<Text>().text = fileNames[i- dirs.Length];
            data = File.ReadAllBytes(fileNames2[i - dirs.Length]);
            Texture2D result = new Texture2D(6, 6);
            //result.LoadImage(data);
            result.EncodeToJPG(1);
            Image[] her = temp.GetComponentsInChildren<Image>();
            her[1].sprite = Sprite.Create(result, new Rect(0, 0, result.width, result.height), new Vector2(0, 0));
            //Destroy(result);
            temp.transform.localPosition = new Vector2(temp.transform.localPosition.x + temp.rectTransform.sizeDelta.x * (i % 5), temp.transform.localPosition.y - temp.rectTransform.sizeDelta.y * (i / 5));
        }
        curPath.text = curePath;
        if(directNames.Count+fileNames.Count<=5)
        {
            context3.rectTransform.sizeDelta = new Vector2(context3.rectTransform.sizeDelta.x, 122);
        }
        else
        {
            if((directNames.Count + fileNames.Count) % 5!=0)
                context3.rectTransform.sizeDelta = new Vector2(context3.rectTransform.sizeDelta.x, 122 * (int)((directNames.Count + fileNames.Count) / 5)+122);
            else
                context3.rectTransform.sizeDelta = new Vector2(context3.rectTransform.sizeDelta.x, 122 * (int)((directNames.Count + fileNames.Count) / 5));
        }
        
        
    }
    public void iBackOpen()
    {
        if (curePath == "C:/")
            return;
        for (int i = curePath.Length - 2; i > 0; i--)
        {
            if (curePath[i] == '/')
            {
                string h = curePath.Substring(0, i);
                curePath = "";
                iGetPictures(h);
                return;
            }
        }
    }

    public Slider sizeCh;
    float sW = 768, sH = 768;
    public void changeSizeOpen()
    {
        openIm.rectTransform.sizeDelta = new Vector2(sW * sizeCh.value, sH * sizeCh.value);
    }
    public void iBackDir()
    {
        curePath = "";
        pictOpen.transform.localPosition = new Vector2(10000, 0);
        searchInp.text = "";
        posSearch = "*.png";
    }
    public void iSearchPict()
    {
        posSearch = "*" + searchInp.text + "*.png";
        string h = curePath.Substring(0, curePath.Length-1);
        curePath = "";
        iGetPictures(h);
    }
    public void iOpenPict(string pict)
    {
        openIm.transform.localPosition = new Vector2(0, 0);
        byte[] data = File.ReadAllBytes(curePath+pict);
        Texture2D tex = new Texture2D(6, 6);
        tex.LoadImage(data);
        openIm.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
    }

    public void uChoosePathOfPng()
    {
        isAutoSavingsPath = true;
        try
        {
            currentPath = "";
            getDir("C:");
        }
        catch
        {

        }
        setAutoPath.text = pathOfSaving;
        
    }
    public void setResolution()
    {
        if (resolutionPng.text != "")
        {
            resolutionText.text = (Mathf.Abs(int.Parse(resolutionPng.text))).ToString() + "x" + (Mathf.Abs(int.Parse(resolutionPng.text))).ToString();
            resolutionOfPng = Mathf.Abs(int.Parse(resolutionPng.text));
        }
        else
            resolutionText.text = "T_T";
    }
    public InputField ammountForPng;
    public InputField resolutionPng;
    public Text resolutionText;
    public InputField pathDirection;

    public struct complex
    {
        public double x, y;
        public complex(double x1,double y1)
        {
            x = x1;
            y = y1;
        }
        public double cabs(complex z)
        {
            return Mathf.Sqrt((float)(z.x * z.x + z.y * z.y));
        }
        public static complex operator *(complex z1, complex z2)
        {
            return new complex(z1.x * z2.x - z1.y * z2.y, z1.x * z2.y + z1.y * z2.x);
        }
        public static complex operator +(complex z1, complex z2)
        {
            return new complex(z1.x+ z2.x, z1.y +z2.y);
        }
    }

    int W = 2400, H = 2400;
    int X0,Y0;
    double L = 1550;
    int get_gray_color(complex z0)
    {
        complex z = z0;
        for (int gray = 255; gray>=0; gray--)
        {
            if (z.cabs(z) > 2.9f)
                return gray;
            z = z*z + z0;
        }
        return 0;
    }

    void mande()
    {
        target = new Texture2D(W, H);
        X0 = 3 * W / 4;
        Y0 = H / 2;
        for (int i = 0; i < W; i++)
        {
            for (int e = 0; e < H; e++)
            {
                
                    target.SetPixel((int)i, (int)e, new Color(1, 1, 1));
                
            }
        }
        for (int i=0;i<W;i++)
        {
            for (int e = 0; e < H; e++)
            {
                double x = (i - X0) / L;
                double y = (e - Y0) / L;
                complex z = new complex(x, y);
                int gray = get_gray_color(z);
                if(gray!=255)
                {
                    target.SetPixel((int)i, (int)e, new Color((float)gray / 255f, (float)gray / 255f, (float)gray / 255f));
                }
            }
        }
        target.Apply();
        byte[] bytes = target.EncodeToPNG();
        //loadProc.transform.localPosition = new Vector2(10000, 10000);
        //StopCoroutine("loading");
        try
        {
            File.WriteAllBytes(pathOfSaving, bytes);
        }
        catch
        {
            setMessage(":(", "the path was invalid", "ok");
        }
    }

    int[] autoScaleEn = { };

    public void changeDontPut()
    {
        dontPut = !dontPut;
    }

    void genfastUniveralToPng()
    {
        //loadProc.transform.localPosition = new Vector2(0, 0);
        //StartCoroutine("loading");
        try
        {
            target = new Texture2D(resolutionOfPng, resolutionOfPng);
        }
        catch
        {
            setMessage("oh", "the resoltion is to big(", "Ok)");
        }
        currentOfpoints = 0;
        for (int i = 0; i < target.width; i++)
        {
            for (int e = 0; e < target.height; e++)
            {
                target.SetPixel(i, e, new Color(1, 1, 1));
            }
        }
        previousX = UnityEngine.Random.Range(target.width / -2, target.height / 2);
        previousY = UnityEngine.Random.Range(target.width / -2, target.height / 2);
        target.SetPixel((int)previousX, (int)previousY, new Color(1, 0, 0));
        currentOfpoints++;
        for (int i = 1; i < maxAmmountOfPoints; i++)
        {
            float r = UnityEngine.Random.Range(0f, 100f);

            float x = 0, y = 0;
            float xer = previousX, yer = previousY;
            try
            {
                if (r >= 0 && r < vero[0])
                {
                    universal(xer, yer, a[function][0], b[function][0], c[function][0], d[function][0], e[function][0], f[function][0], out x, out y);
                }
                else if (r >= vero[0] && r < vero[1] + vero[0])
                {
                    universal(xer, yer, a[function][1], b[function][1], c[function][1], d[function][1], e[function][1], f[function][1], out x, out y);
                }
                else if (r >= vero[1] + vero[0] && r < vero[2] + vero[1] + vero[0])
                {
                    universal(xer, yer, a[function][2], b[function][2], c[function][2], d[function][2], e[function][2], f[function][2], out x, out y);
                }
                else if (r >= vero[2] + vero[1] + vero[0] && r < vero[2] + vero[1] + vero[0] + vero[3])
                {
                    universal(xer, yer, a[function][3], b[function][3], c[function][3], d[function][3], e[function][3], f[function][3], out x, out y);
                }
                else if (r >= +vero[3] + vero[2] + vero[1] + vero[0] && r < vero[2] + vero[1] + vero[0] + vero[3] + vero[4])
                {
                    universal(xer, yer, a[function][4], b[function][4], c[function][4], d[function][4], e[function][4], f[function][4], out x, out y);
                }
        }
            catch
        {
                print(vero[0]);
                print(vero[1]);
            setMessage(":(", "current coefficients are not suitable(", "ok");
        }
        float x1, y1;
            masshtabF(x, y, out x1, out y1);
            x1 += target.width / 2;
            y1 += target.height / 2;
            x1 -= 0.5f * Masch;
            y1 -= 0.5f * Masch;
            if (dontPut)
                if (x1 < 0 || x1 > target.width || y1 < 0 || y1 > target.height)
                { }
                else
                {
                    target.SetPixel((int)(x1), (int)(y1), new Color(1 - x1 / (target.width), y1 / (target.height), x1 / (target.width)));
                }
            else
            {
                target.SetPixel((int)(x1), (int)(y1), new Color(1 - x1 / (target.width), y1 / (target.height), x1 / (target.width)));
            }
            previousX = x; previousY = y;
            currentOfpoints++;
        }
        target.Apply();
        
        byte[] bytes = target.EncodeToPNG();
        try
        {
            
            File.WriteAllBytes(pathOfSaving, bytes);
        }
        catch
        {
           setMessage(":(", "the path was invalid", "ok");
        }
        isFinished.color = new Color(isFinished.color.r, isFinished.color.g, isFinished.color.b, 1);
    }

    


    public Image pict;

    IEnumerator genPict()
    {
        
        while (isGen)
        {
            Image her ;
            if (points.Count==0)
            {
                her = Instantiate(pict, mainP.transform);
                her.transform.localPosition = new Vector2(0, 0);
                
            }
            else
            {
               // GameObject.Find("point" + (points.Count - 1).ToString()).GetComponent<Image>().color = new Color(1 - Mathf.Abs(GameObject.Find("point" + (points.Count - 1).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2), 1 - Mathf.Abs(GameObject.Find("point" + (points.Count - 1).ToString()).transform.localPosition.x) / (Screen.width / her2.scaleFactor / 2), Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2));


                // her = Instantiate(pict, GameObject.Find("pict" + (points.Count - 1).ToString()).transform);
                pictPreobr(points[points.Count - 1], out her);
                //print(her.rectTransform.sizeDelta.x);
            }
            amPoints.text = points.Count.ToString() + " points now";
            //her.color = colors1[points.Count % colors1.Length];
            her.name = "pict" + points.Count.ToString();
            points.Add(her);
            
            if (points.Count==maxPreobr)
            {
                isGen = false;
                isGenerating = false;
                StopCoroutine("genPict");
            }
            yield return new WaitForSeconds(speed);
        }
    }
    bool isFastGen=false;
    public Text isFinished;
    Texture2D target;
    int currentOfpoints;
    float previousX, previousY;

    float distanceT=0.5f;

    public InputField distanceInp;
    public void dSetDistance()
    {
        if(distanceInp.text!="")
        {
            distanceT = float.Parse(distanceInp.text);
        }
    }

    void generateTreygolnik()
    {
        target = new Texture2D((int)(Screen.width/her2.scaleFactor), (int)(Screen.height / her2.scaleFactor));
        for (int i = 0; i < target.width; i++)
        {
            for (int e = 0; e < target.height; e++)
            {
                target.SetPixel(i, e, new Color(1, 1, 1));
            }
        }
        for (int i=3;i<maxAmmountOfPoints;i++)
        {
            if (points.Count == maxPoints)
            {
                Image her = Instantiate(point1, mainP.transform);
                points.Add(her);
                her.name="point"+(points.Count).ToString();
                currentOfpoints = points.Count;
                previousX = UnityEngine.Random.Range(Screen.width / -2, Screen.height / 2);
                previousY = UnityEngine.Random.Range(Screen.width / -2, Screen.height / 2);
                target.SetPixel((int)previousX, (int)previousY, new Color(1, 0, 0));
            }
            else
            {
                int r = UnityEngine.Random.Range(0, maxPoints);
                previousX = (previousX + points[r].transform.localPosition.x + (Screen.width / her2.scaleFactor / 2)) *distanceT;
                previousY = (previousY + points[r].transform.localPosition.y + (Screen.height / her2.scaleFactor / 2)) * distanceT;
                //print(previousX);
                target.SetPixel((int)previousX, (int)previousY, new Color(1 - previousX / (Screen.width / her2.scaleFactor), previousY / (Screen.height / her2.scaleFactor), previousX / (Screen.width / her2.scaleFactor)));
                // target.SetPixel(10, 10, new Color(0, 1, 0));
                currentOfpoints++;

            }
            
        }
        target.Apply();
        mainP.sprite = Sprite.Create(target, new Rect(0, 0, target.width, target.height), new Vector2(0, 0));
        amPoints.text = currentOfpoints.ToString() + " points now";
        isFinished.color = new Color(isFinished.color.r, isFinished.color.g, isFinished.color.b, 1);
    }

    List<float> xTre=new List<float>(), yTre=new List<float>();

    void generateTreygolnikToPng()
    {
        //loadProc.transform.localPosition = new Vector2(0, 0);

        //StartCoroutine("loading");
        try
        {
            target = new Texture2D(resolutionOfPng, resolutionOfPng);
        }
        catch
        {
            setMessage("oh", "the resoltion is to big(", "Ok)");
        }
        xTre.Add(UnityEngine.Random.Range(0 + 10, 0 + 70));
        xTre.Add(UnityEngine.Random.Range(target.width - 10, target.width - 70));
        xTre.Add(UnityEngine.Random.Range(target.width / 2 - 70, target.width / 2 + 70));
        yTre.Add(UnityEngine.Random.Range(0 + 10, 0 + 70));
        yTre.Add(UnityEngine.Random.Range(0 + 10, 0 + 70));
        yTre.Add(UnityEngine.Random.Range(target.height - 10, target.height - 90));

        for (int i = 0; i < target.width; i++)
        {
            for (int e = 0; e < target.height; e++)
            {
                target.SetPixel(i, e, new Color(1, 1, 1));
            }
        }
        for (int i = 3; i < maxAmmountOfPoints; i++)
        {
            if (points.Count == maxPoints)
            {
                Image her = Instantiate(point1, mainP.transform);
                points.Add(her);
                her.name = "point" + (points.Count).ToString();
                currentOfpoints = points.Count;
                previousX = UnityEngine.Random.Range(target.width / -2, target.height / 2);
                previousY = UnityEngine.Random.Range(target.width / -2, target.height / 2);
                target.SetPixel((int)previousX, (int)previousY, new Color(1, 0, 0));
            }
            else
            {
                int r = UnityEngine.Random.Range(0, maxPoints);
                previousX = (previousX + xTre[r]) *distanceT;
                previousY = (previousY + yTre[r]) *distanceT;
                //print(previousX);
                target.SetPixel((int)previousX, (int)previousY, new Color(1 - previousX / (target.width), previousY / (target.height), previousX / (target.width)));
                // target.SetPixel(10, 10, new Color(0, 1, 0));
                currentOfpoints++;

            }

        }
        target.Apply();
        byte[] bytes = target.EncodeToPNG();
        //loadProc.transform.localPosition = new Vector2(10000, 10000);
        //StopCoroutine("loading");
        try
        {
            File.WriteAllBytes(pathOfSaving, bytes);
        }
        catch
        {
            setMessage(":(", "the path was invalid", "ok");
        }
        isFinished.color = new Color(isFinished.color.r, isFinished.color.g, isFinished.color.b, 1);
    }

    void slowTreygolnik()
    {
        Image her = Instantiate(point1, mainP.transform);
        
        if (points.Count == maxPoints)
        {
            her.transform.localPosition = new Vector2(UnityEngine.Random.Range(Screen.width / -2, Screen.width / 2), UnityEngine.Random.Range(Screen.height / -2, Screen.height / 2));
        }
        else
        {
            int r = UnityEngine.Random.Range(0, maxPoints);
            her.transform.localPosition = new Vector2((points[points.Count - 1].transform.localPosition.x + points[r].transform.localPosition.x) * distanceT, (points[points.Count - 1].transform.localPosition.y + points[r].transform.localPosition.y) * distanceT);
            GameObject.Find("point" + (points.Count - 2).ToString()).GetComponent<Image>().color = new Color(1 - Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2), 1 - Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.x) / (Screen.width / her2.scaleFactor / 2), Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2));
        }
        GameObject.Find("stepByStep").SendMessage("getCoordsSlow", her.transform.localPosition);
        her = changeSizeP(her);
        her.name = "point" + (points.Count + 1).ToString();
        points.Add(her);
        amPoints.text = points.Count.ToString() + " points now";
        if (points.Count > maxAmmountOfPoints)
        {
            GameObject.Find("stepByStep").SendMessage("theEnd");
            isGenerating = false;
            isFinished.color = new Color(isFinished.color.r, isFinished.color.g, isFinished.color.b, 1);
            isGen = false;
        }
    }

    IEnumerator generating()
    {
        while(isGen)
        {
            for (int i = 0; i < iterationsForSpeed; i++)
            {
                Image her = Instantiate(point1, mainP.transform);
                her.color = new Color(0, 0, 0);
                
                if (points.Count == maxPoints)
                {
                    her.transform.localPosition = new Vector2(UnityEngine.Random.Range(Screen.width / -2, Screen.width / 2), UnityEngine.Random.Range(Screen.height / -2, Screen.height / 2));
                }
                else
                {
                    int r = UnityEngine.Random.Range(0, maxPoints);
                    her.transform.localPosition = new Vector2((points[points.Count - 1].transform.localPosition.x + points[r].transform.localPosition.x) * distanceT, (points[points.Count - 1].transform.localPosition.y + points[r].transform.localPosition.y) * distanceT);
                   // GameObject.Find("point" + (points.Count - 2).ToString()).GetComponent<Image>().color = new Color(1 - Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2), 1 - Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.x) / (Screen.width / her2.scaleFactor / 2), Mathf.Abs(GameObject.Find("point" + (points.Count - 2).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2));

                }
                her = changeSizeP(her);
                her.name = "point" + (points.Count + 1).ToString();
                points.Add(her);


                amPoints.text = points.Count.ToString() + " points now";

                // mainP.sprite = Sprite.Create(target, new Rect(0, 0, target.width, target.height), new Vector2(0, 0));
                if (points.Count /*currentOfpoints*/ > maxAmmountOfPoints)
                {
                    isGenerating = false;
                    isFinished.color = new Color(isFinished.color.r, isFinished.color.g, isFinished.color.b, 1);
                    isGen = false;
                    StopCoroutine("generating");
                }
            }
            yield return new WaitForSeconds(speed);
        }
    }
    Image hertemp22;
    float timeNow = 0;
    
    float recoveryRate = 50f;
    public Image menuP;
    public Canvas her2;
    float speedFlex = 1f;
    float movementSpeed = 6f;

    float colMultiply = 0f;

   public void exitFrom()
    {
        Application.Quit();
        
    }

    public void transfornPos(Vector2 tr)
    {
        float r = UnityEngine.Random.Range(0f, 1f);
        for (int i = 1; i < points.Count; i++)
        {
            if (i % 4 == 1)
            {
                points[i].transform.localPosition += new Vector3(tr.x / her2.scaleFactor, tr.y / her2.scaleFactor);
            }
            else if (i % 4 == 2)
            {
                points[i].transform.localPosition += new Vector3(-tr.y / her2.scaleFactor, tr.x / her2.scaleFactor);
            }
            else if (i % 4 == 3)
            {
                points[i].transform.localPosition += new Vector3(-tr.x / her2.scaleFactor, -tr.y / her2.scaleFactor);
            }
            else if (i % 4 == 0)
            {
                points[i].transform.localPosition += new Vector3(tr.y / her2.scaleFactor, -tr.x / her2.scaleFactor);
            }
            if (r - colMultiply > 0)
                points[i].color = new Color(r - colMultiply, r - colMultiply, r - colMultiply, UnityEngine.Random.Range(0.1f, 1f));
            else
            {
                r = 0.3f;
                colMultiply = 0;
                points[i].color = new Color(r - colMultiply, r - colMultiply, r - colMultiply, UnityEngine.Random.Range(0.1f, 1f));
            }
            colMultiply += 0.015f;
            GameObject.Find("pict" + (i).ToString()).GetComponent<Image>().color = new Color(1 - Mathf.Abs(GameObject.Find("pict" + (i).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2), 1 - Mathf.Abs(GameObject.Find("pict" + (i).ToString()).transform.localPosition.x) / (Screen.width / her2.scaleFactor / 2), Mathf.Abs(GameObject.Find("pict" + (i).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2));

            //if (i%2==1)
            //{
            //    points[i].transform.localPosition += new Vector3(tr.x / her2.scaleFactor / movementSpeed * 2f/*/(i*8f)*/, tr.y / her2.scaleFactor / movementSpeed * 2f/*/(i * 8f)*/);
            //}
            //else
            //{
            //    points[i].transform.localPosition += new Vector3(tr.x / her2.scaleFactor / movementSpeed/2f/*/ (i * 8f)*/, tr.y / her2.scaleFactor / movementSpeed / 2f/*/ (i * 8f)*/);
            //}
        }
    }

    public void zoomPict(Vector2 zoom)
    {
        for(int i=1;i<points.Count;i++)
        {
            
                
            
            float t = points[i].rectTransform.sizeDelta.x + zoom.x*(i*1.1f);
            float t1 = points[i].rectTransform.sizeDelta.y * t / points[i].rectTransform.sizeDelta.x;
            points[i].rectTransform.sizeDelta = new Vector2(t, t1);
        }
    }

    public Image loadProc;
    public Image process;
    public Text perscentProc;

    

    public void rotatePict(Vector2 rotate)
    {
        float r = UnityEngine.Random.Range(0f, 1f);
        // print(1);
        for (int i = 1; i < points.Count; i++)
        {
            //if (r - colMultiply > 0)
            //    points[i].color = new Color(r - colMultiply, r - colMultiply, r - colMultiply, Random.Range(0.1f, 1f));
            //else
            //{
            //    r = 0.3f;
            //    colMultiply = 0;
            //    points[i].color = new Color(r - colMultiply, r - colMultiply, r - colMultiply, Random.Range(0.1f, 1f));
            //}
            //colMultiply += 0.015f;
            GameObject.Find("pict" + (i).ToString()).GetComponent<Image>().color = new Color(1 - Mathf.Abs(GameObject.Find("pict" + (i).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2), 1 - Mathf.Abs(GameObject.Find("pict" + (i).ToString()).transform.localPosition.x) / (Screen.width / her2.scaleFactor / 2), Mathf.Abs(GameObject.Find("pict" + (i).ToString()).transform.localPosition.y) / (Screen.height / her2.scaleFactor / 2));

            float t = points[i].transform.localEulerAngles.z + (rotate.y+rotate.x)*(i*1.1f)/movementSpeed;
            points[i].transform.localEulerAngles = new Vector3(0, 0, t);
        }
    }

    public Image menuIm;

    public Image colorSettings;
    float deltaSX;
    float deltaSY;
    bool isChColor = false;
    bool isChColorD = false;
    bool isRetry=true;
    Color col = new Color(1,0,0);

    public Image settings;
    public InputField setAutoPath;
    string autoPath;
    public InputField setAutoResolution;
    int autoResolution;

    public void uSettings()
    {
        settings.transform.localPosition = new Vector2(0, 0);
        swapMenu();
    }
    public void uSetAutoPath()
    {
        try
        {
            autoPath = setAutoPath.text;
            PlayerPrefs.SetString("autoPathS", autoPath);
        }
        catch
        {

        }
    }
    public void uSetAutoResolution()
    {
        try
        {
            autoResolution = int.Parse(setAutoResolution.text);
            PlayerPrefs.SetInt("autoResS", autoResolution);
        }
        catch
        {
            setMessage("Hey", "you didn't set the resolotion, man", "Oh, yes,yes)");
        }
    }
    public void uBackSettings()
    {
        settings.transform.localPosition = new Vector2(10000, 0);
    }
    //pub


    void Update () {
        
        

        if (isSwapMenu)
        {
            if (isSwapMenuD)
            {

                yMenu = Mathf.MoveTowards(yMenu, -Screen.height/her2.scaleFactor/3, recoveryRate * Time.deltaTime *60f/*/speedFlex*/);

                menuP.transform.localPosition = new Vector2(0, yMenu);
                if (yMenu == -Screen.height / her2.scaleFactor / 3)
                {
                    speedFlex = 1f;
                    isSwapMenu = false;
                }
            }
            else
            {
                yMenu = Mathf.MoveTowards(yMenu, -Screen.height / her2.scaleFactor*1.1f, recoveryRate * Time.deltaTime * 60f/* / speedFlex*/);

                menuP.transform.localPosition = new Vector2(0, yMenu);
                if (yMenu == -Screen.height / her2.scaleFactor*1.1f)
                {
                    speedFlex = 1f;
                    isSwapMenu = false;
                }
            }
            //speedFlex += 0.4f;
        }

        if (isChColor)
        {
            if (!isChColorD)
            {

                deltaSX = Mathf.MoveTowards(deltaSX, 185 / 2, recoveryRate * Time.deltaTime * 5f);
                deltaSY = Mathf.MoveTowards(deltaSX, 195 / 2, recoveryRate * Time.deltaTime * 5f);

                colorSettings.GetComponent<RectTransform>().offsetMin = new Vector2(deltaSX, deltaSY);
                colorSettings.GetComponent<RectTransform>().offsetMax = new Vector2(-deltaSX, -deltaSY);
                if (deltaSX >= 185 / 2 && deltaSY>= 185 / 2)
                {
                    isChColor = false;
                    colorSettings.GetComponent<RectTransform>().offsetMin = new Vector2(10000, 10000);
                    colorSettings.GetComponent<RectTransform>().offsetMax = new Vector2(10000, 10000);
                    
                }
            }
            else
            {
                deltaSX = Mathf.MoveTowards(deltaSX, 0, recoveryRate * Time.deltaTime * 5f);
                deltaSY = Mathf.MoveTowards(deltaSX, 0, recoveryRate * Time.deltaTime * 5f);

                colorSettings.GetComponent<RectTransform>().offsetMin = new Vector2(deltaSX, deltaSY);
                colorSettings.GetComponent<RectTransform>().offsetMax = new Vector2(-deltaSX, -deltaSY);
                if (deltaSX == 0 && deltaSY == 0)
                {
                   
                    isChColor = false;
                }
            }
            
        }

        if (isSettedVero)
        {

            aSettedVero = Mathf.MoveTowards(aSettedVero, 0, recoveryRate * Time.deltaTime /100f);

            settedVero.color = new Color(settedVero.color.r, settedVero.color.g, settedVero.color.b, aSettedVero);
            if (aSettedVero == 0)
            {
                aSettedVero = 1f;
                isSettedVero = false;
            }
        }

        if (isChooseP)
        {
            Image h = Instantiate(point1,mainP.transform);
            h.name = "pon";
            h.transform.localPosition = new Vector2(-Screen.width / her2.scaleFactor / 2, -Screen.height / her2.scaleFactor / 2);
            h.transform.localPosition = h.transform.localPosition + new Vector3(Input.mousePosition.x / her2.scaleFactor, Input.mousePosition.y / her2.scaleFactor);
            if(h.transform.localPosition.x + hintTemp.rectTransform.sizeDelta.x < Screen.width / her2.scaleFactor / 2 && h.transform.localPosition.y + hintTemp.rectTransform.sizeDelta.y < Screen.height / her2.scaleFactor / 2)
            {
                hintTemp.transform.localPosition = new Vector2(-Screen.width / her2.scaleFactor / 2, -Screen.height / her2.scaleFactor / 2);
                hintTemp.transform.localPosition = hintTemp.transform.localPosition + new Vector3(Input.mousePosition.x / her2.scaleFactor + hintTemp.rectTransform.sizeDelta.x / 2, Input.mousePosition.y / her2.scaleFactor + hintTemp.rectTransform.sizeDelta.y / 2);
            }
            else if(h.transform.localPosition.x + hintTemp.rectTransform.sizeDelta.x > Screen.width / her2.scaleFactor / 2 && h.transform.localPosition.y + hintTemp.rectTransform.sizeDelta.y < Screen.height / her2.scaleFactor / 2)
            {
                hintTemp.transform.localPosition = new Vector2(hintTemp.transform.localPosition.x, -Screen.height / her2.scaleFactor / 2);
                hintTemp.transform.localPosition = hintTemp.transform.localPosition + new Vector3(0, Input.mousePosition.y / her2.scaleFactor + hintTemp.rectTransform.sizeDelta.y / 2);
                hintTemp.transform.localPosition = new Vector2(Screen.width / her2.scaleFactor / 2 - hintTemp.rectTransform.sizeDelta.x/2, hintTemp.transform.localPosition.y);
            }
            else if (h.transform.localPosition.x + hintTemp.rectTransform.sizeDelta.x < Screen.width / her2.scaleFactor / 2 && h.transform.localPosition.y + hintTemp.rectTransform.sizeDelta.y > Screen.height / her2.scaleFactor / 2)
            {
                hintTemp.transform.localPosition = new Vector2(-Screen.width / her2.scaleFactor / 2, hintTemp.transform.localPosition.y);
                hintTemp.transform.localPosition = hintTemp.transform.localPosition + new Vector3(Input.mousePosition.x / her2.scaleFactor + hintTemp.rectTransform.sizeDelta.x / 2, 0);
                hintTemp.transform.localPosition = new Vector2(hintTemp.transform.localPosition.x, Screen.height / her2.scaleFactor / 2 -hintTemp.rectTransform.sizeDelta.y/2);
            }
            else if (h.transform.localPosition.x + hintTemp.rectTransform.sizeDelta.x > Screen.width / her2.scaleFactor / 2 && h.transform.localPosition.y + hintTemp.rectTransform.sizeDelta.y > Screen.height / her2.scaleFactor / 2)
            {
            }
            Destroy(GameObject.Find("pon"));
            

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               
                    Image her = Instantiate(point1, mainP.transform);
                Vector3 g = Input.mousePosition - new Vector3(Screen.width / her2.scaleFactor, Screen.height / her2.scaleFactor);

                her.transform.localPosition = new Vector2(-Screen.width / her2.scaleFactor/2, -Screen.height / her2.scaleFactor/2);
                her.transform.localPosition = her.transform.localPosition + new Vector3(Input.mousePosition.x / her2.scaleFactor, Input.mousePosition.y / her2.scaleFactor) ;
                //print(g);
                //print(Input.mousePosition);
                    her.name = "point" + (phase + 1).ToString();
                points.Add(her);
                
                //her = Instantiate(point1, mainP.transform);
                //her.transform.localPosition = new Vector2(-400)
                phase++;
                hintTemp.GetComponentInChildren<Text>().text = "choose the position of " + (phase + 1).ToString() + " point";
                if (phase==maxPoints)
                {
                    Destroy(GameObject.Find("hint"));
                    isChooseP = false;
                }
            }
        }

        if(isPict)
        {
            //if(Input.GetKeyDown(KeyCode.Mouse0)&& Input.GetKeyDown(KeyCode.Mouse1))
            //{
            //    zoomPict
            //}
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if(isFirst)
            {
                isFirst = false;
                deletePoints();
            }
            openIm.transform.localPosition = new Vector2(10000, 10000);
            createFractalIm.transform.localPosition = new Vector2(10000, 10000);
            isWantSave = true;
            iBackDir();
            returnFromPng();
            swapMenu();
            uBackSettings();
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            startGen();
            if (isSwapMenuD)
                swapMenu();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            stopGen();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            startPutPoints();
            if (isSwapMenuD)
                swapMenu();
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            deletePoints();
        }
        if (Input.GetKeyDown(KeyCode.F8))
        {
            aOpenSelectCre();
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            iOpenPicture();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            uSettings();
            if (isSwapMenuD)
                swapMenu();
        }
    }
}
