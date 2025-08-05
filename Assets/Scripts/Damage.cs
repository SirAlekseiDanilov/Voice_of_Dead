using UnityEngine;

public class Damage : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    private GameObject Player;
    private Health Health;

    float timer;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Health = Player.GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == Player & timer > timeBetweenAttacks)
        {
            Attack();
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    void Attack()
    {
        //print(timer);
        timer = 0f;
        if (Health.HitPoints > 0) {
            Health.TakeDamage(attackDamage); // избыточно? не крутить разве анимацию урона
        }
    }
}