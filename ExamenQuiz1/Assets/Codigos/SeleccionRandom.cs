using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeleccionRandom : MonoBehaviour
{

    public int NumeroDePreguntas;
    public List<int> numbRandom;
    public bool stop = false;
    public int puntaje;
    public int contador = 0;
    public int contadorPreguntas = 0;
    public GameObject[] preguntitas;
    public GameObject PanelF;
    public TextMeshProUGUI TPuntaje;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   

    public void EmpezarPreguntar ()
    {

            preguntitas[numbRandom[contadorPreguntas]].SetActive(false);
            contadorPreguntas++;
            preguntitas[numbRandom[contadorPreguntas]].SetActive(true);
       
    }


    public void Empezar()
    {
        for (int i = 0; i < 100; i++)
        {
            int x = Random.Range(0, NumeroDePreguntas - 1);
            if (!numbRandom.Contains(x))
            {
                numbRandom.Add(x);
                contador++;
            }
            if (contador == NumeroDePreguntas - 1) 
            {
                break;

            }

        }
        preguntitas[numbRandom[contadorPreguntas]].SetActive(true);
    }



    public void RespuestaCorrecta(Button boton)
    {
        StartCoroutine(RespuestaCorrectaCoroutine( boton));
    }

    public void RespuestaIncorrecta(Button boton)
    {

        StartCoroutine(RespuestaIncorrectaCoroutine( boton));
    }

    public IEnumerator RespuestaCorrectaCoroutine(Button boton)
    {
        boton.image.color = Color.green;
        yield return new WaitForSeconds(3);
        puntaje++;
        EmpezarPreguntar();
        

    }
    public IEnumerator RespuestaIncorrectaCoroutine(Button boton)
    {
        boton.image.color = Color.red;
        yield return new WaitForSeconds(3);
        EmpezarPreguntar();

    }



    // Update is called once per frame
    void Update()
    {
       if (preguntitas.Length  == contadorPreguntas)
        {
            PanelF.SetActive(true);
            TPuntaje.text = puntaje.ToString();
        }
    }
}