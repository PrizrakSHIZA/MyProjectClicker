using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [HideInInspector] public bool started = false, finished = false;
    public float starttime = 10f;
    public string word;
    public string style;
    float currenttime = 0f;


    private void Start()
    {
        currenttime = starttime;
        if (word == "Lang")
        {
            word = Lang.GetText("time") + ": ";
        }
    }

    void Update()
    {
        if (started && !finished)
        {
            currenttime -= Time.deltaTime;
            gameObject.GetComponent<Text>().text = word + currenttime.ToString(style);
            if (currenttime <= 0)
            {
                currenttime = 0;
                finished = true;
            }
        }
    }

    public void StartTimer()
    {
        started = true;
    }
}
