using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_De_Nave : MonoBehaviour
{
    Rigidbody rigidbody_;
    Transform transform_;
    AudioSource audiosource_;
    
    [SerializeField] float mainThrust = 0.10f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody_ = GetComponent<Rigidbody>();
        transform_ = GetComponent<Transform>();
        audiosource_ = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime + " seg " + (1.0f / Time.deltaTime) + " FPS");
        //print("Hola");
        ProcesarInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "ColisionSegura":
                print("Colision Segura...");
                break;
            case "Combustible":
                print("Combustible...");
                break;
            case "Aterrizaje":
                //print("Aterrizaje...");
                SceneManager.LoadScene("Nivel2");
                break;
            default:
                //print("Muerto...!!!");
                SceneManager.LoadScene("Nivel1");
                break;
        }
        
        /*
        if(collision.gameObject.CompareTag("ColisionSegura"))
        {
            print("Colision Segura...");
        }
        else if(collision.gameObject.CompareTag("ColisionPeligrosa"))
        {
            print("Colision Peligrosa...");
        }
        */
    }

    private void ProcesarInput()
    {
        Propulsion();
        Rotacion();
    }

    private void Propulsion()
    {
        rigidbody_.freezeRotation = true;
        if (Input.GetKey(KeyCode.Space))
        {
            //print("Propulsor");
            rigidbody_.AddRelativeForce(Vector3.up*mainThrust);     // X=0, Y=1, Z=0

            if (!audiosource_.isPlaying)
            {
                audiosource_.Play();
            }
        }
        else{
            audiosource_.Stop();
        }
        rigidbody_.freezeRotation = false;
    }

    private void Rotacion()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //print("Rotar derecha");
            //transform.Rotate(Vector3.back);
            var rotarDerecha = transform.rotation;
            rotarDerecha.z -= Time.deltaTime * 1;
            transform.rotation = rotarDerecha;
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                //transform.Rotate(Vector3.forward);
                //print("Rotar izquierda");
                var rotarIzquierda = transform.rotation;
                rotarIzquierda.z += Time.deltaTime * 1;
                transform.rotation = rotarIzquierda;
            }
        }
    }
}
