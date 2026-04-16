using UnityEngine;

public class Pickup : MonoBehaviour
{
    private enum PickUpType { Books }

    [SerializeField] private float pickUpDistance = 5f;
    [SerializeField] private float accelerationRate = 5f;
    [SerializeField] private float maxSpeed = 10f;

    [SerializeField] private PickUpType pickUpType;

    private Vector3 moveDir;
    private float currentSpeed;
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Vector3 playerPos = PlayerController.Instance.transform.position;

        if (Vector3.Distance(transform.position, playerPos) < pickUpDistance) {
            moveDir = (playerPos - transform.position).normalized;
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, accelerationRate * Time.deltaTime);
        } else {
            moveDir = Vector3.zero;
            currentSpeed = 0f;
        }
    }

    private void FixedUpdate() {
        rb.linearVelocity = moveDir * currentSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerController>() != null) {
            DetectPickupType();
            Destroy(gameObject);
        }
    }

    private void DetectPickupType() {
        switch (pickUpType) {
            case PickUpType.Books:
                if (EconomyManager.Instance != null) {
                    EconomyManager.Instance.UpdateCurrentBooks();
                }
                break;
        }
    }
}