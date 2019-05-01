using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSceneParallax : MonoBehaviour
{
    private Renderer fundo;
    public float vel = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        fundo = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var vet2 = new Vector2(vel * Time.deltaTime, vel * Time.deltaTime);
        fundo.material.mainTextureOffset += vet2;
    }
}
