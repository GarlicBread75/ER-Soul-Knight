using UnityEngine;

public class RainbowRot : MonoBehaviour
{
    [SerializeField] float hueModifier;
    [SerializeField] bool canColour;
    [SerializeField] Color colour;
    [SerializeField] float hue;
    Renderer rend;

    [Space]
    [Space]
    [Space]

    [SerializeField] float rotModifier;
    [SerializeField] bool canRot;
    [SerializeField] bool canRotX;
    [SerializeField] bool canRotY;
    [SerializeField] bool canRotZ;
    float rotX;
    float rotY;
    float rotZ;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rotX = transform.rotation.x;
        rotY = transform.rotation.y; 
        rotZ = transform.rotation.z;
        hue /= 255;
        //colour = rend.material.GetColor("_BaseColor");
    }

    void Update()
    {
        if (canColour)
        {
            if (hue >= 1)
            {
                hue = 0;
            }
            else
            {
                hue += Time.deltaTime / hueModifier;
            }

            colour = Color.HSVToRGB(hue, 1, 0.7f);
            rend.material.SetColor("_BaseColor", colour);
        }

        if (canRot)
        {
            if (canRotX)
            {
                if (rotX >= 360)
                {
                    rotX = 0;
                }
                else
                {
                    rotX += Time.deltaTime / rotModifier;
                }
            }

            if (canRotY)
            {
                if (rotY >= 360)
                {
                    rotY = 0;
                }
                else
                {
                    rotY += Time.deltaTime / rotModifier;
                }
            }

            if (canRotZ)
            {
                if (rotZ >= 360)
                {
                    rotZ = 0;
                }
                else
                {
                    rotZ += Time.deltaTime / rotModifier;
                }
            }

            transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
        }
    }
}
