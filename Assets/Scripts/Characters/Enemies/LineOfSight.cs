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
        if (other.gameObject.GetComponent<Character>() && !targetIsOnSight)
        {
            targetIsOnSight = true;

            if (ai.target == null)
            {
                ai.setTarget(other.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Character>() && targetIsOnSight)
        {
            targetIsOnSight = false;
        }
    }

    public bool isTargetOnSight()
    {
        return targetIsOnSight;
    }

}
