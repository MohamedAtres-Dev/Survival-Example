using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    private Transform cameraTransform = default;
    private Rigidbody2D rb;

    [SerializeField] private InputHandler inputHandler = default;
    //Movement Variables
    [SerializeField] private float movementForce = 10f; //To read movement values from Input
    [NonSerialized] public Vector3 movementVector = default; //to use With Rigidbody
    [NonSerialized] public bool isJumping = false;
    [NonSerialized] public bool isRunning = false;

    
    #endregion

    #region Monobehaviour
    private void OnEnable()
    {
        inputHandler.moveVectorEvent += MoveWithVector;
        inputHandler.moveUpEvent += MoveUp;
        inputHandler.moveDownEvent += MoveDown;
        inputHandler.moveRightEvent += MoveRight;
        inputHandler.moveLeftEvent += MoveLeft;
    }

    private void OnDisable()
    {
        inputHandler.moveVectorEvent -= MoveWithVector;
        inputHandler.moveUpEvent -= MoveUp;
        inputHandler.moveDownEvent -= MoveDown;
        inputHandler.moveRightEvent -= MoveRight;
        inputHandler.moveLeftEvent -= MoveLeft;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       
    }

    #endregion

    private void MoveWithVector(Vector2 move)
    {
        transform.position += (Vector3)move * 0.5f;
    }

    private void MoveUp()
    {
        rb.AddRelativeForce(Vector2.up * movementForce);
    }

    private void MoveDown()
    {
        rb.AddRelativeForce( - Vector2.up * movementForce);
    }

    private void MoveRight()
    {
        rb.AddRelativeForce(Vector2.right * movementForce);
    }

    private void MoveLeft()
    {
        rb.AddRelativeForce(- Vector2.right * movementForce);
    }

    //private void Move()
    //{
    //    float xInput = Input.GetAxis("Horizontal");
    //    float yInput = Input.GetAxis("Vertical");

    //    float xForce = xInput * movementForce * Time.deltaTime;
    //    float yForce = yInput * movementForce * Time.deltaTime;

    //    Vector2 force = new Vector2(xForce, yForce);

    //    rb.AddForce(force , ForceMode2D.Impulse);
    //}


}

