using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chirpController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource sonido;
    void Start()
    {
        sonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
