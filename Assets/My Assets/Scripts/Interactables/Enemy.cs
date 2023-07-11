using UnityEngine;

public class ColourChaser : MonoBehaviour
{
    [SerializeField] float maxHp;
    [SerializeField] float currentHp;
    [SerializeField] GameObject deathEffect;
    void Start()
    {
        currentHp = maxHp;
    }

    void FixedUpdate()
    {
        if (currentHp <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.1f);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "mechKatana")
        {
            currentHp--;
        }
    }
}
