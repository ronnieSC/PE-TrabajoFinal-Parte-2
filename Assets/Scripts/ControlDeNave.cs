using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
    AudioSource audioSource;

    private MainMenu m = new MainMenu();

    [SerializeField] private GameObject[] hearts; 
    private static int life;
    private static TiempoEnSegundos2 time;

    [SerializeField] float velocidadPropulsion = 200.0f;  //valor standar ya que delta es aprox 0.2
    [SerializeField] float velocidadRotacion = 200.0f;
    [SerializeField] float  timerMuerte = 1.0f;
    [SerializeField] float  timerNivelCompleto = 1.0f;
    
    [SerializeField] AudioClip sonidoPropulsion;
    [SerializeField] AudioClip sonidoNivelCompleto;
    [SerializeField] AudioClip sonidoMuerte;

    //[SerializeField] ParticleSystem partMuerte;
    //[SerializeField] ParticleSystem partNivelCompleto;
    [SerializeField] ParticleSystem partPropulsion;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>(); // no es necesario
        audioSource = GetComponent<AudioSource>();
        time = new TiempoEnSegundos2();

        life = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarInput();
    }

     private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ColisionSegura":
                //print("Colision Segura ...");
                break;
            case "Combustible":
                //Debug.Log("chocaaaaaaaaaaaaaaaaa");
                addCombustible();
                break;
            case "ColisionPeligrosa":
                ProcesarMuerte();
                break;
            case "Aterrizaje1":
                ProcesarNivelCompleto();
                Invoke("PasarNivel1", timerNivelCompleto);
                print("Llegaste");
                break;
            case "Aterrizaje2":
                ProcesarNivelCompleto();
                Invoke("PasarNivel2", timerNivelCompleto);
                print("Llegaste");
                break;
            case "Aterrizaje3":
                ProcesarNivelCompleto();
                Invoke("PasarNivel3", timerNivelCompleto);
                print("Llegaste");
                break;
            case "Aterrizaje4":
                ProcesarNivelCompleto();
                Invoke("PasarNivel4", timerNivelCompleto);
                print("Llegaste");
                break;
            case "Aterrizaje5":
                ProcesarNivelCompleto();
                Invoke("PasarNivel5", timerNivelCompleto);
                print("Llegaste");
                break;
            
        }

    }
    private void addCombustible(){
        if(TiempoEnSegundos2.tiempoValor <= 100){
            TiempoEnSegundos2.tiempoValor += 5f;
        }
    }

    private void ProcesarNivelCompleto()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(sonidoNivelCompleto);
        //partNivelCompleto.Play();
        m.CargarMenuSiguiente();
    }

    private void ProcesarMuerte()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(sonidoMuerte);
        
        life--;

        if(life==0){
            //Invoke("Muerte1", timerMuerte);
            Muerte(SceneManager.GetActiveScene().buildIndex + 1);
        }
        hearts[life].SetActive(false);
    }
////////////////////////////////////////////////////////

    private void Muerte(int i)
    {
        SceneManager.LoadScene("Nivel"+i);
    }

    private void PasarNivel0()
    {
        SceneManager.LoadScene("Menu");
    }

    private void PasarNivel1()
    {
        SceneManager.LoadScene("Nivel2");
    }

    private void PasarNivel2()
    {
        SceneManager.LoadScene("Nivel3");
    }

    private void PasarNivel3()
    {
        SceneManager.LoadScene("Nivel4");
    }

    private void PasarNivel4()
    {
        SceneManager.LoadScene("Nivel5");
    }

    private void PasarNivel5()
    {
        SceneManager.LoadScene("Menu");
    }

////////////////////////////////////////////////
    private void ProcesarInput()
    {
        ProcesarPropulsion();
        ProcesarRotacion();
        
    }

    private void ProcesarPropulsion()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Propulsion();
        }
        else
        {
           audioSource.Stop();
           partPropulsion.Stop();     
        }
        rigidbody.freezeRotation = false;
    }

    private void Propulsion()
    {
        rigidbody.freezeRotation = true;
        rigidbody.AddRelativeForce(Vector3.up * velocidadPropulsion * Time.deltaTime);
        if(!partPropulsion.isPlaying)
        {
            partPropulsion.Play();
        }
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(sonidoPropulsion);
        }
        //print("Propulsor");
    }

    private void ProcesarRotacion()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * velocidadRotacion * Time.deltaTime); //-Vector3.forward
            //print("Rotar Derecha");
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
            //print("Rotar Izquierda");
        }
    }
}
