using UnityEngine;

public class ColourChaser : MonoBehaviour
{
    [SerializeField] Material[] materials;
    MeshRenderer rend;

    void Awake()
    {
        rend = GetComponent<MeshRenderer>();
        rend.material = materials[Random.Range(0, materials.Length)];
        rend.material.SetFloat("_ShadowStep", Random.Range(0f, 0.7f));
        rend.material.SetFloat("_ShadowStepSmooth", Random.Range(0f, 0.1f));

        rend.material.SetFloat("_SpecularStep", Random.Range(0f, 1f));

        rend.material.SetFloat("_RimStep", Random.Range(0.7f, 1f));
        rend.material.SetFloat("_RimStepSmooth", Random.Range(0f, 1f));
        rend.material.SetColor("_RimStepColor", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));

        rend.material.SetFloat("_OutlineWidth", Random.Range(0f, 1f));
        rend.material.SetColor("_OutlineColor", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }
}
