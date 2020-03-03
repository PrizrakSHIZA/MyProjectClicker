using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDisabling : MonoBehaviour
{
    void Update()
    {
        if(this.gameObject.activeSelf == true)
        {
            StartCoroutine(Disabling());
        }
    }

    IEnumerator Disabling()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
