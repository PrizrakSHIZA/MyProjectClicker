using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLandscape : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }
}
