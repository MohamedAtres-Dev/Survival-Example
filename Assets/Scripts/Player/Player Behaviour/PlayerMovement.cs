using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    private Camera cam = default;
    private Rigidbody2D rb;

    [SerializeField] private InputHandler inputHandler = default;
    //Movement Variables
    [SerializeField] private float movementForce = 10f; //To read movement values from Input
    [NonSerialized] public Vector3 movementVector = default; //to use With Rigidbody
    [NonSerialized] public bool isJumping = false;
    [NonSerialized] public bool isRunning = false;
    private Vector2 mousePos;       // use this to get mouse pos
    [SerializeField] private Transform rotatePlayerGFX = default;
    #endregion

    #region Monobehaviour
    private void OnEnable()
    {
        inputHandler.moveVectorEvent += MoveWithVector;
    }

    private void OnDisable()
    {
        inputHandler.moveVectorEvent -= MoveWithVector;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        //Use this to make player rot. depend on mouse cursor
        Vector2 lookdir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;

        rotatePlayerGFX.localRotation = Quaternion.Slerp(rotatePlayerGFX.rotation, Quaternion.Euler(0f , 0f , angle), 0.2f);
        //rb.rotation = angle;
    }

    #endregion

    #region Methods
    private void MoveWithVector(Vector2 move)
    {
        transform.position += (Vector3)move * 0.5f;
    }
    #endregion


}

