using UnityEngine;
using UnityEngine.UI;

public enum SaleBarMode
{
    Descending,
    Ascending
}

public class BarraVenda : MonoBehaviour
{
    public Image saleBar;

    private float tempoInicial;
    public float tempo;
    public SaleBarMode mode = SaleBarMode.Ascending;

    public bool finished;

    public delegate void SaleFinished();
    public SaleFinished saleFinished;

    private void Start()
    {
        tempoInicial = tempo;

        if (mode == SaleBarMode.Ascending)
        {
            saleBar.fillAmount = 0;
            tempo = 0;
        }
        else
        {
            tempoInicial = tempo;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == SaleBarMode.Ascending)
        {
            SaleBarAscending();
        }
        else
        {
            SaleBarDescending();
        }        
    }

    public void SaleBarDescending()
    {
        if (tempo > 0)
        {
            tempo -= Time.deltaTime;
            saleBar.fillAmount = tempo / tempoInicial;
        }
        else
        {
            tempo = 0;
            finished = true;
            saleFinished();
        }
    }

    public void SaleBarAscending()
    {
        if (tempo < tempoInicial)
        {
            tempo += Time.deltaTime;
            saleBar.fillAmount = tempo / tempoInicial;
        }
        else
        {
            tempo = 0;
            finished = true;
            saleFinished();
        }
    }
}
