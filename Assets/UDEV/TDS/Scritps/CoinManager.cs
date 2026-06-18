using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    [SerializeField]
    private TMPro.TextMeshProUGUI coinText;

    private int coin;

    private void Awake()
    {
        Instance = this;
    }

    public void AddCoin(int amount)
    {
        coin += amount;

        coinText.text = coin.ToString();
        Debug.Log("Coin: " + coin);
    }
}