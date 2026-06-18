using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;

    [SerializeField] private int expToNextLevel = 100;

    private int currentExp;
    private int currentLevel = 1;

    [SerializeField] private ExperienceUI experienceUI;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        experienceUI.UpdateExp(
            currentExp,
            expToNextLevel,
            currentLevel);
    }

    public void AddExp(int amount)
    {
        currentExp += amount;

        while (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;

            LevelUp();
        }

        experienceUI.UpdateExp(
            currentExp,
            expToNextLevel,
            currentLevel);
    }

    private void LevelUp()
    {
        currentLevel++;

        expToNextLevel += 50;

        Debug.Log($"LEVEL UP! {currentLevel}");
    }
}