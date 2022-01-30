using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nian : Actor
{
    [SerializeField]
    private CharacterController characterController;
    private const float movementSpeed = 5;

    private void Update()
    {
        //if(Physics.Raycast(Vector3.down, transform.position + Vector3.right * 0.5f))
        characterController.Move(new Vector2(movementSpeed, Physics.gravity.y) * Time.deltaTime);
    }
}
