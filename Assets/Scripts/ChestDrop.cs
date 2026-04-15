using UnityEngine;

public class ChestDrop : MonoBehaviour
{
    [SerializeField] private GameObject itemDrop;
    [SerializeField] private float force = 5f;
    [SerializeField] private float upwardBoost = 1.5f;

    public void Drop()
    {
        if (itemDrop == null) return;

        GameObject item = Instantiate(itemDrop, transform.position, Quaternion.identity);

        Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Random horizontal direction
            float randomX = Random.Range(-1f, 1f);

            // Combine sideways + upward force
            Vector2 direction = new Vector2(randomX, upwardBoost).normalized;

            rb.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}