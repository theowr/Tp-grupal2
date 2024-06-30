using UnityEngine;
using UnityEngine.UI;

public class Plata : MonoBehaviour
{
    public Button[] botones;
    public int presupuesto;
    public int precio1;
    public int precio2;

    private Text presupuestoTxt;
    private Text precio1Txt;
    private Text precio2Txt;
    public Color colorCorrecto = Color.green;
    public Color colorIncorrecto = Color.red;
    private bool respondido = false;

    public Button SalirBtn;
    public Button ReIntendoBtn;
    public Text TextoFinal;

    void Start()
    {
        presupuesto = Random.Range(300, 1001);
        precio1 = Random.Range(1, 551);
        precio2 = Random.Range(1, 501);

        presupuestoTxt = GameObject.Find("PresupuestoTxt").GetComponent<Text>();
        precio1Txt = GameObject.Find("Precio1").GetComponent<Text>();
        precio2Txt = GameObject.Find("Precio2").GetComponent<Text>();

        presupuestoTxt.text = "Tu presupuesto es " + presupuesto.ToString();
        precio1Txt.text = precio1.ToString();
        precio2Txt.text = precio2.ToString();

        for (int i = 0; i < botones.Length; i++)
        {
            int index = i;
            botones[i].onClick.AddListener(() => BotonPresionado(index));
        }

        SalirBtn.gameObject.SetActive(false);
        ReIntendoBtn.gameObject.SetActive(false);
        TextoFinal.gameObject.SetActive(false);
    }

    void BotonPresionado(int indice)
    {
        if (!respondido)
        {
            VerificarRespuesta(indice);
            respondido = true;
            DesactivarElementosIniciales();
            ActivarElementosFinales();
        }
    }

    public void VerificarRespuesta(int indiceSeleccionado)
    {
        int total = precio1 + precio2;
        int respuestaCorrecta;
        if (presupuesto > total)
            respuestaCorrecta = 0;
        else if (presupuesto == total)
            respuestaCorrecta = 1;
        else
            respuestaCorrecta = 2;

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

    void DesactivarElementosIniciales()
    {
        foreach (Button boton in botones)
        {
            boton.gameObject.SetActive(false);
        }
        presupuestoTxt.gameObject.SetActive(false);
        precio1Txt.gameObject.SetActive(false);
        precio2Txt.gameObject.SetActive(false);
    }

    void ActivarElementosFinales()
    {
        SalirBtn.gameObject.SetActive(true);
        ReIntendoBtn.gameObject.SetActive(true);
        TextoFinal.gameObject.SetActive(true);
    }
}