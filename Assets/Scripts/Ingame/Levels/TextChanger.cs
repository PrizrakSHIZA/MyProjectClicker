using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    public Text raidfinished, money, expirience, clicks;

    void Start()
    {
        raidfinished.text = Lang.GetText("raidfinished");
        money.text = Lang.GetText("money");
        expirience.text = Lang.GetText("expirience");
        clicks.text = Lang.GetText("clicks:");
    }
}
