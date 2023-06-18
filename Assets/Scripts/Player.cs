using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update



    [SerializeField]
    GameObject[] maps;

    private Vector3 v3;
    private Rigidbody rb;
    [SerializeField] private Camera cam;
    void Start()
    {
        // cria componente fisico para objeto player
        gameObject.AddComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        v3 = new(transform.position.x, transform.position.y, transform.position.z - 5);
        cam.transform.localPosition = v3;
        rb.velocity = Vector3.forward;
        rb.freezeRotation = true;
    }

    float a;
    

    //quando o player  mudar de plataforma ira gerar um novo mapa. 
    
  void OnCollisionEnter(Collision e) {
      a =  e.gameObject.transform.position.z;
        
    
    }
    void OnCollisionExit(Collision e)
    {
        CreateGround(a);
    }

    void CreateGround(float a)
    {
        Instantiate(maps[1], new Vector3(0.0f,0.0f,a+20),transform.rotation);
        print("mapa criado"); ;
    }



}
