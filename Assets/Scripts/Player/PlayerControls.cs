using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Creatures
{
    [SerializeField] private float BaseSpeed = 10f;
    [SerializeField] private float SprintSpeed = 5f;
    private float speedMovement;
    private AnimationParamHandler _animationParamHandler;

    public Vector2 Direction { get; private set; }
    public Vector2 LastNonZeroDir { get; private set; }
    private void Update()
    {
        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        if (input != Vector2.zero)
            LastNonZeroDir = input.normalized;

        Direction = input.normalized;

        speedMovement = Input.GetKey(KeyCode.LeftShift)
            ? BaseSpeed + SprintSpeed
            : BaseSpeed;

        _animationParamHandler.SetDirAndIsMoving(Direction);
    }
    private void Start()
    {
        speedMovement = BaseSpeed;
       // LastNonZeroDir = Vector2.right;
    }
    protected override void Awake()
    {
        base.Awake();
        _animationParamHandler = GetComponent<AnimationParamHandler>();
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + Direction * (speedMovement * Time.fixedDeltaTime));
    }
}