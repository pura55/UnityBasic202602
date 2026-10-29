using UnityEngine;
using TMPro;

public class ShowGetKey : MonoBehaviour
{
    [SerializeField] private GameObject keyImage;
    [SerializeField] private GameObject keyName;

    private TextMeshProUGUI keyText;

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        //  GameObjectが有効になったらKeyクラスのイベントを登録
        Key.OnShowGetKey += ShowPublic;
        Key.OnHideGetKey += ShowPrivate;

        keyText = keyName.GetComponent<TextMeshProUGUI>();
    }

    private void OnDisable()
    {
        //  GameObjectが無効になったらKeyクラスのイベントを削除
        Key.OnShowGetKey -= ShowPublic;
        Key.OnHideGetKey -= ShowPrivate;
    }

    private void ShowPublic(KeyType key)
    {
        keyImage.SetActive(true);
        keyText.text = key.ToString();
        keyName.SetActive(true);
    }

    private void ShowPrivate(KeyType key)
    {
        keyImage.SetActive(false);
        keyName.SetActive(false);
    }
}
