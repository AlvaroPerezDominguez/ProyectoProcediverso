using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturadorManos : MonoBehaviour
{

    public Material material;


    public void AumentarSaturacionManos()
    {

        Debug.Log("Aumentando saturacion manos");

        Color currentColor = material.color;

        // Convertir de RGB a HSV
        Color.RGBToHSV(currentColor, out float currentHue, out float currentSaturation, out float currentValue);

        // Modificar los valores HSV
        currentSaturation = currentSaturation + 0.2f;

        // Convertir de nuevo de HSV a RGB
        Color modifiedColor = Color.HSVToRGB(currentHue, currentSaturation, currentValue);

        // Aplicar el nuevo color al material
        material.color = modifiedColor;
    }

}
