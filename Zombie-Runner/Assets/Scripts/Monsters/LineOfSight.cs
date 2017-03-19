using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private bool targetIsOnSight;
    private Enemy_AI ai;
    void Start()
    {
        ai = transform.GetComponentInParent<Enemy_AI>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerScript>() && !targetIsOnSight)
        {
            targetIsOnSight = true;

            if (ai.target == null)
            {
                Debug.Log("Found Something " + other.gameObject.name);
                ai.setTarget(other.gameObject);
            }



        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerScript>() && targetIsOnSight)
        {
            targetIsOnSight = false;
        }
    }

    public bool isTargetOnSight()
    {
        return targetIsOnSight;
    }

}
