using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(1f, 100f)] private float maxSpeed = 10f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 10f;
    [SerializeField, Range(1f, 10f)] private float jumpHeight = 5f;
    private Vector3 velocity;
    private Vector3 desiredVelocity;
    //[SerializeField] private Rect allowedArea = new Rect(-5f, -5f, 10f, 10f);
    //[SerializeField, Range(0f, 1f)] private float bounciness = 0.5f;
    private Rigidbody body;
    private bool desiredJump;
    private bool onGround;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        //Vector3 desiredVelocity = new Vector3(playerInput.x, 0, playerInput.y) * maxSpeed;
        desiredVelocity = new Vector3(playerInput.x, 0, playerInput.y) * maxSpeed;
        //Vector3 displacement = velocity * Time.deltaTime;
        //Vector3 newPosition = transform.localPosition + displacement;
        //if(newPosition.x < allowedArea.xMin)
        //{
        //    newPosition.x = allowedArea.xMin;
        //    velocity.x = -velocity.x * bounciness;
        //}
        //else if(newPosition.x > allowedArea.xMax)
        //{
        //    newPosition.x = allowedArea.xMax;
        //    velocity.x = -velocity.x * bounciness;
        //}
        //else if(newPosition.z < allowedArea.yMin)
        //{
        //    newPosition.z = allowedArea.yMin;
        //    velocity.z = -velocity.z * bounciness;
        //}
        //else if(newPosition.z > allowedArea.yMax)
        //{
        //    newPosition.z = allowedArea.yMax;
        //    velocity.z = -velocity.z * bounciness;
        //}
        //transform.localPosition = newPosition;
        desiredJump |= Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        velocity = body.velocity;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        if (desiredJump)
        {
            desiredJump = false;
            Jump();
        }
        body.velocity = velocity;
        onGround = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }

    private void Jump()
    {
        if (onGround)
            velocity.y += math.sqrt(-2 * Physics.gravity.y * jumpHeight);
    }
}
