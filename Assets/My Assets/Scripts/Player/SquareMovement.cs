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
    Rigidbody rb;
    float moveX, moveZ;
    float ls;
    [SerializeField] float stamina;
    bool sprinting;

    [Space]

    [Header("Jumping")]
    [SerializeField] float jumpPower;
    [SerializeField] GameObject jumpParticles;
    bool jumpPressed;

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
        rb = GetComponent<Rigidbody>();
        ls = lerpSpeed;
        stamina = sprintStamina;
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
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, ls * Time.deltaTime);
        transform.position = smoothPos;

        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ls = sprintSpeed;
            sprinting = true;
        }
        else
        {
            ls = lerpSpeed;
            sprinting = false;
        }


        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (dead)
        {
            return;
        }

        // Sprinting
        if (sprinting)
        {
            stamina -= Time.deltaTime * 2;
        }
        else
        if (stamina < sprintStamina && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime;
        }

        // Jumping
        if (jumpPressed)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
            GameObject effect = Instantiate(jumpParticles, transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(effect, 1.1f);
            sounds[0].Invoke();
            jumpPressed = false;
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
