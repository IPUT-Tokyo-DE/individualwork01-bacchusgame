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
        // �V�[�������[�h���ꂽ�玩���Ŋ֐��Ăяo��
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // �����ƃ��X�i�[�����i���������[�N�h�~�j
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (resultUI != null)
        {
            resultUI.SetActive(false); // �V�[�����[�h����Ƀ��U���gUI���\��
        }

        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners(); // ��x���X�i�[�����Z�b�g
            playButton.onClick.AddListener(OnPlayButtonClicked);
        }
        // �����ǉ��I�I�I
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
