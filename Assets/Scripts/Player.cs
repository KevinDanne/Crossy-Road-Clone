using System;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpDistance = 8f;
    [SerializeField] private float _jumpHeight = 1f;

    private Collider _collider;
    
    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public void OnMoveUp(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded()) return;
        transform.position += new Vector3(0, _jumpHeight, _jumpDistance);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded()) return;
        transform.position += new Vector3(-_jumpDistance, _jumpHeight, 0);
        transform.eulerAngles = new Vector3(0, -90, 0);
    }

    public void OnMoveDown(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded()) return;
        transform.position += new Vector3(0, _jumpHeight, -_jumpDistance);
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded()) return;
        transform.position += new Vector3(_jumpDistance, _jumpHeight, 0);
        transform.eulerAngles = new Vector3(0, 90, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Vehicle"))
        {
            GameManager.Instance.GameOver();
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, _collider.bounds.extents.y);
    }

    public float JumpDistance()
    {
        return _jumpDistance;
    }
}