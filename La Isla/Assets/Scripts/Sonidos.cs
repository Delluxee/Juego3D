using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] audiosFX;

    public void PlaySFX(int index, Vector3 desirePosition)
    {
        transform.position = desirePosition;
        source.PlayOneShot(audiosFX[index]);
    }
}
