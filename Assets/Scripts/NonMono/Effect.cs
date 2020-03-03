using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Effect
{
    int id;

    public string name;
    public string description;
    public DateTime time;
    public DateTime endtime;

    public Effect(int id, string name, string description)
    {
        this.id = id;
        this.name = name;
        this.description = description;
    }
}
