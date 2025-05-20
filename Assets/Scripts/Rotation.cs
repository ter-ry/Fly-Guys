using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speedx = 3f;
    public float speedy = 0f;
    public float speedz = 0f;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speedx * Time.deltaTime / 0.01f, speedy * Time.deltaTime / 0.01f, speedz * Time.deltaTime / 0.01f);

    }
}
