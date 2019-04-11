using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GrupoAssentoC : MonoBehaviour {
    
    public AssentoC GetAssento()
    {
        var lstAssentos = GetComponentsInChildren<AssentoC>();
        var assentosDesocupados = lstAssentos.Where(a => a.ocupado == false).ToArray();

        if(assentosDesocupados != null && assentosDesocupados.Length > 0)
        {
            return assentosDesocupados[0];
        }
        else
        {
            return null;
        }
    }
}
