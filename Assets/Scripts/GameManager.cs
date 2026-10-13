using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("ÉQÅ[ÉÄê›íË")]
    [SerializeField] private float gameTime = 60f;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TextMeshProUGUI resultText;

    [SerializeField] private EnemySpawner enemySpawner;

    private float remainingTime;
    private bool isGameFinished = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        remainingTime = gameTime;
        resultPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameFinished) return;

        remainingTime -= Time.deltaTime;

        remainingTime = Mathf.Max(remainingTime, 0f);

        timerText.text = Mathf.CeilToInt(remainingTime).ToString();

        if (remainingTime <= 0f)
        {
            GameClear();
            return;
        }

        enemySpawner.CheckSpawn(remainingTime);
    }

    public void GameOver()
    {
        if (isGameFinished) return;

        isGameFinished = true;

        resultPanel.SetActive(true);
        resultText.text = "GAME OVER";

        Time.timeScale = 0f;
    }

    public void GameClear()
    {
        if (isGameFinished) return;

        isGameFinished = true;

        resultPanel.SetActive(true);
        resultText.text = "GAME CLEAR!";

        Time.timeScale = 0f;
    }
}
