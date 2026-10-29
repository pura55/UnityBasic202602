using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private string gameSceneName; // ゲームシーンの名前

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// @brief Startボタンが押された際の処理
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    /// @brief Quitボタンが押された際の処理
    public void OnQuitButtonClicked()
    {
#if UNITY_EDITOR
        // Unityエディターの再生を停止する場合
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ビルド後のアプリを終了する場合
        Application.Quit();
#endif
    }
}
