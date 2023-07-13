using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHp, currentHp;
    [SerializeField] Material flickerMat;
    [SerializeField] float flickerDuration;
    [SerializeField] UnityEvent thingy;
    MeshRenderer rend;
    Material originalMaterial;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        originalMaterial = rend.material;
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
            StartCoroutine(Hit());
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
        thingy.Invoke();
        Destroy(gameObject);
    }

    IEnumerator Hit()
    {
        TakeDmg(1);
        rend.material = flickerMat;
        yield return new WaitForSeconds(flickerDuration);
        rend.material = originalMaterial;
    }
}