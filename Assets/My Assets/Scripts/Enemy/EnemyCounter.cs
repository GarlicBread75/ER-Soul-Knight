using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] int enemyCount;
    [SerializeField] GameObject signetsMenu;

    private void FixedUpdate()
    {
        if (enemyCount == 0)
        {
            signetsMenu.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void AddEnemy()
    {
        enemyCount++;
    }

    public void RemoveEnemy()
    {
        enemyCount--;
    }
}
