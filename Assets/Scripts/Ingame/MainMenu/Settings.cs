using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using System.Collections.Generic;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void Awake()
    {

    }

    private void Start()
    {
        gameObject.GetComponent<Slider>().onValueChanged.AddListener(OnValueChange);
    }

    public void OnValueChange(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    private void Update()
    {
    }
}
