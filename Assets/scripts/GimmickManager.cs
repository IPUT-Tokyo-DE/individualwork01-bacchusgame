using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    public GameObject bowGenerator;       // 弓ジェネレーター
    public GameObject bowGenerator2;       // 弓ジェネレーター
    public GameObject bowGenerator3;       // 弓ジェネレーター
    public GameObject laserGenerator;     // レーザージェネレーター
    public GameObject laserGenerator2;     // レーザージェネレーター
    public GameObject laserGenerator3;     // レーザージェネレーター
    public GameObject sawGenerator;       // のこぎりジェネレーター

    private int lastLevel = 0; // 最後に確認したレベル

    private void Start()
    {
        UpdateGenerators(); // 最初に一度チェック
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.CurrentState == GameManager.GameState.Playing)
        {
            if (lastLevel != GameManager.Instance.CurrentLevel)
            {
                UpdateGenerators();
            }
        }
    }

    private void UpdateGenerators()
    {
        int level = GameManager.Instance.CurrentLevel;
        lastLevel = level;

        // レベルに応じて、過去分もアクティブにする
        if (level >= 1 && bowGenerator != null)
        {
            bowGenerator.SetActive(true);
        }
        if (level >= 2 && laserGenerator != null)
        {
            laserGenerator.SetActive(true);
        }
        if (level >= 3 && sawGenerator != null)
        {
            bowGenerator2.SetActive(true);
            sawGenerator.SetActive(true);
        }
        if (level >= 4 && laserGenerator2 != null)
        {
            laserGenerator2.SetActive(true);
        }
        if (level >= 5 && laserGenerator3 != null)
        {
            laserGenerator3.SetActive(true);
        }

        if (level >= 6 && bowGenerator3 != null)
        {
            bowGenerator3.SetActive(true);
        }
    }
}
