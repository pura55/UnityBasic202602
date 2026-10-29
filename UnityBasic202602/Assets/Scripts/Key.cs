using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    
    //  イベント宣言
    public static event Action<KeyType> OnKeyCollected;

    public static event Action<KeyType> OnShowGetKey;

    public static event Action<KeyType> OnHideGetKey;
    

    private void OnTriggerStay(Collider other)
    {
        //  侵入しているGameObjectがPlayerである場合、Keyを消す
        if(other.CompareTag("Player"))
        {
            OnShowGetKey?.Invoke(keyType);

            if(Keyboard.current.eKey.isPressed)
            {
                OnKeyCollected?.Invoke(keyType);    //  イベントの呼び出し
                OnHideGetKey?.Invoke(keyType);
                Destroy(gameObject);
            }
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        //  接触したGameObjectがPlayerである場合、Keyを消す
        if (other.CompareTag("Player"))
        {
            OnHideGetKey?.Invoke(keyType);
        }
    }
}   
