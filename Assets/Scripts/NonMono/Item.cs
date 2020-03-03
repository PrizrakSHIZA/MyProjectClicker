using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public int index;
    public string name;
    public int price;

    public Item(int index, string name, int price)
    {
        this.index = index;
        this.name = name;
        this.price = price;
    }
}
