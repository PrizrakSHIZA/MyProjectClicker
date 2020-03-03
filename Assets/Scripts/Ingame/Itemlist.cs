using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemlist : MonoBehaviour
{
    public GameObject prefab;
    public static List<Item> itemlist = new List<Item>();
    List<GameObject> objlist = new List<GameObject>();

    void Start()
    {
        Getitemlist();
        Addtoshop();
    }

    public void Getitemlist()
    {
        itemlist.Add(new Item(1, "item1", 150));
        itemlist.Add(new Item(2, "item23", 500));
        itemlist.Add(new Item(3, "NotItem", 2500));
    }

    public void Addtoshop()
    {
        GameObject tempobj;

        for (int i = 0; i < itemlist.Count; i++)
        {
            GameObject image = null, text = null;
            tempobj = Instantiate(prefab, transform);
            image = tempobj.transform.Find("Image").gameObject;
            text = tempobj.transform.Find("Buy").transform.Find("Text").gameObject;
            image.GetComponent<Image>().color = Random.ColorHSV();
            text.GetComponent<Text>().text = "Buy " + itemlist[i].price;
            objlist.Add(tempobj);
        }
    }
}
