using UnityEngine;

public class World_Interaction
{
    public void hitSomethingInFrontOfMe(RaycastHit hit)
    {
        Debug.Log("Hit Something " + hit.collider.gameObject.name);
        if (hit.collider.GetComponent<Item>())
        {
            GameObject.Destroy(hit.collider.gameObject);
        }
    }
}
