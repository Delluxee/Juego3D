using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]

public class EnemyController : MonoBehaviour
{
    public MovementController movement;
    public Transform jugador;
    public float rangeOfDetection = 15f;
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, jugador.position);
        if (distance <= rangeOfDetection)
        {
            Vector3 player = (transform.position - jugador.position).normalized;
            Vector3 forward = (transform.TransformDirection(Vector3.forward));

            if (Vector3.Dot(forward, player) < 0)
            {
                movement.Rotate(-0.95f);
            }

            if(Vector3.Dot(forward, player) > 0)
            {
                movement.Rotate(0.95f);
            }
            Debug.Log("Jugador Detectado");
           
            

            //Vector3.Dot(Vector3.forward);
           // movement.Move(1, 0);
        }
    }
}
