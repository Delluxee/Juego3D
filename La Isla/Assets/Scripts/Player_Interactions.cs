using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interactions : MonoBehaviour
{
    public Transform cameraPlayer;
    public Transform objetoVacioCaja;
    public LayerMask lm;
    public GameObject armaPrincipal;
    public Transform objetoVacioArma;
    public float rayDistance;

    private void Update()
    {
        if (Input.GetButtonDown("e"))
        {
            if (objetoVacioCaja.childCount > 0)
            {
                objetoVacioCaja.GetComponentInChildren<Rigidbody>().isKinematic = false;
                objetoVacioCaja.DetachChildren();
                if (objetoVacioArma.childCount > 0)
                {
                    objetoVacioArma.GetChild(0).gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.DrawRay(cameraPlayer.position, cameraPlayer.forward * rayDistance, Color.green);
                if (Physics.Raycast(cameraPlayer.position, cameraPlayer.forward, out RaycastHit hit, rayDistance, lm))
                {
                    hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                    hit.transform.parent = objetoVacioCaja;
                    hit.transform.localPosition = Vector3.zero;
                    hit.transform.localRotation = Quaternion.identity;
                    if (objetoVacioArma.childCount > 0)
                    {
                        objetoVacioArma.GetChild(0).gameObject.SetActive(false);
                    }
                }
            }
        } }
    
    
     public Player_Stadistics player_Stadistics;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Puerta" && player_Stadistics.Battery_Count >= 4)
        {
            other.GetComponentInParent<Puerta>().OnOpenDoor();
        }
        if (other.tag == "Bateria")
        {
            other.GetComponentInParent<Script_Bateria>().OnGetBattery();
            player_Stadistics.Battery_Count++;
        }
        if (other.tag == "Arma")
        {
            other.transform.parent = objetoVacioArma;
            other.transform.localRotation = Quaternion.identity;
            other.transform.localPosition = Vector3.zero;
            if (objetoVacioCaja.childCount > 0)
            {
                other.gameObject.SetActive(false);
            }
        }
    }
      /*  if (Input.GetButtonDown("e"))
        {
            if (objetoVacioCaja.childCount > 0)
            {
                objetoVacioCaja.GetComponentInChildren<Rigidbody>().isKinematic = false;
                objetoVacioCaja.DetachChildren();
                if (objetoVacioCaja.childCount > 0)
                {
                    objetoVacioCaja.GetChild(0).gameObject.SetActive(true);
                }
            }
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(cameraPlayer.position, cameraPlayer.forward, out hit, 3f, lm))
                {
                    hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                    hit.transform.parent = objetoVacioCaja;
                    hit.transform.localPosition = Vector3.zero;
                    Debug.Log(hit.transform.name);
                    if (objetoVacioArma.childCount > 0)
                    {
                        objetoVacioArma.GetChild(0).gameObject.SetActive(false);
                    }
                }
            }
        }
        Debug.DrawRay(cameraPlayer.position, cameraPlayer.forward, Color.green);
    }
    
   */ 
}
