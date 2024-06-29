using UnityEngine;
using UnityEngine.UI;

public class Plata : MonoBehaviour
{
    public Button[] botones;  // Array de botones para las opciones
    public int presupuesto;
    public int precio1;
    public int precio2;

    public Color colorCorrecto = Color.green;
    public Color colorIncorrecto = Color.red;

    private bool respondido = false;

    void Start()
    {
        




        for (int i = 0; i < botones.Length; i++)
        {
            int index = i;  // Necesario para capturar el índice correcto en el listener
            botones[i].onClick.AddListener(() => BotonPresionado(index));
        }
    }

    void BotonPresionado(int indice)
    {
        if (!respondido)
        {
            VerificarRespuesta(indice);
            respondido = true;
        }
    }

    public void VerificarRespuesta(int indiceSeleccionado)
    {
        int total = precio1 + precio2;
        int respuestaCorrecta;

        if (presupuesto > total)
            respuestaCorrecta = 0;  // Sobra
        else if (presupuesto == total)
            respuestaCorrecta = 1;  // Alcanza
        else
            respuestaCorrecta = 2;  // Falta

        for (int i = 0; i < botones.Length; i++)
        {
            Image imagenBoton = botones[i].GetComponent<Image>();

            if (i == respuestaCorrecta)
            {
                imagenBoton.color = colorCorrecto;
            }
            else
            {
                imagenBoton.color = colorIncorrecto;
            }

            botones[i].interactable = false;
        }
    }

   
}