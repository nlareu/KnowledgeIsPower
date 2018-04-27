using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPreguntas : MonoBehaviour {

	public static MostrarPreguntas Instance { get; private set; }

    public Text TxtPregunta, TxtPespuesta1, TxtRespuesta2, TxtPuntos;

    public string[] preguntas, respuestas1, respuestas2;
    int lvl = 0;
    bool started = false, resp; //falso-izquierda true-derecha
    int points = 0;


	// Use this for initialization
	void Start () {
		started = true;

		Instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (started)
			this.UpdateQuestionDisplay ();

//        TxtPuntos.text = points.ToString();
    }

	private void UpdateQuestionDisplay () {
		TxtPregunta.text = preguntas[lvl].ToString();
		TxtPespuesta1.text = respuestas1[lvl].ToString();
		TxtRespuesta2.text = respuestas2[lvl].ToString();
	}
	public void DisplayNextQuestion() {
		this.lvl++;

		this.UpdateQuestionDisplay ();
	}

    public void respCorrecta()
    {
        int ran = Random.Range(10, 15);
        switch (lvl)
        {
            //NIVEL 1
            case 0:
                if (resp == false) //correcto
                {
                    points += 121 * ran; //* DIFERENCIA_DECOLOR 
                }
                else
                {
                    points += 40 * ran; // * (diferencia/2)
                }
                break;

            case 1:
                if (resp == false) //correcto
                {
                    points += 121 * ran; //* DIFERENCIA_DECOLOR 
                }
                else
                {
                    points += 40 * ran; // * (diferencia/2)
                }
                break;

            case 2:
                if (resp == true) //correcto
                {
                    points += 121 * ran; //* DIFERENCIA_DECOLOR 
                }
                else
                {
                    points += 40 * ran; // * (diferencia/2)
                }
                break;

            //NIVEL 2
            case 3:
                if (resp == false) //correcto
                {
                    points += 121 * ran; //* DIFERENCIA_DECOLOR 
                }
                else
                {
                    points += 40 * ran; // * (diferencia/2)
                }
                break;
            case 4:
                if (resp == false) //correcto
                {
                    points += 121 * ran; //* DIFERENCIA_DECOLOR 
                }
                else
                {
                    points += 40 * ran; // * (diferencia/2)
                }
                break;
            case 5:
                if (resp == false) //correcto
                {
                    points += 121 * ran; //* DIFERENCIA_DECOLOR 
                }
                else
                {
                    points += 40 * ran; // * (diferencia/2)
                }
                break;

            //NIVEL 3
            case 6:
                if (resp == true) //correcto
                {
                    points += 121 * ran; //* DIFERENCIA_DECOLOR 
                }
                else
                {
                    points += 40 * ran; // * (diferencia/2)
                }
                break;
            case 7:
                if (resp == false) //correcto
                {
                    points += 121 * ran; //* DIFERENCIA_DECOLOR 
                }
                else
                {
                    points += 40 * ran; // * (diferencia/2)
                }
                break;
            case 8:
                if (resp == true) //correcto
                {
                    points += 121 * ran; //* DIFERENCIA_DECOLOR 
                }
                else
                {
                    points += 40 * ran; // * (diferencia/2)
                }
                break;

            //NIVEL 4
            case 9:
                if (resp == false) //correcto
                {
                    points += 121 * ran; //* DIFERENCIA_DECOLOR 
                }
                else
                {
                    points += 40 * ran; // * (diferencia/2)
                }
                break;
            case 10:
                if (resp == true) //correcto
                {
                    points += 121 * ran; //* DIFERENCIA_DECOLOR 
                }
                else
                {
                    points += 40 * ran; // * (diferencia/2)
                }
                break;
            case 11:
                if (resp == true) //correcto
                {
                    points += 121 * ran; //* DIFERENCIA_DECOLOR 
                }
                else
                {
                    points += 40 * ran; // * (diferencia/2)
                }
                break;


            //NIVEL 5
            case 12:
                points += ran * ran + ran;
                break;
            case 13:
                points += ran * ran + ran;
                break;
            case 14:
                points += ran * ran + ran;
                break;
            case 15:
                points += ran * ran + ran;
                break;
            case 16:
                points += ran * ran + ran;
                break;

        }
    }
}

