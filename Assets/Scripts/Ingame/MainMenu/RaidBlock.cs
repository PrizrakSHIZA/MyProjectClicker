using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaidBlock : MonoBehaviour
{
    public static DateTime _lastraid, _endtime;
    public static bool _readyforraid = false;
    public Text timer, money, test;
    DateTime endTime;
    TimeSpan span;

    void Awake()
    {
        Effects.LoadList();

        PlayerData data = SaveSystem.Load();
        if (data != null)
        {
            Player.data = data;
            _lastraid = data.lastraid;
            endTime = data.endtime;
        }
        else
        {
            Player.data = new PlayerData(200, 0, 0, DateTime.Now, DateTime.Now, new List<Item>(), new List<Effect>());
            _lastraid = DateTime.Now;
            endTime = DateTime.Now;
        }
        //Effects.AddEffect(1, new TimeSpan(0, 2, 0));
        //Effects.AddEffect(2, new TimeSpan(0, 0, 30));
    }

    void Update()
    {
        UpdateRaidblock();
        UpdateEffects();
    }

    private void UpdateRaidblock()
    {
        span = endTime.Subtract(DateTime.Now);
        if (span <= TimeSpan.Zero)
        {
            timer.text = Lang.GetText("readytoraid");
            _readyforraid = true;
        }
        else
        {
            _readyforraid = false;
            timer.text = span.Minutes.ToString() + ":" + span.Seconds.ToString("00");
        }

        money.text = Player.data.money.ToString();
    }

    private void UpdateEffects()
    {
        TimeSpan lasts;
        test.text = "";
        if(Player.data.effects != null)
            foreach (Effect a in Player.data.effects)
            {
                lasts = a.endtime.Subtract(DateTime.Now);
                if (lasts <= TimeSpan.Zero)
                {
                    Player.data.effects.Remove(a);
                }
                else
                    test.text += $"{a.name} - {a.description} - {lasts.Minutes}:{lasts.Seconds.ToString("00")}\n";
            }
    }
}
