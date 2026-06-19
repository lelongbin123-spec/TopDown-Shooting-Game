using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;

    [SerializeField] private int expToNextLevel = 100;

    private int currentExp;
    private int currentLevel = 1;

    [SerializeField] private ExperienceUI experienceUI;
    [SerializeField] private LevelUpUI levelUpUI;
    [SerializeField] private EnemySpawner enemySpawner;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddExp(int amount)
    {
        currentExp += amount;

        while (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;
            LevelUp();
        }

        UpdateUI();
    }

    private void LevelUp()
    {
        currentLevel++;

        expToNextLevel += 50;

        Debug.Log($"LEVEL UP! {currentLevel}");

        enemySpawner?.ReduceSpawnTime(0.5f);
        levelUpUI?.ShowLevelUp(currentLevel);
    }

    private void UpdateUI()
    {
        experienceUI?.UpdateExp(
            currentExp,
            expToNextLevel,
            currentLevel);
    }
}