using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator swordAttack;

    void Start()
    {
        swordAttack = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackStart();
        }
    }

    public void AttackEnd()
    {
        gameObject.tag = "Untagged";
        swordAttack.SetBool("Attack", false);
    }

    public void AttackStart()
    {
        gameObject.tag = "Sword";
        swordAttack.SetBool("Attack", true);
    }
}
