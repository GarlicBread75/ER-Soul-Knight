using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int maxHp;
    [SerializeField] int currentHp;
    //[SerializeField] Slider slider;

    [Space]

    [Header("Invulnerability")]
    [SerializeField] float invulnerableDuration;
    [SerializeField] int numberOfFlashes;
    [SerializeField] Material flashColor1;
    [SerializeField] Material flashColor2;


    [Space]

    [Header("Respawning")]
    [SerializeField] float respawnDelay;
    [SerializeField] Transform respawnPoint;

    [Space]

    [Header("Sounds")]
    [SerializeField] UnityEvent[] sounds;

    // Misc
    [SerializeField] Transform target;
    [SerializeField] Vector3 knockback;
    Vector3 direction;
    BoxCollider col;
    Rigidbody rb;
    MeshRenderer rend;
    Material originalMaterial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        rend = GetComponent<MeshRenderer>();
        currentHp = maxHp;
        originalMaterial = rend.material;
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

        direction.x = transform.position.x - target.position.x;
        direction.z = transform.position.z - target.position.z;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
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
        gameObject.SetActive(false);
    }

    IEnumerator Respawn()
    {
        Die();
        yield return new WaitForSeconds(respawnDelay);
    }

    IEnumerator Hit()
    {
        gameObject.layer = 11;
        rb.velocity = new Vector3(knockback.x * direction.x, knockback.y, knockback.z * direction.z);
        TakeDmg(1);
        StartCoroutine(InvulnerabilityFlash());
        yield return new WaitForSeconds(invulnerableDuration);
        gameObject.layer = 6;
    }

    IEnumerator InvulnerabilityFlash()
    {
        for (int i = 0; i <= numberOfFlashes; i++)
        {
            if (i % 2 == 0)
            {
                rend.material = flashColor1;
            }
            else
            {
                rend.material = flashColor2;
            }
            yield return new WaitForSeconds(invulnerableDuration/numberOfFlashes);
        }
        rend.material = originalMaterial;
    }
}