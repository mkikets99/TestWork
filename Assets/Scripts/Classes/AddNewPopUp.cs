using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewPopUp : MonoBehaviour
{


    [SerializeField]
    Canvas printer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int width = Screen.width;
        int height = Screen.height;
        RectTransform rt = this.gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(width/4,(float)height/1.5f);
        rt.transform.position = new Vector3(width / 2, height / 2);
    }

    public void Close()
    {
        Destroy(gameObject);
    }
    
}
