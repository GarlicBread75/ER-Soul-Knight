using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour
{
    #region Variables

    [Header("Customization")]
    [Space]
    [SerializeField] Mesh[] meshes;

    [Space]

    [SerializeField] Slider red;
    [SerializeField] Slider green;
    [SerializeField] Slider blue;

    [Space]

    [SerializeField] Slider shadowStep;
    [SerializeField] Slider shadowStepSmooth;

    [Space]

    [SerializeField] Slider specularStep;
    [SerializeField] Slider specularStepSmooth;
    [SerializeField] Slider specularColourR;
    [SerializeField] Slider specularColourG;
    [SerializeField] Slider specularColourB;

    [Space]

    [SerializeField] Slider rimStep;
    [SerializeField] Slider rimStepSmooth;
    [SerializeField] Slider rimColourR;
    [SerializeField] Slider rimColourG;
    [SerializeField] Slider rimColourB;

    [Space]

    [SerializeField] Slider outlineWidth;
    [SerializeField] Slider outlineColourR;
    [SerializeField] Slider outlineColourG;
    [SerializeField] Slider outlineColourB;

    // Misc
    Renderer rend;
    MeshFilter meshFilter;
    int num = 1;

    #endregion

    #region Customization

    void Start()
    {
        rend = GetComponent<Renderer>();
        meshFilter = GetComponent<MeshFilter>();

        red.value = rend.material.GetColor("_BaseColor").r;
        green.value = rend.material.GetColor("_BaseColor").g;
        blue.value = rend.material.GetColor("_BaseColor").b;

        shadowStep.value = rend.material.GetFloat("_ShadowStep");
        shadowStepSmooth.value = rend.material.GetFloat("_ShadowStepSmooth");

        specularStep.value = rend.material.GetFloat("_SpecularStep");
        specularStepSmooth.value = rend.material.GetFloat("_SpecularStepSmooth");
        specularColourR.value = rend.material.GetColor("_SpecularColor").r;
        specularColourG.value = rend.material.GetColor("_SpecularColor").g;
        specularColourB.value = rend.material.GetColor("_SpecularColor").b;

        rimStep.value = rend.material.GetFloat("_RimStep");
        rimStepSmooth.value = rend.material.GetFloat("_RimStepSmooth");
        rimColourR.value = rend.material.GetColor("_RimColor").r;
        rimColourG.value = rend.material.GetColor("_RimColor").g;
        rimColourB.value = rend.material.GetColor("_RimColor").b;

        outlineWidth.value = rend.material.GetFloat("_OutlineWidth");
        outlineColourR.value = rend.material.GetColor("_OutlineColor").r;
        outlineColourG.value = rend.material.GetColor("_OutlineColor").g;
        outlineColourB.value = rend.material.GetColor("_OutlineColor").b;
    }

    void FixedUpdate()
    {
        SetMaterialValues();
    }

    void SetColour()
    {
        rend.material.SetColor("_BaseColor", new Color(red.value, green.value, blue.value));
    }

    void SetShadowStep()
    {
        rend.material.SetFloat("_ShadowStep", shadowStep.value);
        rend.material.SetFloat("_ShadowStepSmooth", shadowStepSmooth.value);
    }

    void SetSpecularStep()
    {
        rend.material.SetFloat("_SpecularStep", specularStep.value);
        rend.material.SetFloat("_SpecularStepSmooth", specularStepSmooth.value);
        rend.material.SetColor("_SpecularColor", new Color(specularColourR.value, specularColourG.value, specularColourB.value));
    }

    void SetRimStep()
    {
        rend.material.SetFloat("_RimStep", rimStep.value);
        rend.material.SetFloat("_RimStepSmooth", rimStepSmooth.value);
        rend.material.SetColor("_RimColor", new Color(rimColourR.value, rimColourG.value, rimColourB.value));
    }

    void SetOutline()
    {
        rend.material.SetFloat("_OutlineWidth", outlineWidth.value);
        rend.material.SetColor("_OutlineColor", new Color(outlineColourR.value, outlineColourG.value, outlineColourB.value));
    }

    void SetMaterialValues()
    {
        SetColour();
        SetShadowStep();
        SetSpecularStep();
        SetRimStep();
        SetOutline();
    }

    public void ChangeMesh()
    {
        meshFilter.mesh = meshes[num];
        num++;

        if (num >= meshes.Length)
        {
            num = 0;
        }
    }

    public void Randomize()
    {
        red.value = Random.Range(0f, 1f);
        green.value = Random.Range(0f, 1f);
        blue.value = Random.Range(0f, 1f);

        shadowStep.value = Random.Range(0f, 1f);
        shadowStepSmooth.value = Random.Range(0f, 1f);

        specularStep.value = Random.Range(0f, 1f);
        specularStepSmooth.value = Random.Range(0f, 1f);
        specularColourR.value = Random.Range(0f, 1f);
        specularColourG.value = Random.Range(0f, 1f);
        specularColourB.value = Random.Range(0f, 1f);

        rimStep.value = Random.Range(0f, 1f);
        rimStepSmooth.value = Random.Range(0f, 1f);
        rimColourR.value = Random.Range(0f, 1f);
        rimColourG.value = Random.Range(0f, 1f);
        rimColourB.value = Random.Range(0f, 1f);

        outlineWidth.value = Random.Range(0f, 1f);
        outlineColourR.value = Random.Range(0f, 1f);
        outlineColourG.value = Random.Range(0f, 1f);
        outlineColourB.value = Random.Range(0f, 1f);
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("red", red.value);
        PlayerPrefs.SetFloat("green", green.value);
        PlayerPrefs.SetFloat("blue", blue.value);

        PlayerPrefs.SetFloat("shadowStep", shadowStep.value);
        PlayerPrefs.SetFloat("shadowStepSmooth", shadowStepSmooth.value);

        PlayerPrefs.SetFloat("specularStep", specularStep.value);
        PlayerPrefs.SetFloat("specularStepSmooth", specularStepSmooth.value);
        PlayerPrefs.SetFloat("specularColourR", specularColourR.value);
        PlayerPrefs.SetFloat("specularColourG", specularColourG.value);
        PlayerPrefs.SetFloat("specularColourB", specularColourB.value);

        PlayerPrefs.SetFloat("rimStep", rimStep.value);
        PlayerPrefs.SetFloat("rimStepSmooth", rimStepSmooth.value);
        PlayerPrefs.SetFloat("rimColourR", rimColourR.value);
        PlayerPrefs.SetFloat("rimColourG", rimColourG.value);
        PlayerPrefs.SetFloat("rimColourB", rimColourB.value);

        PlayerPrefs.SetFloat("outlineWidth", outlineWidth.value);
        PlayerPrefs.SetFloat("outlineColourR", outlineColourR.value);
        PlayerPrefs.SetFloat("outlineColourG", outlineColourG.value);
        PlayerPrefs.SetFloat("outlineColourB", outlineColourB.value);
    }

    public void GetData()
    {
        red.value = PlayerPrefs.GetFloat("red");
        green.value = PlayerPrefs.GetFloat("green");
        blue.value = PlayerPrefs.GetFloat("blue");

        shadowStep.value = PlayerPrefs.GetFloat("shadowStep");
        shadowStepSmooth.value = PlayerPrefs.GetFloat("shadowStepSmooth");

        specularStep.value = PlayerPrefs.GetFloat("specularStep");
        specularStepSmooth.value = PlayerPrefs.GetFloat("specularStepSmooth");
        specularColourR.value = PlayerPrefs.GetFloat("specularColourR");
        specularColourG.value = PlayerPrefs.GetFloat("specularColourG");
        specularColourB.value = PlayerPrefs.GetFloat("specularColourB");

        rimStep.value = PlayerPrefs.GetFloat("rimStep");
        rimStepSmooth.value = PlayerPrefs.GetFloat("rimStepSmooth");
        rimColourR.value = PlayerPrefs.GetFloat("rimColourR");
        rimColourG.value = PlayerPrefs.GetFloat("rimColourG");
        rimColourB.value = PlayerPrefs.GetFloat("rimColourB");

        outlineWidth.value = PlayerPrefs.GetFloat("outlineWidth");
        outlineColourR.value = PlayerPrefs.GetFloat("outlineColourR");
        outlineColourG.value = PlayerPrefs.GetFloat("outlineColourG");
        outlineColourB.value = PlayerPrefs.GetFloat("outlineColourB");
    }

    #endregion
}