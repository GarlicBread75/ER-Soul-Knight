using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    TextMeshProUGUI counter;
    int kills = 0;

    void Start()
    {
        counter = GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        ShowKills();
    }

    void ShowKills()
    {
        counter.text = kills.ToString();
    }

    public void AddKill()
    {
        kills++;
    }
}
