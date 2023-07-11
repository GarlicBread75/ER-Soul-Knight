using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    [SerializeField] string scene;

    void OnTriggerEnter(Collider trigger)
    {
        SceneManager.LoadScene(scene);
    }
}
