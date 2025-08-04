using UnityEngine;

public class Damage : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    GameObject Player;
    Health Health;

    float timer;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Health = Player.GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == Player)
        {
            Attack();
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (Health.currentHealth <= 0)
        {
            // TODO: add death script here.
        }
    }

    void Attack()
    {
        timer = 0f;
        if (Health.currentHealth > 0)
        {
            Health.TakeDamage(attackDamage);
        }
    }
}