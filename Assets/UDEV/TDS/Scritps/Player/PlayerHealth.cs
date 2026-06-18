using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 100;

    private int currentHealth;

    private PlayerHealthUI healthUI;

    private PlayerFlash playerFlash;

    private void Awake()
    {
        currentHealth = maxHealth;

        playerFlash = GetComponent<PlayerFlash>();
    }

    private void Start()
    {
        healthUI = FindFirstObjectByType<PlayerHealthUI>();

        if (healthUI != null)
        {
            healthUI.UpdateHP(
                currentHealth,
                maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        currentHealth = Mathf.Clamp(
            currentHealth,
            0,
            maxHealth);

        playerFlash?.Flash();

        if (healthUI != null)
        {
            healthUI.UpdateHP(
                currentHealth,
                maxHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Game Over");
        gameObject.SetActive(false);
    }
}