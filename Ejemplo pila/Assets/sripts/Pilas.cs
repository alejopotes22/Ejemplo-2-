using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;   // Importante si usas TextMeshPro
using UnityEngine.UI;

public class PilaTexto : MonoBehaviour
{
    // Pila de nombres
    private Stack<string> pilaNombres = new Stack<string>();

    [Header("Referencias UI")]
    public TMP_InputField inputField; // Para escribir texto
    public TMP_Text textPila;         // Para mostrar el contenido de la pila
    public TMP_Text textResultado;    // Para mostrar Peek o Pop

    // Push: agrega el texto del InputField a la pila
    public void PushString()
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {
            pilaNombres.Push(inputField.text);
            inputField.text = ""; // limpiar después de insertar
            MostrarPila();
        }
    }

    // Pop: quita el último elemento
    public void PopString()
    {
        if (pilaNombres.Count > 0)
        {
            string eliminado = pilaNombres.Pop();
            textResultado.text = "POP → " + eliminado;
            MostrarPila();
        }
        else
        {
            textResultado.text = "La pila está vacía";
        }
    }

    // Peek: muestra el último elemento sin quitarlo
    public void PeekString()
    {
        if (pilaNombres.Count > 0)
        {
            string ultimo = pilaNombres.Peek();
            textResultado.text = "PEEK → " + ultimo;
        }
        else
        {
            textResultado.text = "La pila está vacía";
        }
    }

    // Clear: vacía toda la pila
    public void ClearStack()
    {
        pilaNombres.Clear();
        textResultado.text = "Pila limpiada";
        MostrarPila();
    }

    // Método auxiliar para mostrar todo el contenido de la pila
    private void MostrarPila()
    {
        textPila.text = "Pila:\n";

        foreach (string item in pilaNombres)
        {
            textPila.text += item + "\n";
        }
    }
}


// push: para apilar 
// pop: para quitar el último elemento de la pila
// peek: para ver el último elemento de la pila sin quitarlo
// clear: para limpiar la pila