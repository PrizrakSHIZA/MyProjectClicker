using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenLevel : MonoBehaviour
{
    public GameObject btn_normal, btn_over, image_normal, image_over;
    [SerializeField] string levelname;

    private void OnMouseDown()
    {
        if (btn_normal != null)
        {
            btn_normal.SetActive(false);
            image_normal.SetActive(false);
            btn_over.SetActive(true);
            image_over.SetActive(true);
        }
        if (RaidBlock._readyforraid)
        {
            //RaidBlock._lastraid = DateTime.Now;
            SceneManager.LoadScene(levelname);
        }
    }

    private void OnMouseUp()
    {
        if (btn_normal != null)
        {
            btn_normal.SetActive(true);
            image_normal.SetActive(true);
            btn_over.SetActive(false);
            image_over.SetActive(false);
        }
    }
}
