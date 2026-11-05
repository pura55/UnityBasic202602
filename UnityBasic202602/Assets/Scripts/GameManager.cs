using UnityEngine;
using StealthGame;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 firstPosition = new Vector3(0f, 0f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        
    }

    /// @brief ゲームオーバーを実行します
    public void ExecuteGameOver(Transform player)
    {
        player.position = firstPosition;
    }
}
