using UnityEngine;
using UnityEngine.U2D.IK;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip soundtrack1;

    public static AudioController Instance;
    void Awake()
    {
        Debug.Log("Audio controller");
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(string soundType)
    {
        switch (soundType)
        {
            case "Soundtrack1":
                audioSource.PlayOneShot(soundtrack1);
                break;

            default:
                break;
        }
    }
}
