using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーの動作を行います
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float walkSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float sensitivity = 0.2f;

    private Vector2 inputKeyDirection;
    private Vector2 inputPointerDirection;
    private Vector3 movement;
    private Vector3 viewpointMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement();

        ApplyViewpointMovement();
    }

    /// @brief 移動入力を受け付けます
    public void OnMove(InputAction.CallbackContext context)
    {
        //  入力がなくなったら、移動しない
        if (context.canceled)
        {
            inputKeyDirection = Vector2.zero;
            return;
        }

        inputKeyDirection = context.ReadValue<Vector2>();
    }

    /// @brief 視点移動入力を受け付けます
    public void OnLock(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            inputPointerDirection = Vector2.zero;
            return;
        }

        inputPointerDirection = context.ReadValue<Vector2>();
    }

    /// @brief 移動処理を反映します
    private void ApplyMovement()
    {
        //  入力情報から移動方向の単位ベクトルを算出
        movement.Set(inputKeyDirection.x, 0, inputKeyDirection.y);
        movement.Normalize();

        //  歩きアニメーション
        bool hasHorizontalInput = !Mathf.Approximately(inputKeyDirection.x, 0f);
        bool hasVerticalInput = !Mathf.Approximately(inputKeyDirection.y, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        animator.SetBool("IsWalking", isWalking);

        movement = transform.TransformDirection(movement.x, 0, movement.z);

        transform.localPosition += movement * walkSpeed * Time.deltaTime;
    }

    /// @brief 視点移動処理を反映します
    private void ApplyViewpointMovement()
    {
        viewpointMovement.y += inputPointerDirection.x * sensitivity;

        transform.rotation = Quaternion.Euler(viewpointMovement);
    }
}
