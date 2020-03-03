using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPlayerRoom : MonoBehaviour
{
    public string levelname;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(levelname);
    }
}
