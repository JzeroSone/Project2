using DamageNumbersPro;
using HighlightPlus;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;
    private Renderer boundaryRenderer;
    private Vector3 _direction;

    void Start()
    {
        boundaryRenderer = GameObject.FindWithTag("Boundary").GetComponent<Renderer>();
    }

    void Update()
    {
        _direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _direction.y = 1;
        }else if (Input.GetKey(KeyCode.S))
        {
            _direction.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction.x = -1;
        }else if (Input.GetKey(KeyCode.D))
        {
            _direction.x = 1;
        }
        GetComponent<Draw>().DrawCircle(transform.position, player.attackRange);
    }

    void FixedUpdate()
    {
        transform.position += _direction.normalized * player.movementSpeed * Time.fixedDeltaTime;
        Bounds _bounds = GetComponent<Renderer>().bounds;
        Vector2 max = boundaryRenderer.bounds.max;
        Vector2 min = boundaryRenderer.bounds.min;
        transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, min.x + _bounds.size.x / 2, max.x - _bounds.size.x / 2),
                Mathf.Clamp(transform.position.y, min.y + _bounds.size.y / 2, max.y - _bounds.size.y / 2),
                transform.position.z
            );
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            float damageReduction = player.defence > 0 ? player.defence / (16.6f + player.defence) : Mathf.Pow(0.94f, Mathf.Abs(player.defence)) - 1;
            float damage = enemy.attackPower * (1 - damageReduction);
            if(player.healthPoint > damage * Time.deltaTime)
            {
                player.healthPoint -= damage * Time.deltaTime;
            }
            else
            {
                player.healthPoint = 0f;
            }
            
        }
    }
}
