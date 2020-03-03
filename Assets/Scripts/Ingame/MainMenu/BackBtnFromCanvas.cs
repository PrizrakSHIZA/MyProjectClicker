using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBtnFromCanvas : MonoBehaviour
{
    public Canvas canvas;

    private void OnMouseDown()
    {
        canvas.gameObject.SetActive(false);
    }
}
