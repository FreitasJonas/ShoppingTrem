using UnityEngine;
using UnityEngine.UI;

public class BarraMochila : MonoBehaviour {
    
    public Image barraMochila;

    public bool RetiraItem(int qtde, Produto product)
    {
        float espacoDesocupar = (float)(qtde * product.tam) / 10;
                
        if (barraMochila.fillAmount >= espacoDesocupar)
        {            
            barraMochila.fillAmount -= espacoDesocupar;

            //se ficou vazia depois da operação
            if (barraMochila.fillAmount <= 0)
            {
                return false;
            }
            
            return true;
        }
        else
        {
            //esta vazia antes da operação
            return false;
        }
    }
}
