using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentHealth;
    private int health;
    //[SerializeField] private int health;
    public float flashSpeed = 5;
    public Slider healthSlider;
    public Color flashColour = new Color(1, 0, 0, 0.1f);

    private void Awake()
    {

        healthSlider = GameObject.FindGameObjectWithTag("UI_H").GetComponent<Slider>();
    }
    private void Start() {
        health = currentHealth;
    }

 
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        float sl = currentHealth / (float)health;
        print(currentHealth);
        print(health);
        print(sl);
        healthSlider.value = sl;
    }
}