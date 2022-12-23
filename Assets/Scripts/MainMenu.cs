using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void ReintentarJuego(int num)
    {
        SceneManager.LoadScene("Nivel"+num);
    }

    public void CargarEscenaJuego(int num)
    {
        SceneManager.LoadScene("Nivel"+num);
    }

    public void CargarMenuReintentar()
    {
        SceneManager.LoadScene("MenuGameOver");
    }

    public void CargarMenuSiguiente()
    {
        SceneManager.LoadScene("MenuNextLv2");
    }

}
