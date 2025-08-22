using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PilasImagenes : MonoBehaviour
{
    private Stack<GameObject> pilaImagenes = new Stack<GameObject>();

    [Header("Referencias UI")]
    public Transform contenedor;   // Panel o un GameObject vacío donde se crearán las imágenes
    public GameObject prefabImagen; // Prefab de un UI → Image
    public TMP_Text resultadoText;

    private Sprite[] spritesDisponibles;
    private int indiceActual = 0;  // Para llevar el orden fijo

    void Start()
    {
        // Cargar imágenes desde Resources/Imagenes
        spritesDisponibles = Resources.LoadAll<Sprite>("Imagenes");

        if (spritesDisponibles.Length == 0)
        {
            Debug.LogWarning("⚠ No se encontraron imágenes en Resources/Imagenes");
        }
    }

    // PUSH: mete la siguiente imagen en orden fijo
    public void PushImage()
    {
        if (indiceActual < spritesDisponibles.Length)
        {
            Sprite nueva = spritesDisponibles[indiceActual];

            // Instanciamos un nuevo Image en el contenedor
            GameObject nuevaImagenGO = Instantiate(prefabImagen, contenedor);
            nuevaImagenGO.GetComponent<Image>().sprite = nueva;

            // Lo apilamos
            pilaImagenes.Push(nuevaImagenGO);

            resultadoText.text = "PUSH → " + nueva.name;

            // Pasamos al siguiente índice
            indiceActual++;
        }
        else
        {
            resultadoText.text = "⚠ No hay más imágenes para apilar";
        }
    }

    // POP: destruye el último objeto de la pila
    public void PopImage()
    {
        if (pilaImagenes.Count > 0)
        {
            GameObject ultima = pilaImagenes.Pop();
            resultadoText.text = "POP → " + ultima.GetComponent<Image>().sprite.name;
            Destroy(ultima);

            // Retrocedemos el índice para poder volver a apilar esa imagen si se desea
            indiceActual = Mathf.Max(0, indiceActual - 1);
        }
        else
        {
            resultadoText.text = "⚠ La pila está vacía";
        }
    }

    // PEEK: solo muestra el nombre de la última imagen
    public void PeekImage()
    {
        if (pilaImagenes.Count > 0)
        {
            GameObject cima = pilaImagenes.Peek();
            resultadoText.text = "PEEK → " + cima.GetComponent<Image>().sprite.name;
        }
        else
        {
            resultadoText.text = "⚠ La pila está vacía";
        }
    }

    // CLEAR: limpia todo
    public void ClearStack()
    {
        while (pilaImagenes.Count > 0)
        {
            GameObject img = pilaImagenes.Pop();
            Destroy(img);
        }

        resultadoText.text = "Pila vaciada";

        // Reiniciamos el índice
        indiceActual = 0;
    }
}
