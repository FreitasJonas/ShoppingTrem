using System.Collections.Generic;
using UnityEngine;

public class Mochila : MonoBehaviour {

    public int tam = 10;

    public List<Produto> listProduct;
    public Produto product;
    public BarraMochila barBag;

    public delegate void BagEmpty();
    public BagEmpty bagEmpty;

    // Use this for initialization
    void Start () {

        //inicializa lista de produtos
        listProduct = new List<Produto>();

        var tempTam = tam;
        while (tempTam > 0)
        {
            listProduct.Add(Instantiate(product));
            tempTam -= 1;
        }		
	}

    public void RemoveItems(Produto product, int qtde = 1)
    {
        if(listProduct.Count > 0)
        {
            listProduct.RemoveRange(0, qtde);
            barBag.RetiraItem(qtde, product);
        }
        else
        {
            bagEmpty();
        }
    }
}
