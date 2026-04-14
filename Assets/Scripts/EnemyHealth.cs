using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   [SerializeField] private int startingHealth = 3;

   private int currentHealth;


   public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (currentHealth <= 0){
            Debug.Log("Enemy died!");
            Destroy(gameObject);
        
        }
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }
}
