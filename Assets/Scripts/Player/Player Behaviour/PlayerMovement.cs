using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    private Transform cameraTransform = default;

    private Rigidbody2D rb;

    //Movement Variables
    [SerializeField] private float movementForce = 10f; //To read movement values from Input
    [NonSerialized] public Vector3 movementVector = default; //to use With Rigidbody
    [NonSerialized] public bool isJumping = false;
    [NonSerialized] public bool isRunning = false;

    #endregion

    #region Monobehaviour
    private void OnEnable()
    {

    }

    private void OnDisable()
    {


    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up , ForceMode2D.Force);
        }
       
    }

    #endregion

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

