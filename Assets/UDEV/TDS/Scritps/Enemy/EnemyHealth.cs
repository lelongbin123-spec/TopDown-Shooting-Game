using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 100;

    [Header("Health Bar")]
    [SerializeField] private Transform barSlide;

    [Header("Knockback")]
    [SerializeField] private float knockbackForce = 3f;
    [SerializeField] private float knockbackDuration = 0.15f;

    [Header("Drop")]
    [SerializeField] private GameObject coinPrefab;

    private int currentHealth;
    private Rigidbody2D rb;
    private bool isKnocked;

    public bool IsKnocked => isKnocked;

    private void Awake()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();

        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        currentHealth = Mathf.Clamp(
            currentHealth,
            0,
            maxHealth);

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Knockback(Vector2 direction)
    {
        StartCoroutine(KnockbackRoutine(direction));
    }

    private IEnumerator KnockbackRoutine(Vector2 direction)
    {
        isKnocked = true;

        rb.linearVelocity = Vector2.zero;

        rb.AddForce(
            direction * knockbackForce,
            ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);

        isKnocked = false;
    }

    private void UpdateHealthBar()
    {
        float percent =
            (float)currentHealth / maxHealth;

        barSlide.localScale =
            new Vector3(percent, 1f, 1f);

        barSlide.localPosition =
            new Vector3(-(1f - percent) / 2f, 0f, 0f);
    }

    private void Die()
    {
        Instantiate(
            coinPrefab,
            transform.position,
            Quaternion.identity);

        Destroy(gameObject);
    }
}