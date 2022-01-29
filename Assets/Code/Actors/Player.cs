using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    private float moveSpeed = 500;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        int x = 0;
        if (InputController.IsPressed("MOVE_RIGHT"))
            x = 1;
        if (InputController.IsPressed("MOVE_LEFT"))
            x = -1;
        rigidBody.velocity = new Vector2(x * moveSpeed * Time.deltaTime, 0);
    }
}
