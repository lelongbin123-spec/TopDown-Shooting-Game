using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;

    [SerializeField] private int expValue = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        CoinManager.Instance.AddCoin(value);

        ExperienceManager.Instance.AddExp(expValue);

        Destroy(gameObject);
    }
}