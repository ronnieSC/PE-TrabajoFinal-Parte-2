using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//using MainMenu;

public class TiempoEnSegundos2 : MonoBehaviour
{
    public TMP_Text tiempoText;
    public static float tiempoValor;
    public float incrementoPorSegundo;

    public int numeroDeEscena;
    
    // Start is called before the first frame update
    void Start()
    {
        //tiempoValor = float.Parse(tiempoText.text);
        //incrementoPorSegundo = -1;
        print(tiempoText.text);
        tiempoValor = 100f;
        //numeroDeEscena = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoValor <= 0){
            //SceneManager.LoadScene("Nivel" + (numeroDeEscena+1));
            MainMenu m = new MainMenu();
            m.CargarMenuReintentar();
            //MainMenu.ReintentarJuego(numeroDeEscena+1);
        }
        
        else {
            Debug.Log("En TIEMPO SEGUNDOS: "+tiempoValor);
            tiempoText.text = (int)tiempoValor + "%";
            tiempoValor = tiempoValor + incrementoPorSegundo * Time.deltaTime;
        }
        
    }
}
