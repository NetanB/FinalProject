using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   [SerializeField] private int startingHealth = 3;
   [SerializeField] private GameObject deathVFXPrefab;

   private int currentHealth;
   private KnockBack knockBack;
   private Flash flash;

   private void Awake()
   {
    flash = GetComponent<Flash>();
    knockBack = GetComponent<KnockBack>();
   }


   public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockBack.GetKnockedBack(PlayerController.Instance.transform, 15f);
        StartCoroutine(flash.FlashRoutine());
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0){
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        
        }
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }
}
