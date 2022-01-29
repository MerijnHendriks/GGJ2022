using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    [SerializeField]
    private Transform model;
    [SerializeField]
    private Rigidbody2D rigidBody;
    private const float moveSpeed = 2000;
    private const float jumpSpeed = 2500;
    private Vector2 position;
    private Timer timer = new Timer();
    private Timer timer2 = new Timer();

    private bool isJumping;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        position = new Vector2(transform.position.x, transform.position.y);
        CheckInput();

        if (InputController.IsPressed("TEST"))
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.position = Vector2.zero;
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(position, Vector2.down, Color.green);
        if (Physics2D.Raycast(position + Vector2.right * 0.5f, Vector2.down, 1.1f))
            return true;
        if (Physics2D.Raycast(position + Vector2.left * 0.5f, Vector2.down, 1.1f))
            return true;
        return false;
    }

    private void CheckInput()
    {
        int x = 0;

        if (InputController.IsPressed("MOVE_RIGHT"))
        {
            x = 1;
            model.transform.rotation = Quaternion.identity;
        }
        if (InputController.IsPressed("MOVE_LEFT"))
        {
            x = -1;
            model.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (InputController.IsPressed("JUMP") && !isJumping && IsGrounded())
            StartCoroutine(Jump());

        rigidBody.velocity = new Vector2(x * moveSpeed * Time.deltaTime, position.y);
    }

    private IEnumerator Jump()
    {
        isJumping = true;
        timer.Set(0.3f);
        while (!timer.Done())
        {
            rigidBody.velocity += Vector2.up * jumpSpeed * Time.deltaTime;
            yield return null;
        }
        isJumping = false;
    }

    public void Teleport(Vector3 position)
    {
        //rigidBody.MovePosition(position);

        StartCoroutine(Teleporting(position));
    }

    private IEnumerator Teleporting(Vector3 position)
    {
        // rigidBody.position += Vector2.up * 3;//= position;
        //rigidBody.MovePosition(position);
        timer2.Set(1);
        while (!timer2.Done())
        {
            transform.position = position;
            rigidBody.velocity = Vector2.zero;
            yield return null;
        }

        rigidBody.simulated = true;
        print("Teleporting");
    }
}
