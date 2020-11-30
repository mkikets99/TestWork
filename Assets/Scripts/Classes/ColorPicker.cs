using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public enum PossibleColor
    {
        Red=0xFF0000,
        Green=0x00FF00,
        Yellow=0xFFFF00,
        Orange=0xFFA500,
        Blue=0x0000FF,
        Cyan=0x00FFFF,
        White=0xFFFFFF,
        Black=0x000000,
        Gray=0x808080
    };
    public PossibleColor posibleColor;
    [SerializeField]
    GameObject picker;
    [SerializeField]
    GameObject Cpick;
    GameObject popcp = null;
    // Start is called before the first frame update
    void Start()
    {
        System.Array A = System.Enum.GetValues(typeof(PossibleColor));
        posibleColor = (PossibleColor)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        Color a;
        Debug.Log(posibleColor);
        switch (posibleColor)
        {
            case PossibleColor.Red:
                a = Color.red;
                break;
            case PossibleColor.Green:
                a = Color.green;
                break;
            case PossibleColor.Yellow:
                a = Color.yellow;
                break;
            case PossibleColor.Orange:
                a = Color.Lerp(Color.red,Color.yellow,.5f);
                break;
            case PossibleColor.Blue:
                a = Color.blue;
                break;
            case PossibleColor.Cyan:
                a = Color.cyan;
                break;
            case PossibleColor.White:
                a = Color.white;
                break;
            case PossibleColor.Black:
                a = Color.black;
                break;
            case PossibleColor.Gray:
                a = Color.gray;
                break;
            default:
                a = Color.white;
                break;
        }

        picker.GetComponent<Image>().color = a;
        Button pcr = picker.GetComponent<Button>();
        pcr.onClick.AddListener(() => OpenPick());
    }

    // Update is called once per frame
    void Update()
    {
        int width = Screen.width;
        int height = Screen.height;
        RectTransform rt2 = picker.GetComponent<RectTransform>();
        //rt2.sizeDelta = new Vector2(width / 22, height / 12);
        //rt2.transform.localPosition = new Vector3(5,-20);

        if (popcp != null)
        {
            RectTransform rt3 = popcp.GetComponent<RectTransform>();
            rt3.transform.position = picker.transform.position+new Vector3(50,-50);
        }
    }

    void OpenPick()
    {
        //GameObject cpick = Instantiate
        if (popcp == null) popcp = Instantiate<GameObject>(Cpick);
        RectTransform rt2 = popcp.GetComponent<RectTransform>();
        popcp.transform.SetParent(picker.transform.parent.parent);
        rt2.transform.position = picker.transform.position + new Vector3(50, -50);

        foreach(var butin in GameObject.FindGameObjectsWithTag("cpB"))
        {
            Button bt = butin.GetComponent<Button>();
            bt.onClick.AddListener(() => ClosePick(butin));
        }


    }

    void ClosePick(GameObject buton)
    {
        posibleColor = (PossibleColor)System.Enum.Parse(typeof(PossibleColor), buton.name);
        Color a;
        switch (posibleColor)
        {
            case PossibleColor.Red:
                a = Color.red;
                break;
            case PossibleColor.Green:
                a = Color.green;
                break;
            case PossibleColor.Yellow:
                a = Color.yellow;
                break;
            case PossibleColor.Orange:
                a = Color.Lerp(Color.red, Color.yellow, .5f);
                break;
            case PossibleColor.Blue:
                a = Color.blue;
                break;
            case PossibleColor.Cyan:
                a = Color.cyan;
                break;
            case PossibleColor.White:
                a = Color.white;
                break;
            case PossibleColor.Black:
                a = Color.black;
                break;
            case PossibleColor.Gray:
                a = Color.gray;
                break;
            default:
                a = Color.white;
                break;
        }

        picker.GetComponent<Image>().color = a;
        Destroy(popcp);
        popcp = null;
    }
}
