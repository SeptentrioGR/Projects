using UnityEngine;

public class Sun_Rotation : MonoBehaviour
{
    public float rotationSpeed;
    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, (rotationSpeed * Time.deltaTime));
    }

}
