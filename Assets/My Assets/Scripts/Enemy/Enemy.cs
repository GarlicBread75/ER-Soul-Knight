using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] Material[] materials;

    [SerializeField] float maxHp;
    [SerializeField] float currentHp;
    [SerializeField] GameObject deathEffect;

    [SerializeField] UnityEvent[] events;

    void Start()
    {
        GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
        currentHp = maxHp;
        events[0].Invoke();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (currentHp <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.1f);
            events[1].Invoke();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            currentHp--;
        }
    }
}
