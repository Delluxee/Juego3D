using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject platform;

    public Transform minPosition;
    public Transform maxPosition;

    public float speedMovement;

    private void OnTriggerStay(Collider other)
    {
        if (other != null)
        {
            MovePlatform();
        }
    }
    private void MovePlatform()
    {
        platform.transform.Translate(Vector3.up * Time.deltaTime * speedMovement);

        if (platform.transform.position.y >= maxPosition.position.y && speedMovement > 0)
        {
            speedMovement = speedMovement * -1;
        }
        if (platform.transform.position.y <= minPosition.position.y && speedMovement < 0)
        {
            speedMovement = speedMovement * -1;
        }
    }
}

