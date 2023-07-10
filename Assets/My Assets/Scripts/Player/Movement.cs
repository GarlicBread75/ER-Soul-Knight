using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] float lerpSpeed;
    float moveX, moveZ;

    [Space]

    [Header("Respawning")]
    [SerializeField] float respawnDelay;
    [SerializeField] Transform respawnPoint;
    [SerializeField] GameObject deathEffect;
    BoxCollider col;
    bool dead;

    [Space]

    [Header("Sounds")]
    [SerializeField] UnityEvent[] sounds;

    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (dead)
        {
            return;
        }

        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(moveX, 0, moveZ).normalized;
        Vector3 desiredPos = transform.position + moveDir;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, lerpSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }

    void FixedUpdate()
    {
        if (dead)
        {
            return;
        }
    }

    IEnumerator DieAndRespawn()
    {
        dead = true;
        //sounds[1].Invoke();
        col.enabled = false;
        // play death effect
        yield return new WaitForSeconds(respawnDelay);
        // destroy death effect
        transform.position = respawnPoint.position;
        col.enabled = true; 
        dead = false;
    }
}
