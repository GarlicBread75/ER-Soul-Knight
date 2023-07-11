using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [SerializeField] GameObject[] portals;
    public bool portalsLocked = true;

    void FixedUpdate()
    {
        if (!portalsLocked)
        {
            for (int i = 0; i < portals.Length; i++)
            {
                portals[i].SetActive(true);
            }
        }
    }

    public void UnlockPortals()
    {
        portalsLocked = false;
    }
}
