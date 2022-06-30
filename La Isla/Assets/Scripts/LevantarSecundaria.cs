using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevantarSecundaria : MonoBehaviour
{
    public GameObject Arma2Suelo;
    public GameObject Arma2Jugador;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arma")
        {
            Arma2Suelo.SetActive(false);
            Arma2Jugador.SetActive(true);
        }
    }
}
