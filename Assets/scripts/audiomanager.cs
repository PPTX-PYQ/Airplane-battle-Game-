using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    private static audiomanager _instance;
    public static audiomanager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<audiomanager>();
            }
            return _instance;
        }
    }
    private AudioSource audioSource;
    public AudioClip buttonClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayButtonClip()
    {
        audioSource.PlayOneShot(buttonClip, 0.1f);
    }
}
