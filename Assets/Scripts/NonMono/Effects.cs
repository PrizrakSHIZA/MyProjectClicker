using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class Effects
{
    public static List<Effect> list = new List<Effect>();

    public static void LoadList()
    {
        list.Add(new Effect(0, "Nothing", "Do nothing"));
        list.Add(new Effect(1, "DoubleCoins", "Every click make coin doubles"));
        list.Add(new Effect(2, "Test2", "Second test"));
    }

    public static void AddEffect(int id, TimeSpan span)
    {
        Effect temp = list[id];
        temp.time = DateTime.Now;
        temp.endtime = DateTime.Now + span;
        Player.data.effects.Add(temp);
    }
}
