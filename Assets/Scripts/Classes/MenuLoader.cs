using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLoader : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject printer;

    [SerializeField]
    GameObject menu;

    [SerializeField]
    GameObject prefabToLoad;

    GameObject Content;

    List<GameObject> items;
    void Start()
    {
        items = new List<GameObject>();
        int width = Screen.width;
        int height = Screen.height;
        //menu = new GameObject("Menu");
        menu = GameObject.Instantiate(menu);
        menu.transform.SetParent(printer.transform);
        RectTransform rt = menu.GetComponent<RectTransform>();
        ScrollRect sr = menu.GetComponent<ScrollRect>();
        sr.horizontal = false;
        sr.vertical = false;
        sr.verticalScrollbar.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        rt.anchorMin = new Vector2(0.5f, 1);
        rt.anchorMax = new Vector2(0.5f, 1);
        //rt.pivot = new Vector2(0.5f, 1);
        Image im = menu.GetComponent<Image>();
        Color d = Color.black;
        d.a = .7f;
        im.color = d;
        rt.sizeDelta = new Vector2(width / 4, height / 2 + height / 7);
        rt.position = new Vector3(width / 2, height / 2 - height / 7);
        Content = GameObject.FindGameObjectWithTag("Menu.Content");
    }

    public void AddItem(DataStructure data)
    {
        GameObject t1 = GameObject.Instantiate(prefabToLoad);
        t1.GetComponent<MenuItem>().LoadMenuItem();
        t1.GetComponent<MenuItem>().SetUI(data);
        t1.GetComponent<MenuItem>().PrintToCanvas(Content,items.Count);
        items.Add(t1);
        Content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 15 + items.Count * 25);
    }
    // Update is called once per frame
    void Update()
    {
        int width = Screen.width;
        int height = Screen.height;
        RectTransform rt = menu.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(width / 4, height / 2 + height / 7);
        rt.position = new Vector3(width / 2, height / 2 - height / 7);
    }

    public void Refresh()
    {
        ScrollRect sr = menu.GetComponent<ScrollRect>();
        sr.vertical = true;
        sr.verticalScrollbar.GetComponent<RectTransform>().sizeDelta = new Vector2(10, 0);
    }
}
