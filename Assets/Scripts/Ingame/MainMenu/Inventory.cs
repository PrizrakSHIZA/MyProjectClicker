using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject prefab;
    List<Item> itemlist = new List<Item>();

    void Start()
    {
        itemlist = Player.data.items;
    }

    private void OnEnable()
    {
        Addtoinventory();
    }

    public void Addtoinventory()
    {
        GameObject tempobj;
        for (int i = 0; i < itemlist.Count; i++)
        {
            //List<Item> temp = itemlist.FindAll(item => item.index == i);
            GameObject image = null, text = null;
            tempobj = Instantiate(prefab, transform);
            image = tempobj.transform.Find("Image").gameObject;
            text = tempobj.transform.Find("Buy").transform.Find("Text").gameObject;
            image.GetComponent<Image>().color = Random.ColorHSV();
            text.GetComponent<Text>().text = "Use(" /*+ temp.Count + ")"*/;
        }
    }

}
