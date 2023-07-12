using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] float lerpSpeed;
    [SerializeField] float turnSpeed;
    float moveX, moveZ;
    float ls;

    [Space]

    [Header("Sounds")]
    [SerializeField] UnityEvent[] sounds;

    void Start()
    {
        ls = lerpSpeed;
    }

    void Update()
    {
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
    }
}
