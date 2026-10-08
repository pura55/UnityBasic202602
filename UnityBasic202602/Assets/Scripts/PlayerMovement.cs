using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    //[SerializeField] private float  = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            transform.position += new Vector3(0, 0f, moveSpeed) * Time.deltaTime;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            transform.position -= new Vector3(0, 0f, moveSpeed) * Time.deltaTime;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position -= new Vector3(moveSpeed, 0f, 0) * Time.deltaTime;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime;
        }
    }

    private void Rotation()
    {
        if (Mouse.current != null)
        {
            float myRotate = Pointer.
        }
    }
}
