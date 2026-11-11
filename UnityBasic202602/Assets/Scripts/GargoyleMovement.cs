using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// ガーゴイルムーブメント
/// 
/// ガーゴイルの移動を行います
/// </summary>
public class GargoyleMovement : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 1f; // 回転速度
    [SerializeField] private float turnInterval = 4f; // 回転するまでの時間
    [SerializeField] private float targetRotationAmount = 90f; // 目標回転量

    private bool isFront = true; // 前かどうかのフラグ
    private bool isTurn = false; // 回転ができる状態かどうかのフラグ
    private float currentTurnSpeed = 0f; // 回転速度
    private float currentRotationAmount = 0f; // 現在の回転量
    private Vector3 rotation = new Vector3(0f, -90f, 0f); // オブジェクトの回転状況

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaitTurnInterval());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTurn)
        {
            return;
        }

        ApplyChange();
    }

    /// @brief 変更を反映します
    private void ApplyChange()
    {
        rotation.y += currentTurnSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(rotation);

        currentRotationAmount += currentTurnSpeed * Time.deltaTime;

        // 目標回転量を超えているため回転を停止します
        if(targetRotationAmount <= Mathf.Abs(currentRotationAmount))
        {
            isTurn = false;
            StartCoroutine(WaitTurnInterval());
        }
    }

    /// @brief 回転までの待機を行います
    private IEnumerator WaitTurnInterval()
    {
        yield return new WaitForSeconds(turnInterval);

        // 前を向いている場合は横向きの速度を設定
        // 横を向いている場合は前向きの速度を設定
        if(isFront)
        {
            isFront = false;
            currentTurnSpeed = turnSpeed;
        }
        else
        {
            isFront = true;
            currentTurnSpeed = -turnSpeed;
        }

        // 計測している回転量を初期化
        currentRotationAmount = 0f;
        isTurn = true;
    }
}
