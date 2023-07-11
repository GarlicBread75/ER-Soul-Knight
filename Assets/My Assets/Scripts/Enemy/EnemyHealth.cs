using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHp, currentHp;
    [SerializeField] Slider slider;

    void Start()
    {
        currentHp = maxHp;
        //slider.maxValue = maxHp;
        //slider.value = currentHp;
    }

    void FixedUpdate()
    {
        //slider.value = currentHp;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void TakeDmg(int dmg)
    {
        currentHp -= dmg;
    }

    void Heal(int heal)
    {
        currentHp += heal;
    }

    void RaiseMaxHp(int increase)
    {
        maxHp += increase;
        currentHp += increase;
    }

    void LowerMaxHp(int decrease)
    {
        maxHp += decrease;
        currentHp += decrease;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}