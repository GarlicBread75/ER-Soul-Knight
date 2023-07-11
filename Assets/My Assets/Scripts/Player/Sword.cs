using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator swordAttack;
    BoxCollider col;

    void Start()
    {
        swordAttack = GetComponent<Animator>();
        col = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swordAttack.SetBool("Attack", true);
        }
    }

    public void AttackEnd()
    {
        swordAttack.SetBool("Attack", false);
    }

    public void EnableCollider()
    {
        col.enabled = true;
    }

    public void DisableCollider()
    {
        col.enabled = false;
    }
}
