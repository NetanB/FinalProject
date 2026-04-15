using UnityEngine;

public class Destructible : MonoBehaviour 
{
    [SerializeField] private GameObject destroyVFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DamageSource>())
        {
            Instantiate(destroyVFX, transform.position, Quaternion.identity);

            // 👇 Call ChestDrop if it exists
            ChestDrop drop = GetComponent<ChestDrop>();
            if (drop != null)
            {
                drop.Drop();
            }

            Destroy(gameObject);
        }
    }
}