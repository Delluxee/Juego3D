using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Se entr� al Trigger");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Se pertenece en el trigger");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Se sali� del trigger");
    }
}
