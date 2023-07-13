using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthArmour : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int maxHp;
    [SerializeField] int currentHp;
    [SerializeField] Slider hpSlider;

    [Space]

    [Header("Armour")]
    [SerializeField] int maxArmour;
    [SerializeField] int currentArmour;
    [SerializeField] Slider armourSlider;
    [SerializeField] float regenerationCd;
    [SerializeField] float regenCd;
    [SerializeField] bool canRegen;
    bool shieldBroken;

    [Space]

    [Header("Invulnerability")]
    [SerializeField] float invulnerableDuration;
    [SerializeField] int numberOfFlashes;
    [SerializeField] Material flashColor1;
    [SerializeField] Material flashColor2;
    [SerializeField] Vector3 knockback;
    MeshRenderer rend;
    Rigidbody rb;
    Material originalMaterial;


    [Space]

    [Header("Respawning")]
    [SerializeField] float respawnDelay;
    [SerializeField] Transform respawnPoint;

    [Space]

    [Header("Sounds")]
    [SerializeField] UnityEvent[] sounds;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<MeshRenderer>();
        originalMaterial = rend.material;

        currentHp = maxHp;
        currentArmour = maxArmour;

        hpSlider.maxValue = maxHp;
        hpSlider.value = currentHp;
        armourSlider.maxValue = maxArmour;
        armourSlider.value = currentArmour;

        regenCd = regenerationCd;
        StartCoroutine(RegenArmour());
    }

    void FixedUpdate()
    {
        hpSlider.value = currentHp;
        armourSlider.value = currentArmour;

        if (currentArmour == 0)
        {
            shieldBroken = true;
        }
        else
        if (currentArmour > 0)
        {
            shieldBroken = false;
        }

        if (currentHp <= 0)
        {
            StartCoroutine(Respawn());
        }

        if (currentArmour < maxArmour)
        {
            if (regenCd > 0)
            {
                regenCd -= Time.fixedDeltaTime;
            }
            else
            {
                canRegen = true;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float directionX = transform.position.x - collision.transform.position.x;
            float directionZ = transform.position.z - collision.transform.position.z;

            rb.velocity = new Vector3(knockback.x * directionX, knockback.y, knockback.z * directionZ);
            if (shieldBroken)
            {
                TakeDmg(1);
            }
            else
            {
                TakeArmourDmg(1);
            }
            StartCoroutine(Hit());
        }
    }

    #region HitPoints
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

    void TakeArmourDmg(int dmg)
    {
        currentArmour -= dmg;
    }

    void HealArmour(int heal)
    {
        currentArmour += heal;
    }

    void RaiseMaxArmour(int increase)
    {
        maxArmour += increase;
        currentArmour += increase;
    }

    void LowerMaxArmour(int decrease)
    {
        maxArmour += decrease;
        currentArmour += decrease;
    }
    #endregion

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
        regenCd = regenerationCd;
        gameObject.layer = 11;
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

    IEnumerator RegenArmour()
    {
        while (true)
        {
            if (canRegen)
            {
                if (currentArmour < maxArmour)
                {
                    yield return new WaitForSeconds(1);
                    currentArmour++;
                }
                else
                {
                    canRegen = false;
                    regenCd = regenerationCd;
                    yield return null;
                }
            }
            else
            {
                yield return null;
            }
        }
    }
}