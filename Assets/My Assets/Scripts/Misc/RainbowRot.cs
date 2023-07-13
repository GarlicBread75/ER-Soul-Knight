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

    [Space]

    [SerializeField] bool canRotX;
    [SerializeField] float rotX;

    [Space]

    [SerializeField] bool canRotY;
    [SerializeField] float rotY;

    [Space]
    
    [SerializeField] bool canRotZ;
    [SerializeField] float rotZ;
    Vector3 rot;

    void Start()
    {
        rend = GetComponent<Renderer>();
        hue /= 255;
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

            colour = Color.HSVToRGB(hue, 1, 1);
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

            rot = new Vector3(rotX, rotY, rotZ);
            transform.rotation = Quaternion.Euler(rot);
        }
    }
}
