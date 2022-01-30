using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nian : Actor
{
    [SerializeField]
    private CharacterController characterController;
    private const float movementSpeed = 5;

    protected override void Start()
    {
        base.Start();
        moveDirection = (transform.rotation.y == 0 ? MoveDirection.MoveRight : MoveDirection.MoveLeft);
    }

    ////private void OnCollisionEnter(Collision collision)
    //private void OnTriggerEnter(Collider other)
    //{
    //    print(other.transform);
    //    if (other.transform.tag == "Player")
    //        print("LoseHeart");
    //}

    private void Update()
    {
        characterController.Move(new Vector2(movementSpeed * (int)moveDirection, Physics.gravity.y) * Time.deltaTime);
        if (transform.localPosition.y < -1 || transform.position.x < -11.5f || transform.position.x > 11.5f)
            Destroy(gameObject);

    }
}
