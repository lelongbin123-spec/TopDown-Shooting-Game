using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3f;

    [Header("Attack")]
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackCooldown = 1f;

    private EnemyHealth enemyHealth;
    private Transform player;
    private IDamageable playerDamageable;
    private Rigidbody2D rb;

    private float nextAttackTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        FindPlayer();
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            FindPlayer();
            return;
        }

        // Đang bị knockback thì không chase
        if (enemyHealth != null &&
            enemyHealth.IsKnocked)
        {
            return;
        }

        float distance = Vector2.Distance(
            transform.position,
            player.position);

        if (distance <= attackRange)
        {
            rb.linearVelocity = Vector2.zero;
            Attack();
        }
        else
        {
            Chase();
        }
    }

    private void FindPlayer()
    {
        GameObject playerObj =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObj == null)
            return;

        player = playerObj.transform;
        playerDamageable =
            playerObj.GetComponent<IDamageable>();
    }

    private void Chase()
    {
        Vector2 direction =
            (player.position - transform.position).normalized;

        rb.linearVelocity = direction * moveSpeed;
    }

    private void Attack()
    {
        if (Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + attackCooldown;

        if (playerDamageable != null)
        {
            playerDamageable.TakeDamage(damage);

            Debug.Log(
                $"{gameObject.name} attacked player for {damage} damage");
        }
        else
        {
            Debug.LogWarning(
                "Player không có component IDamageable");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position,
            attackRange);
    }
}