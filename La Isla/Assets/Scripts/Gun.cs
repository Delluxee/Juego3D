using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject prefab_bala;
    public Transform spawnPoint;
    public float force;
    public int CartuchoMax = 5;
    public int CartuchoActual;

    private void Start()
    {
        CartuchoActual = CartuchoMax;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && CartuchoActual > 0)
        {
            GameObject go = Instantiate(prefab_bala, spawnPoint.position, spawnPoint.rotation);
            go.GetComponent<Rigidbody>().AddForce(go.transform.forward * force, ForceMode.Impulse);
            Destroy(go, 2f);
            CartuchoActual--;
        }

        if (Input.GetButtonDown("Recargar"))
        {
            Reload();
        }
    }

    void Reload()
    {
        CartuchoActual = CartuchoMax;
    }
}
