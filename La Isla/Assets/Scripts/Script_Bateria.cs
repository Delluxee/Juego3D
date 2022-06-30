using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Bateria : MonoBehaviour
{
    public GameObject Object;
    public AudioSource source;
    public AudioClip soundFX;

    public void OnGetBattery()
    {
        gameObject.SetActive(false);

        source.transform.position = transform.position;

        source.PlayOneShot(soundFX);
    }
}
