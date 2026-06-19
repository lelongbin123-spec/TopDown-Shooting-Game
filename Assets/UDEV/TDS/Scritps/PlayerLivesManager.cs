using UnityEngine;

public class PlayerLivesManager : MonoBehaviour
{
    public static PlayerLivesManager Instance;

    [SerializeField] private int maxLives = 3;

    private int currentLives;

    [SerializeField] private LivesUI livesUI;

    public int CurrentLives => currentLives;

    private void Awake()
    {
        Instance = this;
        currentLives = maxLives;
    }

    private void Start()
    {
        livesUI.UpdateLives(currentLives);
    }

    public void LoseLife()
    {
        currentLives--;

        livesUI.UpdateLives(currentLives);

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER");

        Time.timeScale = 0f;
    }
}