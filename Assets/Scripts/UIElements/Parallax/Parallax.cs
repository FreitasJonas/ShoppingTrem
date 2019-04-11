using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    private Renderer fundo;
    public float vel = 0.5f;
    public bool rightDir = false;

    // Use this for initialization
    void Start () {
        
        fundo = GetComponent<Renderer>();

	}
	
	// Update is called once per frame
	void Update () {

        var vet2 = new Vector2(vel * Time.deltaTime, 0);

        if(!rightDir) // rolar para esquerda
        {
            fundo.material.mainTextureOffset += vet2;
        }
        else if (rightDir) // rolar para esquerda
        {
            fundo.material.mainTextureOffset -= vet2;
        }
    }
}
