using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] float lerpSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float sprintStamina;
    [SerializeField] float turnSpeed;
    float moveX, moveZ;
    float ls;
    [SerializeField] float stamina;
    bool canSprint;

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
        ls = lerpSpeed;
        stamina = sprintStamina;
    }

    void Update()
    {
        if (dead)
        {
            return;
        }

        // Movement
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(moveX, 0, moveZ).normalized;
        Vector3 desiredPos = transform.position + moveDir;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, ls * Time.deltaTime);
        transform.position = smoothPos;

        if (moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }

        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            ls = sprintSpeed;
            canSprint = true;
        }
        else
        {
            ls = lerpSpeed;
            canSprint = false;
        }
    }

    void FixedUpdate()
    {
        if (dead)
        {
            return;
        }

        // Sprinting
        if (canSprint)
        {
            stamina -= Time.deltaTime * 2;
        }
        else
        if (stamina < sprintStamina)
        {
            stamina += Time.deltaTime;
        }
    }

    IEnumerator DieAndRespawn()
    {
        dead = true;
        sounds[1].Invoke();
        col.enabled = false;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));
        yield return new WaitForSeconds(respawnDelay);
        Destroy(effect, 1.1f);
        transform.position = respawnPoint.position;
        col.enabled = true; 
        dead = false;
    }
}
