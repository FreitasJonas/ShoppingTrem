using UnityEngine;

public class CameraC : MonoBehaviour {

    public GameObject temporizador;
    public GameObject joyStick;

    public GameObject btnFimJogo;

	// Use this for initialization
	void Start () {

        joyStick.SetActive(false);

        var temporizador = Instantiate(this.temporizador);
        var scriptTemporizador = temporizador.gameObject.GetComponent<Temporizador>();
        scriptTemporizador.onFinish = EnableGame;
	}
	
    void EnableGame()
    {
        joyStick.SetActive(true);
    }

    public void FimDeJogo()
    {
        joyStick.SetActive(false);
        Instantiate(btnFimJogo);
    }

}
