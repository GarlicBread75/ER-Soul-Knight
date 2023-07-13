using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    TextMeshProUGUI counter;
    int coins = 0;

    void Start()
    {
        counter = GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        ShowCoins();
    }

    void ShowCoins()
    {
        counter.text = coins.ToString();
    }

    public void AddCoins(int num)
    {
        coins += num;
    }
}
