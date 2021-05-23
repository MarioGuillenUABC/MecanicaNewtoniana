using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanica : MonoBehaviour
{
    public GameObject peso;
    public GameObject piso;

    public float masa = 3;
    public float fricCoef = .367f;
    public float angle = 30;
    public float g = 9.81f;

    private float Fr;

    public float w;
    public float V;
    public float A;
    public float N;
    public Vector3 pPos;


    void Start()
    {

        pPos = piso.transform.InverseTransformPoint(transform.position);

    }


    void Update()
    {


        piso.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        w = masa * g;
        N = w * Mathf.Cos(angle * Mathf.PI / 180);
        Fr = Mathf.Sign(angle)*fricCoef * N;
       
     

        if (Mathf.Tan(Mathf.Abs(angle) * Mathf.PI / 180) < fricCoef)
        {
           if ((V < 0 && angle > 0) || (V > 0 && angle < 0) ){
                print("A");
                A = (w * Mathf.Sin(angle * Mathf.PI / 180) - Fr) / masa;
            }
            else {
                V = 0;
                A = 0;
            }
        }
        else {
            A = (w * Mathf.Sin(angle * Mathf.PI / 180) - Fr) / masa;
        }

        V += A * Time.deltaTime;

        pPos.x += V * Time.deltaTime;

        pPos.x = Mathf.Clamp(pPos.x, -.5f, .5f);
        peso.transform.position = piso.transform.TransformPoint(pPos);
        peso.transform.up = piso.transform.up;
        print(A);

    }
}
