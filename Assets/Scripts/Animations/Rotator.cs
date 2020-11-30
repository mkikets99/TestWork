using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public int way { private get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float currangle = 0;
    int time = 200;
    int currtime = 0;
    // Update is called once per frame
    void Update()
    {
        if (way != 0)
        {
            int delay = (int)(Time.deltaTime * 1000);
            if (currtime + delay < time)
            {
                // way == 1 -> 90  currangle = 90
                // way == -1 -> 0

                currangle = (way == 1) ? (float)90 * ((float)currtime / time) : (float)90 - (float)90 * ((float)currtime / time);
                transform.eulerAngles = new Vector3(0, 0, currangle);
                currtime += delay;
            }
            else
            {
                currtime = 0;
                currangle = (way == 1) ? 90 : 0;
                transform.eulerAngles = new Vector3(0, 0, currangle);
                way = 0;
            }
        }
    }
}
