using UnityEngine;
using StealthGame;
using System.Collections;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 firstPosition = new Vector3(0f, 0f, 0f); // 初期値
    [SerializeField] private GameObject playerPrefab; // プレイヤーのプレハブ
    [SerializeField] private Transform generateTransform; // 生成場所のトランスフォーム

    private GameObject instancePlayer; // 生成プレイヤー

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstPosition = generateTransform.position;
        GeneratePlayer();
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        
    }

    private void GeneratePlayer()
    {
        instancePlayer = Instantiate(playerPrefab, firstPosition, Quaternion.identity);
    }

    /// @brief ゲームオーバーを実行します
    public void ExecuteGameOver()
    {
        instancePlayer.transform.position = firstPosition;
    }
}
