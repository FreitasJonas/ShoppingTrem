using UnityEngine;

public class audioCoinLimit : MonoBehaviour {

    private float limit = 1.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        limit -= Time.deltaTime;

        if (limit <= 0)
        {
            Destroy(this.gameObject);
        }
		
	}
}
