using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    [SerializeField] private int maxfps;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = maxfps;
    }
}