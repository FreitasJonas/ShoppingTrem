using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour {

    public float tempo;
    public Image img;
    public Text txt;

    public delegate void FinishDelegate();
    public FinishDelegate onFinish;
	
	// Update is called once per frame
	void Update () {

        if (tempo > 0)
        {
            tempo -= Time.deltaTime;
        }
        else
        {            
            tempo = 0;
            onFinish();
            Destroy(this.gameObject);
        }

        txt.text = tempo.ToString("0");
        img.fillAmount = tempo / 3;		
	}
}
