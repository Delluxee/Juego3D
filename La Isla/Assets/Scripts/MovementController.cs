using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Movimiento del personaje")]
    public float speedMovement;
    public Vector3 Direccion;
    public CharacterController controller;

    [Header("Salto del personaje")]
    public Vector3 MovementY;
    public float gravity = -9.8f;
    public float jumpHeight;

    [Header("Rotacion")]
    public float rotacionPlayerY;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        //Calcular la gravedad en cada frame
        MovementY.y += gravity * Time.deltaTime;

        //Mover el personaje en Y en base a la gravedad calculada
        controller.Move(MovementY * Time.deltaTime);

        //Si el personaje está tocando el suelo y al presionar la tecla, calcular el salto del personaje
        if (controller.isGrounded && MovementY.y < 0)
        {
            MovementY.y = -2f;
        }

        //Si el personaje está tocando el suelo y al presionar la tecla , calcular el salto del personaje
        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            MovementY.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }          
    }

    public void Move(float vertical, float horizontal)
    {
        //Captura los valores del análogo del mouse
        Direccion.x = horizontal;
        Direccion.z = vertical;

        //Transforma dirección a coordenadas del jugador
        Direccion = transform.TransformDirection(Direccion);

        //Mover al jugador en base a los inputs
        controller.Move(Direccion * Time.deltaTime * speedMovement);
    }
    
    public void Rotate(float rotateValue)
    {
        rotacionPlayerY += rotateValue;

        //Rotar el personaje en base al movimiento acumulado
        controller.transform.localRotation = Quaternion.Euler(0, rotacionPlayerY, 0);

    }
}
