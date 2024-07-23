using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FacetasPilar : MonoBehaviour
{
    public List<Image> imagesToChooseFrom; // Lista de imágenes disponibles
    public int maxImageCount = 5; // Cantidad máxima de imágenes a mostrar
    private int currentImageCount = 0; // Contador de imágenes mostradas

    private List<Image> selectedImages = new List<Image>(); // Lista para almacenar las imágenes seleccionadas

    public void IncreaseImageCount()
    {
        if (currentImageCount < maxImageCount)
        {
            // Elige una imagen al azar de la lista y agrega su gemela
            Image selectedImage = ChooseRandomImage();
            selectedImages.Add(selectedImage);

            // Activa la imagen seleccionada y su gemela
            selectedImage.gameObject.SetActive(true);
            FindTwin(selectedImage).gameObject.SetActive(true);

            currentImageCount++;
        }
    }

    private Image ChooseRandomImage()
    {
        List<Image> inactiveImages = new List<Image>();

        // Recorre la lista de imágenes y agrega las inactivas a una lista temporal
        foreach (Image image in imagesToChooseFrom)
        {
            if (!image.gameObject.activeSelf)
            {
                inactiveImages.Add(image);
            }
        }

        // Elije una imagen inactiva al azar de la lista temporal
        int randomIndex = Random.Range(0, inactiveImages.Count);
        return inactiveImages[randomIndex];
    }



    private Image FindTwin(Image originalImage)
    {
        // Obtiene el nombre de la imagen original
        string originalName = originalImage.gameObject.name;

        // Encuentra la imagen gemela en la lista completa
        foreach (Image image in imagesToChooseFrom)
        {
            if (image.gameObject.name == originalName && image != originalImage)
            {
                return image;
            }
        }

        // Si no se encuentra una imagen gemela, retorna null (esto no debería ocurrir si las imágenes están configuradas correctamente)
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
