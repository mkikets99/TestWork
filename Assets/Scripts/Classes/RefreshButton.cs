using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshButton : MonoBehaviour
{
    private GameObject button;
    private GameObject text;
    private RectTransform rt;
    private RectTransform rt2;
    [SerializeField]
    Canvas printer;
    [SerializeField]
    GameObject popup;
    GameObject popupVis = null;
    // Start is called before the first frame update
    void Start()
    {
        int width = Screen.width;
        int height = Screen.height;
        button = new GameObject("Refresh Button");
        rt = button.AddComponent<RectTransform> ();
        Image im = button.AddComponent<Image>();
        Button butt = button.AddComponent<Button>();
        im.color = Color.black;
        butt.onClick.AddListener(()=>Click());
        rt.sizeDelta = new Vector2(150,60);
        rt.transform.position = new Vector3(width/2,height- height/6);
        button.transform.SetParent(printer.transform);
        text = new GameObject("Text");
        Text txt = text.AddComponent<Text>();
        rt2 = text.GetComponent<RectTransform>();
        text.transform.SetParent(button.transform);
        rt2.transform.localPosition = Vector3.zero;
        rt2.sizeDelta = new Vector2(150, 60);
        txt.text = "Refresh";
        txt.color = Color.white;
        txt.alignment = TextAnchor.MiddleCenter;
        txt.fontSize = 25;
        txt.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
    }

    // Update is called once per frame
    void Update()
    {
        int width = Screen.width;
        int height = Screen.height;
        rt.sizeDelta = new Vector2(width/4, height/6);
        rt.transform.position = new Vector3(width / 2, height - height / 6);
        rt2.sizeDelta = new Vector2(width / 4, height / 6);
        Text txt = text.GetComponent<Text>();
        txt.fontSize = height/16;
    }

    void Click()
    {
        Text txt = text.GetComponent<Text>();
        if (txt.text.Equals("Add"))
        {
            int width = Screen.width;
            int height = Screen.height;
            if(popupVis==null||!popupVis.activeSelf) popupVis = Instantiate<GameObject>(popup);
            RectTransform rt2 = popupVis.GetComponent<RectTransform>();
            popupVis.transform.SetParent(printer.transform);
            //rt.sizeDelta = new Vector2(width / 4, (float)height / 1.5f);
            //rt.transform.position = new Vector3(width / 2, height / 2);
        }
        else
        {
            MenuLoader ml = GetComponent<MenuLoader>();
            for(var i = 0; i < 4; i++)
            {
                System.Array A = System.Enum.GetValues(typeof(ColorPicker.PossibleColor));
                ColorPicker.PossibleColor posibleColor = (ColorPicker.PossibleColor)A.GetValue(UnityEngine.Random.Range(0, A.Length));
                Color a;
                switch (posibleColor)
                {
                    case ColorPicker.PossibleColor.Red:
                        a = Color.red;
                        break;
                    case ColorPicker.PossibleColor.Green:
                        a = Color.green;
                        break;
                    case ColorPicker.PossibleColor.Yellow:
                        a = Color.yellow;
                        break;
                    case ColorPicker.PossibleColor.Orange:
                        a = Color.Lerp(Color.red, Color.yellow, .5f);
                        break;
                    case ColorPicker.PossibleColor.Blue:
                        a = Color.blue;
                        break;
                    case ColorPicker.PossibleColor.Cyan:
                        a = Color.cyan;
                        break;
                    case ColorPicker.PossibleColor.White:
                        a = Color.white;
                        break;
                    case ColorPicker.PossibleColor.Black:
                        a = Color.black;
                        break;
                    case ColorPicker.PossibleColor.Gray:
                        a = Color.gray;
                        break;
                    default:
                        a = Color.white;
                        break;
                }
                DataStructure dt;
                dt.color = posibleColor;
                dt.colorUI = a;
                dt.text = "Test";
                ml.AddItem(dt);
            }
            ml.Refresh();
        }
        txt.text = "Add";
    }

}
