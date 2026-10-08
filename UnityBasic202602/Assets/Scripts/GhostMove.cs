using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GhostMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float interval = 5f;
    [SerializeField] private float rotationSpeed = 30f;
    private float rotate = 0;
    //[SerializeField] private float  = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Rotation();
    }

    private void Move()
    {
        float cos = Mathf.Cos(Time.time * interval);
        transform.position += new Vector3(0, 0f, moveSpeed) * cos * Time.deltaTime;
    }

    private void Rotation()
    {
        rotate = Time.time * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, rotate, 0);
    }
}
