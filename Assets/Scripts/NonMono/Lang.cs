using System;
using System.Xml;
using UnityEngine;

public static class Lang
{
    public static string GetText(string name)
    {
        string option = LanguageSelector.option;
        TextAsset textAsset = (TextAsset)Resources.Load("lang");
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(textAsset.text);
        XmlNodeList xList = xml.SelectNodes("/Languages/" + option + "/string[@name='" + name + "']");
        return xList[0].InnerXml;
    }
}