using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaNave : MonoBehaviour
{
    public float vida = 100;
    public Image barradevida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       vida = Mathf.Clamp(vida, 0, 100);
       barradevida.fillAmount = vida / 100; 
    }
}
