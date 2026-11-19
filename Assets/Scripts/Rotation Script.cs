using UnityEngine;

public class RotationScript : MonoBehaviour
{
 public float rotationSpeed = 90f;

    void Update()
    {
        // Непрерывное вращение вокруг оси Z
        transform.Rotate(  0 , 0 ,rotationSpeed* Time.deltaTime );
    }
}
