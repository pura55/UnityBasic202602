using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// オーディオライフタイム
/// 
/// 音の生存時間を管理します
/// </summary>
public class AudioLifeTime : MonoBehaviour
{
    #region Config
    [SerializeField] private float lifeTime = 1f; // 生存時間
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaitLifeTime());
    }

    /// @brief 生存時間の待機を行います
    IEnumerator WaitLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }
}
