using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public GameObject resultUI;
    public TextMeshProUGUI resultText;
    public Button playButton;

    private bool isInitialized = false;

    private void Awake()
    {
        // シーンがロードされたら自動で関数呼び出し
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // ちゃんとリスナー解除（メモリリーク防止）
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (resultUI != null)
        {
            resultUI.SetActive(false); // シーンロード直後にリザルトUIを非表示
        }

        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners(); // 一度リスナーをリセット
            playButton.onClick.AddListener(OnPlayButtonClicked);
        }
        // ここ追加！！！
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeState(GameManager.GameState.Playing);
        }
        isInitialized = true;
    }

    private void Update()
    {
        if (!isInitialized || resultUI == null || resultText == null)
        {
            return;
        }

        if (GameManager.Instance != null && GameManager.Instance.CurrentState == GameManager.GameState.Result)
        {
            if (!resultUI.activeSelf)
            {
                resultUI.SetActive(true);
                resultText.text =
                    $"High Score: {GameManager.Instance.HighScore}\n" +
                    $"Score: {GameManager.Instance.Score}";
            }
        }
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
