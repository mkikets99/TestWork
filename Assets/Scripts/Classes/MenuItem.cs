using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    GameObject item;

    GameObject Colored;
    GameObject Checkbox;
    GameObject Text;
    GameObject pointer;

    int order = 0;


    // Start is called before the first frame update
    public void LoadMenuItem()
    {
        item = gameObject;
        foreach (Transform child in item.transform)
        {
            if (child.tag == "MenuItem.Color") Colored = child.gameObject;
            if (child.tag == "MenuItem.Checkmark") Checkbox = child.gameObject;
            if (child.tag == "MenuItem.Text") Text = child.gameObject;
            if (child.tag == "MenuItem.Dropdown") pointer = child.gameObject;
        }
    }
    void Start()
    {
        item = gameObject;
        foreach (Transform child in item.transform)
        {
            if (child.tag == "MenuItem.Color") Colored = child.gameObject;
            if (child.tag == "MenuItem.Checkmark") Checkbox = child.gameObject;
            if (child.tag == "MenuItem.Text") Text = child.gameObject;
            if (child.tag == "MenuItem.Dropdown") pointer = child.gameObject;
        }
    }

    internal void PrintToCanvas(GameObject printer,int order)
    {
        this.order = order;
        item.transform.SetParent(printer.transform);
        item.GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        int width = Screen.width;
        int height = Screen.height;
        item.GetComponent<RectTransform>().sizeDelta = new Vector2(width / 4 - 20, 20);
        item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -15-order*25);
    }

    public void SetUI(DataStructure data)
    {
        Colored.GetComponent<Image>().color = data.colorUI;
        Text.GetComponent<Text>().text = data.text;
    }

    bool opened = true;
    public void OnClick(BaseEventData data)
    {
        Debug.Log("Clicked");
        Rotate(opened);
        opened = !opened;
    }

    void Rotate(bool toOpen)
    {
        pointer.GetComponent<Rotator>().way = (toOpen) ? 1 : -1;
    }
}
