using UnityEngine;
using UnityEngine.UI;

public class NpcSale : MonoBehaviour
{
    public Button actionButton;    

    private bool inSale;
    private bool playSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            actionButton.interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            actionButton.interactable = false;
        }
    }
}
