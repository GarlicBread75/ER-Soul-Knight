using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int maxHp, currentHp;
    [SerializeField] GameObject deathEffect;
    [SerializeField] GameObject hitEffect;
    //[SerializeField] Slider slider;

    [Space]

    [Header("Respawning")]
    [SerializeField] float respawnDelay;
    [SerializeField] Transform respawnPoint;
    BoxCollider col;

    [Space]

    [Header("Sounds")]
    [SerializeField] UnityEvent[] sounds;

    void Start()
    {
        col = GetComponent<BoxCollider>();
        currentHp = maxHp;
        //slider.maxValue = maxHp;
        //slider.value = currentHp;
    }

    void FixedUpdate()
    {
        //slider.value = currentHp;

        if (currentHp <= 0)
        {
            StartCoroutine(Respawn());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            TakeDmg(1);
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
        sounds[1].Invoke();
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2);
        gameObject.SetActive(false);
    }

    IEnumerator Respawn()
    {
        sounds[1].Invoke();
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
        //gameObject.SetActive(false);
         yield return new WaitForSeconds(respawnDelay);
        transform.position = respawnPoint.position;
        //gameObject.SetActive(true);
    }
}