using UnityEngine;

public class Debug_Gizmo : MonoBehaviour
{
    public Color mColor;
    public Vector3 size;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = mColor;
        Gizmos.DrawCube(transform.position, size);
    }


}
