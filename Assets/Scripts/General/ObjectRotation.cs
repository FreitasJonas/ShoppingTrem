using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float vel_x = 0;
    public float vel_y = 0;
    public float vel_z = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(vel_x, vel_y, vel_z);
    }
}
