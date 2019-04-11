using UnityEngine;

public class SaleManager : MonoBehaviour {

    public Mochila bag;
    public GameObject barSalePrefab;
    public GameObject refInitBarSale;
    
    public delegate void SaleFinished();
    public SaleFinished onSaleFinished;

    private GameObject _barSaleGameObject;

    private void Start()
    {
        //bag = GetComponent<Mochila>();
        bag.bagEmpty = OnBagEmpty;
    }

    public void DoSale(Produto product, ClienteC client, PlayerC player)
    {
        //se houver a quantidade solicitada na mochila
        if (client.qtdeSolicitada <= bag.listProduct.Count)
        {
            //cria barra de venda
            _barSaleGameObject = Instantiate(barSalePrefab, new Vector3(refInitBarSale.transform.position.x, refInitBarSale.transform.position.y, 0), Quaternion.identity);

            //pega o script da barra
            var barSaleScript = _barSaleGameObject.GetComponent<BarraVenda>();
            
            //registra função delegate
            barSaleScript.saleFinished = delegate () {
                //quando terminar...

                //Destroi barra da venda
                Destroy(_barSaleGameObject);

                //Remove os itens da mochila
                bag.RemoveItems(product, client.qtdeSolicitada);

                //Incrementa o dinheiro
                player.IncreaseCash(client.qtdeSolicitada * product.price);

                //avisa a quem estiver registrado que a venda finalizou
                onSaleFinished();
            };

            //ativa barra de venda
            _barSaleGameObject.SetActive(true);
        }
        else
        {
            print("Não há a quantidade solicitada na mochila");
        }
    }

    public void CancelSale()
    {
        if(_barSaleGameObject != null)
            Destroy(_barSaleGameObject);
    }

    void OnBagEmpty()
    {
        GetComponent<CameraC>().FimDeJogo();
    }
}
