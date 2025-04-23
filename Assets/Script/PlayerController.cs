using DamageNumbersPro;
using HighlightPlus;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Player player;
    Renderer boundaryRenderer;
    Vector3 _direction;
    FloatingBar healthBar;
    FloatingBar expBar;
    ShowText goldNumber;
    ShowText levelNumber;
    LevelUpAnimation levelUpAnimation;
    Animator animator;
    Vector3 mousePosition;

    void Awake()
    {
        healthBar = GetComponentInChildren<FloatingBar>();
        expBar = GameObject.Find("FloatingExpBar").GetComponent<FloatingBar>();
        goldNumber = GameObject.Find("GoldNumber").GetComponentInChildren<ShowText>();
        levelNumber = GameObject.Find("LevelNumber").GetComponent<ShowText>();
        player = GetComponent<Player>();
        boundaryRenderer = GameObject.FindWithTag("Boundary").GetComponent<Renderer>();
        levelUpAnimation = GetComponent<LevelUpAnimation>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        healthBar.UpdateBar(player.healthPoint, player.maxHealthPoint);
        expBar.UpdateBar(player.experience, player.maxHealthPoint);
        _direction = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("isMove", true);
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            _direction = mousePosition - transform.position;
            if(Vector3.Angle(Vector3.up, _direction) <= 45f)
            {
                animator.SetInteger("Direction", 1);
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", 1);
            }
            else if(Vector3.Angle(Vector3.down, _direction) <= 45f)
            {
                animator.SetInteger("Direction", 0);
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", -1);
            }
            else if (Vector3.Angle(Vector3.left, _direction) <= 45f)
            {
                animator.SetInteger("Direction", 3);
                animator.SetFloat("MoveX", -1);
                animator.SetFloat("MoveY", 0);
            }
            else if (Vector3.Angle(Vector3.right, _direction) <= 45f)
            {
                animator.SetInteger("Direction", 2);
                animator.SetFloat("MoveX", 1);
                animator.SetFloat("MoveY", 0);
            }
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Vector3.Distance(transform.position, mousePosition) < 0.1f)
        {
            _direction = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _direction.y = 1;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 1);
        }else if (Input.GetKey(KeyCode.S))
        {
            _direction.y = -1;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction.x = -1;
            animator.SetFloat("MoveX", -1);
            animator.SetFloat("MoveY", 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _direction.x = 1;
            animator.SetFloat("MoveX", 1);
            animator.SetFloat("MoveY", 0);
        }
        animator.SetBool("isMove", _direction.magnitude > 0);
        GetComponent<Draw>().DrawCircle(transform.position, player.attackRange * (player.attackRangeBonus + 1));
    }

    void FixedUpdate()
    {
        float movementSpeed = player.movementSpeed * (player.movementSpeedBonus + 1);
        transform.position += _direction.normalized * movementSpeed * Time.fixedDeltaTime;
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
            TakeDamage(damage * Time.deltaTime);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        player.healthPoint -= damageAmount;
        healthBar.UpdateBar(player.healthPoint, player.maxHealthPoint);
        if (player.healthPoint <= 0)
        {
            player.healthPoint = 0f;
            Die();
        }
    }

    public void AddLoot(Loot loot)
    {
        switch (loot.type)
        {
            case Loot.Type.gold: player.gold += loot.value;
                goldNumber.UpdateText(player.gold.ToString());
                break;
            case Loot.Type.exp: player.experience += loot.value;
                if(player.experience >= player.maxExperience)
                {
                    player.experience -= player.maxExperience;
                    player.level++;
                    levelNumber.UpdateText("LV." + player.level);
                    levelUpAnimation.LevelUp();
                }
                expBar.UpdateBar(player.experience, player.maxExperience);
                break;
        }
    }

    public void Die()
    {

    }
}
