using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuy : MonoBehaviour
{
    public static int idx = 1;
    int index;
    int price;

    void Start()
    {
        index = idx;
        idx++;
        price = Itemlist.itemlist.Find(item => item.index == index).price;
    }

    public void Click()
    {
        if (Player.data.money <= price)
        {
            print("You havent enought money!");
        }
        else
        {
            Player.data.money -= price;
            Player.data.items.Add(Itemlist.itemlist[index]);
            SaveSystem.Save();
        }
    }
}
