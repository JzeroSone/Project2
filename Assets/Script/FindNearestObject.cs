using HighlightPlus;
using UnityEngine;

public class FindNearestObject : MonoBehaviour
{
    Player player;
    public GameObject nearestObject;

    void Start()
    {
        player = GetComponent<Player>();
    }
    void Update()
    {
        nearestObject = Find(transform.position, player.attackRange * (player.attackRangeBonus + 1));
    }

    GameObject Find(Vector3 center, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(center, radius);
        float minDistance = Mathf.Infinity;
        if(colliders.Length == 1)
        {
            if (nearestObject != null)
            {
                nearestObject.GetComponent<HighlightEffect>().highlighted = false;
            }
            nearestObject = null;
            return nearestObject;
        }
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                float distance = Vector3.Distance(center, collider.transform.position);
                if(distance < minDistance)
                {
                    if(nearestObject != null)
                    {
                        nearestObject.GetComponent<HighlightEffect>().highlighted = false;
                    }
                    minDistance = distance;
                    nearestObject = collider.gameObject;
                    nearestObject.GetComponent<HighlightEffect>().highlighted = true;
                }
            }
        }
        return nearestObject;
    }

}
