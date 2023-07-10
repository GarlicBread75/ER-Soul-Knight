using UnityEngine;

public class ColourChaser : MonoBehaviour
{
    [SerializeField] Material[] materials;
    MeshRenderer rend;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.material = materials[Random.Range(0, materials.Length)];
    }
}
