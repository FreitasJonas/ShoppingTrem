using UnityEngine;

public class ClienteC : MonoBehaviour {

    public int qtdeSolicitada = 1;
    private bool waitingSale = true;
    
    private GameObject _cashText;
    public Produto product;

    private void Start()
    {
        _cashText = GameObject.Find(this.name + "/CashRef/CashIcon");
        _cashText.SetActive(true);       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("assento"))
        {
            var assento = other.GetComponent<GrupoAssentoC>().GetAssento();
            assento.Sentar(this.gameObject, true);
        }
    }

    public bool IsWaintgSale()
    {
        return waitingSale;
    }

    public void HideCashSymbol()
    {
        waitingSale = false;
        this._cashText.SetActive(false);
    }
}
