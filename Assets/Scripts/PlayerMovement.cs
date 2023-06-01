using System;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpDistance = 8f;
    [SerializeField] private float jumpHeight = 2f;

    private Collider collider;
    
    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    public void OnMoveUp(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded()) return;
        transform.position += new Vector3(0, jumpHeight, jumpDistance);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded()) return;
        transform.position += new Vector3(-jumpDistance, jumpHeight, 0);
        transform.eulerAngles = new Vector3(0, -90, 0);
    }

    public void OnMoveDown(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded()) return;
        transform.position += new Vector3(0, jumpHeight, -jumpDistance);
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded()) return;
        transform.position += new Vector3(jumpDistance, jumpHeight, 0);
        transform.eulerAngles = new Vector3(0, 90, 0);
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, collider.bounds.extents.y);
    }

    public float JumpDistance()
    {
        return jumpDistance;
    }
}