using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] int enemyCount;
    [SerializeField] UnityEvent onNoEnemiesLeft;

    private void FixedUpdate()
    {
        if (enemyCount <= 0)
        {
            onNoEnemiesLeft.Invoke();
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
