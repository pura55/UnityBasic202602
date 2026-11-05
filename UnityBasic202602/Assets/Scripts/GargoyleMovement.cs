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

    private bool isFront = false; // 前かどうかのフラグ
    private Vector3 rotation = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ApplyChange();
    }

    private void ApplyChange()
    {
        rotation.y += turnSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(rotation); ;
    }

    private IEnumerator CountTime()
    {
        yield return new WaitForSeconds(turnInterval);

        if(isFront)
        {
            isFront = false;
            rotation.y = 1f;
        }
        else
        {
            isFront = true;
            rotation.y = -1f;
        }
    }
}
