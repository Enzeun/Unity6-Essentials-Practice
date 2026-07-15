using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    private float speed = 8f;
    private Vector2 moveInput;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3 (moveInput.x, 0, moveInput.y);
        rb.linearVelocity = moveDirection * speed;
    }
    void Update()
    {
        moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

}
