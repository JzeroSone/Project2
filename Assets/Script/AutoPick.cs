using UnityEngine;

public class AutoPick : MonoBehaviour
{
    public float speed = 20.0f;
    public Transform target;
    public bool flag = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (flag == true)
        {
            if (distance < 0.1f)
            {
                Destroy(gameObject);
            }
            Vector3 _direction = target.position - transform.position;
            
            transform.position += _direction.normalized * speed * Time.deltaTime;
        }
        else if(distance < target.GetComponent<Player>().radius)
        {
            Pick();
        }
    }

    public void Pick()
    {
        flag = true;
    }
}
