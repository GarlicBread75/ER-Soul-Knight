using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHp, currentHp;
    [SerializeField] GameObject[] deathEffects;
    [SerializeField] GameObject hitEffect;

    void Start()
    {
        currentHp = maxHp;
    }

    void FixedUpdate()
    {
        if (currentHp <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Sword"))
        {
            TakeDmg(1);

            if (currentHp > 1)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.5f);
            }
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
        GameObject effect = Instantiate(deathEffects[Random.Range(0, deathEffects.Length)], transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }
}