using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 100;

    private int currentHealth;

    private PlayerHealthUI healthUI;

    private PlayerFlash playerFlash;

    [SerializeField] private Transform graphic;
    [SerializeField] private float respawnDelay = 2f;

    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;
    private PlayerController playerController;

    private bool isDead;


    private void Awake()
    {
        currentHealth = maxHealth;

        playerFlash = GetComponent<PlayerFlash>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
        playerController = GetComponent<PlayerController>();
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
        if (isDead)
            return;

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
            isDead = true;
            StartCoroutine(RespawnRoutine());
        }
    }

    /*private void Die()
    {
        PlayerLivesManager.Instance.LoseLife();

        currentHealth = maxHealth;

        healthUI.UpdateHP(
            currentHealth,
            maxHealth);

        transform.position = Vector3.zero;
    }*/

    private IEnumerator RespawnRoutine()
    {
        PlayerLivesManager.Instance.LoseLife();

        graphic.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        currentHealth = maxHealth;

        transform.position = Vector3.zero;

        healthUI.UpdateHP(
            currentHealth,
            maxHealth);

        graphic.gameObject.SetActive(true);

        isDead = false;
    }
}