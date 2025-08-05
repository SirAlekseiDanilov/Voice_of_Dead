using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    /// <summary>
    /// ���� �����.
    /// </summary>
    public int HitPoints => currentHealth;
    /// <summary>
    /// ����������� ��������� ���-�� ����� ����� (�� ������).
    /// </summary>
    private int maxHealth;
    /// <summary>
    /// ������� ���-�� ������ ������ � UI.
    /// </summary>
    public Slider healthSlider;

    /*
    private void Awake() {
        healthSlider = GameObject.FindGameObjectWithTag("UI_H").GetComponent<Slider>();
    }
    */

    private void Start() {
        maxHealth = currentHealth;
    }

 
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth / (float)maxHealth; 
        if (currentHealth <= 0) {
            Dead();
        } ;
    }

    private void Dead() {
        Destroy(gameObject);
        EventDeath?.Invoke();
    }

    [SerializeField] private UnityEvent EventDeath;
    public UnityEvent EventOnDeath => EventDeath;
}