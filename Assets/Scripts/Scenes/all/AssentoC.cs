using UnityEngine;

public class AssentoC : MonoBehaviour {

    public bool ocupado;
    public GameObject objOcupado;
    public GameObject center;

    private GameObject origem;

    public void Sentar(GameObject obj, bool right)
    {
        this.origem = Instantiate(center, obj.transform.position, obj.transform.rotation);
        objOcupado = obj;
        ocupado = true;

        objOcupado.transform.position = new Vector3()
        {
            x = this.center.transform.position.x,
            y = this.center.transform.position.y,
            z = this.center.transform.position.z,
        };

        var angleY = right ? 90 : -90;

        obj.transform.localRotation *= Quaternion.Euler(0, angleY, 0);
    }

    public void Levantar(bool right)
    {
        ocupado = false;
        objOcupado.transform.position = new Vector3()
        {
            x = origem.transform.position.x,
            y = origem.transform.position.y,
            z = origem.transform.position.z,
        };

        Destroy(this.origem);

        var angleY = right ? -90 : 90;

        objOcupado.transform.localRotation *= Quaternion.Euler(0, angleY, 0);
    }
}
