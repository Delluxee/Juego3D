using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (MovementController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movimiento Cámara")]
    private Vector2 mouseMovement;
    public Camera playerCamera;
    private float RotacionCamaraX;
    private float RotacionCamaraY;
    private float RotacionPlayerY;
    public float SensibilidadDelRaton;

    [Header("MovementController")]
    public MovementController movement;
    public MovementController rotacion;

    private void Update()
    {
        //  Captura el movimiento del mouse 
        mouseMovement = new Vector2(Input.GetAxis("Mouse X") * SensibilidadDelRaton, Input.GetAxis("Mouse Y")* SensibilidadDelRaton);

        //Almacenar el movimiento del mouse
        RotacionCamaraX -= mouseMovement.y;
        RotacionCamaraY += mouseMovement.x;

        //Limitar la rotación de la cámara en el eje x
        RotacionCamaraX = Mathf.Clamp(RotacionCamaraX, -40, 40);

        //Rotar la cámara del personaje en base al movimiento acumulado
        playerCamera.transform.localRotation = Quaternion.Euler(RotacionCamaraX, 0, 0);

        movement.Move(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
        rotacion.Rotate(Input.GetAxis("Mouse X"));
    }
}
