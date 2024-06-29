using UnityEngine;
using UnityEngine.UI;

public class Plata : MonoBehaviour
{
    public Button[] botones;  // Array de botones para las opciones
    public int presupuesto;
    public int precio1;
    public int precio2;
    private Text presupuestoTxt;
    private Text precio1Txt;
    private Text precio2Txt;

    public Color colorCorrecto = Color.green;
    public Color colorIncorrecto = Color.red;

    private bool respondido = false;

    void Start()
    {
        //randomizar precios
        presupuesto = Random.Range(300, 1001);
        precio1 = Random.Range(1, 551);
        precio2 = Random.Range(1, 501);

        //obtener objetos para texto
        presupuestoTxt = GameObject.Find("PresupuestoTxt").GetComponent<Text>();
        precio1Txt = GameObject.Find("Precio1").GetComponent<Text>();
        precio2Txt = GameObject.Find("Precio2").GetComponent<Text>();

        //poner respectivos texto en cada caja
        presupuestoTxt.text = "Tu presupuesto es " + presupuesto.ToString();
        precio1Txt.text = precio1.ToString();
        precio2Txt.text = precio2.ToString();

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