using UnityEngine;
using UnityEngine.EventSystems;

public class BtnSale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool inSale;
    private bool playSound;
    private bool btnPress;
    private bool isInit;

    public ClienteC client;
    public PlayerC player;

    public SaleManager saleManager;

    void Start()
    {
        saleManager.onSaleFinished = onSaleFinished;
    }
    
    //utilizados para pegar informações do cliente, como quantidade de produtos solicitada para a compra
    public void Init(ClienteC client, PlayerC player)
    {
        this.client = client;
        this.player = player;

        isInit = true;
    }

    private void onSaleFinished()
    {
        isInit = false;
        client.HideCashSymbol();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isInit)
        {
            saleManager.DoSale(client.product, client, player);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isInit = false;
        saleManager.CancelSale();
    }
}
