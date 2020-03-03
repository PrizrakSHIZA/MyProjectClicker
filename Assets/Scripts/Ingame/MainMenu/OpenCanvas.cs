using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCanvas : MonoBehaviour
{
    public Canvas canvas;

    private void OnMouseDown()
    {
        canvas.gameObject.SetActive(true);
    }
}
