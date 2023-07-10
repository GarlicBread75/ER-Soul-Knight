using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    [SerializeField] string[] scenes;

    void OnTriggerEnter(Collider trigger)
    {
        SceneManager.LoadScene(scenes[Random.Range(0, scenes.Length)]);
    }
}
