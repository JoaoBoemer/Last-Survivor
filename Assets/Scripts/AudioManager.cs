using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip backgroundMenu;
    public AudioClip backgroundLevel1;
    public AudioClip backgroundShop;

    private void Start()
    {
        musicSource.clip = backgroundMenu;
        musicSource.Play();
        DontDestroyOnLoad(gameObject);
    }
}
