using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    [System.Serializable]
    public class MaterialData
    {
        public Material material;
        public float emissionIntensity;
    }

    [SerializeField]
    private MaterialData[] materialDataArray;

    public Color emissionColor = Color.white; // Color de emisión HDR

    [Header("Rango de Intensidad de Emisión")]
    public float minEmissionIntensity = 0.0f; // Valor mínimo de intensidad de emisión
    public float maxEmissionIntensity = 2.0f; // Valor máximo de intensidad de emisión

    private Dictionary<string, MaterialData> materialDictionary;

    // Example of how to use the dictionary
    private void Start()
    {
        // Initialize or clear the dictionary
        if (materialDictionary == null)
        {
            materialDictionary = new Dictionary<string, MaterialData>();
        }
        else
        {
            materialDictionary.Clear();
        }

        // Populate the dictionary
        foreach (var materialData in materialDataArray)
        {
            if (!materialDictionary.ContainsKey(materialData.material.name))
            {
                materialDictionary.Add(materialData.material.name, materialData);
            }
            else
            {
                Debug.LogWarning("Duplicate material name found in the array: " + materialData.material.name);
            }
        }

        foreach (var kvp in materialDictionary)
        {
            string materialName = kvp.Key;
            MaterialData materialData = kvp.Value;

            float emissionIntensity = Random.Range(minEmissionIntensity, maxEmissionIntensity);
            setEmissionIntensity(materialData, emissionIntensity);

            // Access material and float value through MaterialData
            Material material = materialData.material;
            float floatValue = materialData.emissionIntensity;

            // Do something with the material and floatValue
            Debug.Log($"Material Name: {materialName}, Material: {material.name}, Float Value: {floatValue}");
        }
    }

    public void AumentarIntensidad()
    {
        foreach (var kvp in materialDictionary)
        {
            MaterialData materialData = kvp.Value;
            var emissionIntensity = materialData.emissionIntensity * Random.Range(3, 1.75f);
            setEmissionIntensity(materialData, emissionIntensity);
        }

    }

    public Material getRandomMaterial()
    {
        return GetRandomItem(materialDictionary).Value.material;
    }

    private static KeyValuePair<TKey, TValue> GetRandomItem<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
    {
        if (dictionary == null || dictionary.Count == 0)
        {
            throw new System.ArgumentException("Dictionary is null or empty");
        }

        // Convert dictionary values to a list
        List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>(dictionary);

        // Use Random class to generate a random index
        int randomIndex = new System.Random().Next(0, list.Count);

        // Retrieve the random item from the list
        return list[randomIndex];
    }

    private void setEmissionIntensity(MaterialData md, float emissionIntensity)
    {
        emissionColor = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
        md.material.SetColor("_EmissionColor", emissionColor * emissionIntensity);
        md.emissionIntensity = emissionIntensity;
        // Activa la emisión si la intensidad es mayor que cero
        if (emissionIntensity > 0)
        {
            md.material.EnableKeyword("_EMISSION");
        }
        else
        {
            md.material.DisableKeyword("_EMISSION");
        }
    }
}