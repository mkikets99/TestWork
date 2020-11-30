using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavingElem : MonoBehaviour
{
    [SerializeField]
    ColorPicker color;
    [SerializeField]
    InputField input;
    [SerializeField]
    AddNewPopUp field;
    public void Click()
    {
        GameObject eventTrigger = GameObject.FindGameObjectWithTag("Menu.Trigger");
        MenuLoader ml = eventTrigger.GetComponent<MenuLoader>();
        DataStructure dt;
        dt.color = color.posibleColor;
        Color a;
        Debug.Log(dt.color);
        switch (dt.color)
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
        dt.colorUI = a;
        dt.text = input.text;
        ml.AddItem(dt);
        field.Close();
    }
}
