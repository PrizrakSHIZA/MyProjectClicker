using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int money;
    public int level;
    public int language;
    public DateTime lastraid = new DateTime();
    public DateTime endtime = new DateTime();
    public List<Item> items = new List<Item>();
    public List<Effect> effects = new List<Effect>();
    public Stats stats = new Stats();
    public Indicators indicators = new Indicators();


    [Serializable]
    public struct Indicators
    {
        public float health, maxhealth, stamina, maxstamina, staminaregenspeed, dodge;
    }

    [Serializable]
    public struct Stats
    {
        public int strength, vitality, agility;

        public void Increase(string str)
        {
            switch (str)
                {
                case "str":
                    strength++;
                    break;
                case "vit":
                    vitality++;
                    break;
                case "agi":
                    agility++;
                    break;
                default: break;
                }
        }
    }
    
    public PlayerData(int money, int level, int language, DateTime lastraid, DateTime endtime, List<Item> items, List<Effect> effects)
    {
        this.money = money;
        this.level = level;
        this.language = language;
        this.lastraid = lastraid;
        this.endtime = endtime;
        this.items = items;
        this.effects = effects;
        stats.strength = 1;
        stats.agility = 1;
        stats.vitality = 1;
        Refresh();
    }
    
    public void Refresh()
    {
        //health
        indicators.maxhealth = stats.strength * 5 + 10;
        indicators.health = indicators.maxhealth;
        //stamina
        indicators.maxstamina = 100;
        indicators.stamina = indicators.maxstamina;
        //else
        indicators.dodge = stats.agility * 5;
        indicators.staminaregenspeed = 50;
    }
}
