using System.Collections;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class juegoPlanetas : MonoBehaviour
{

    public GameObject[] arrayPlanetas;
    public int planetaActual = 0;
    public int puntos;
    public int vidas = 5;

    private float tiempoQuePasa = 0;
    public float tiempoLimite = 15f; //va en segundos
    private bool jugando = true;

    public TMP_Text textoPlaneta;
    public TMP_Text textoPuntos;
    public TMP_Text textoAcierto;
    public TMP_Text textoInfo;

    public Button botonSig;

    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;

        AsignarPlaneta();

    }

    // Update is called once per frame
    void Update()
    {
        if (jugando)
        {
            //Se calcula el tiempo pasado
            tiempoQuePasa += Time.deltaTime;

            //Si ha pasado el tiempo estimado se asigna un nuevo planeta y se restan vidas
            if (tiempoQuePasa >= tiempoLimite)
            {
                vidas--;
                AsignarPlaneta();
            }
        }
       
    }

    public void AsignarPlaneta()
    {
        //Se resetea el tiempo a 0
        tiempoQuePasa = 0;

        //desactivamos el planeta actual
        arrayPlanetas[planetaActual].SetActive(false);

        //Generamos un nuevo planeta
        int random= Random.Range(0, arrayPlanetas.Length);

        //Comprobamos que no se repita
        if (random != planetaActual)
        {
            //Activamos el nuevo planeta
            planetaActual = random;
            arrayPlanetas[planetaActual].SetActive(true);

            string planeta = "";
            planeta = arrayPlanetas[planetaActual].name;
           

            textoPlaneta.SetText(planeta);
            Debug.Log("Isa planeta= " + planetaActual + " random= " + random);
        }
        else
        {
            //Se repite el proceso hasta obtener un nuevo planeta 
            AsignarPlaneta();
        }      
    }

    public void acierto()
    {

        //si es la primera vez que se encuentra el objetivo se suman los puntos
        if (jugando)
        {
            //Sumamos los puntos
            puntos++;
            textoPuntos.SetText(puntos.ToString());
        }
        
        //Se detiene el juego para que el jugador vea que ha acertado y se cargue la información
        jugando = false;

        //Activamos el botón de siguiente
        botonSig.gameObject.SetActive(true);
        textoAcierto.gameObject.SetActive(true);
        textoInfo.gameObject.SetActive(true);

        //Mostramos el texto
        textoAcierto.SetText("¡GENIAL!");
        textoInfo.SetText("¿Sabías que ¿Sabías que...  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer varius at sem in gravida. Sed volutpat, quam non interdum dictum, velit justo hendrerit lectus, in sagittis elit nulla blandit urna. ?...?");

        //Invoke("ganado", 2);

    }

    public void ganado()
    {
        puntos++;
        textoPuntos.SetText(puntos.ToString());
        Debug.Log("Isa PUNTOS: " + puntos);

        tiempoQuePasa = 0;
    }

    public void Siguiente()
    {

        //Se esconde la información y el botón de siguiente
        botonSig.gameObject.SetActive(false);
        textoAcierto.gameObject.SetActive(false);
        textoInfo.gameObject.SetActive(false);

        //Se continua el juego con un nuevo planeta
        jugando = true;
        AsignarPlaneta();       

    }


}
