using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSelector : MonoBehaviour
{
    public static string option;
    public static Dropdown dp;

    public Text[] Back;
    public Text Volume;
    public Text Language;
    public Text ReadyTR;


    void Start()
    {
        dp = gameObject.GetComponent<Dropdown>();
        dp.value = Player.data.language;
        ChangeOption();
    }

    public void UpdateText()
    {
        ChangeOption();
        Player.data.language = dp.value;
        SaveSystem.Save();

        foreach(Text txt in Back)
            txt.text = Lang.GetText("back");

        Volume.text = Lang.GetText("volume");
        Language.text = Lang.GetText("language");
        ReadyTR.text = Lang.GetText("readytoraid");
    }

    void ChangeOption()
    {
        Dropdown dp = gameObject.GetComponent<Dropdown>();
        switch (dp.options[dp.value].text)
        {
            case "English": option = "English"; break;
            case "Русский": option = "Russian"; break;
            case "Українська": option = "Ukrainian"; break;
            default: break;
        }
    }
}
