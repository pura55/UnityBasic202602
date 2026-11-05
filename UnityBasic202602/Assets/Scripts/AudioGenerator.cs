using UnityEngine;

/// <summary>
/// オーディオジェネレーター
/// 
/// 
/// 音の生成処理を行います
/// </summary>
public class AudioGenerator : MonoBehaviour
{
    [SerializeField] private GameObject generatedSound; // 生成する音
  
    // Update is called once per frame
    void Update()
    {
        
    }

    /// @brief 音を生成します
    public void GenerateSound()
    {
        Instantiate(generatedSound);
    }
}
