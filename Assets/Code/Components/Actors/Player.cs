using System.Collections;
using UnityEngine;

public class Player : Actor
{
    [SerializeField]
    private Transform model;
    [SerializeField]
    private CharacterController rigidBody;
    private const float moveSpeed = 10;
    private const float jumpSpeed = 25f;
    private Vector2 position;
    private Timer timer = new Timer();
    private Timer timer2 = new Timer();

    float jumpForce = 0;

    private bool isJumping;

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

        if (InputController.IsPressed("RIGHT"))
        {
            x = 1;
            model.transform.rotation = Quaternion.identity;
        }
        if (InputController.IsPressed("LEFT"))
        {
            x = -1;
            model.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (InputController.IsPressed("JUMP") && !isJumping && rigidBody.isGrounded)
            StartCoroutine(Jump());

        rigidBody.Move(new Vector3(x * moveSpeed, isJumping ? Physics.gravity.y + jumpSpeed : Physics.gravity.y , 0) * Time.deltaTime);
    }

    private IEnumerator Jump()
    {
        isJumping = true;
        timer.Set(0.3f);
        while (!timer.Done())
            yield return null;
        isJumping = false;
    }

    public void Teleport(Vector3 position)
    {
        StartCoroutine(Teleporting(position));
        transform.position = position;
    }

    private IEnumerator Teleporting(Vector3 position)
    {
        rigidBody.enabled = false;
        transform.position = position;
        yield return new WaitForSeconds(0.1f);
        rigidBody.enabled = true;
    }
}
