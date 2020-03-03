using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDisabler : MonoBehaviour
{
    public List<Canvas> list;

    void Start()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].gameObject.SetActive(false);
        }
    }

}
