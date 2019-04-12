using UnityEngine;

public class audioBtnPressLimit : MonoBehaviour
{
    private float limit = 1.5f;

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;

        if (limit <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
