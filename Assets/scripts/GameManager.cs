using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Title,
        Playing,
        Result
    }

    public static GameManager Instance;

    public GameState CurrentState { get; private set; } = GameState.Playing;
    public int Score { get; private set; } = 0;
    public int HighScore { get; private set; } = 0;

    public int CurrentLevel { get; private set; } = 1; // 現在のレベル（1～5）

    public int maxLevel = 5; // 最大レベル（5）

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Score = 0;
        CurrentLevel = 1; // スタート時はレベル1
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;

        if (newState == GameState.Title)
        {
            Score = 0;
            CurrentLevel = 1;
        }
        else if (newState == GameState.Playing)
        {
            Score = 0;
            CurrentLevel = 1;
        }
        else if (newState == GameState.Result)
        {
            if (Score > HighScore)
            {
                HighScore = Score;
            }
        }
    }

    public void AddScore(int amount)
    {
        Score += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        // 例：スコアに応じてレベルアップ（あとで細かく調整できる）
        if (Score >= 600 && CurrentLevel < 6)
        {
            CurrentLevel = 6;
        }
        else if (Score >= 400 && CurrentLevel < 5)
        {
            CurrentLevel = 5;
        }
        else if (Score >= 300 && CurrentLevel < 4)
        {
            CurrentLevel = 4;
        }
        else if (Score >= 200 && CurrentLevel < 3)
        {
            CurrentLevel = 3;
        }
        else if (Score >= 100 && CurrentLevel < 2)
        {
            CurrentLevel = 2;
        }
    }
}
