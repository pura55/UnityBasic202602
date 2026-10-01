using UnityEngine;
using UnityEngine.InputSystem;

public class GhostMove : MonoBehaviour
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
        MoveForward();

        MoveBack();
    }

    private void MoveForward()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            transform.position += new Vector3(0, 0f, moveSpeed) * Time.deltaTime;
        }
    }

    private void MoveBack()
    {
        if (Keyboard.current.sKey.isPressed)
        {
            transform.position -= new Vector3(0, 0f, moveSpeed) * Time.deltaTime;
        }
    }
}
