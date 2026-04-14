using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
 public bool gettingKnockedBack { get; private set; }


 [SerializeField] private float knockBackTime = 0.2f;
 private Rigidbody2D rb;

 private void Awake()
 {
  rb = GetComponent<Rigidbody2D>();
 }

 public void GetKnockedBack(Transform damageSource, float KnockBackThrust)
    {
        gettingKnockedBack = true;
        Vector2 difference = (transform.position - damageSource.position).normalized * KnockBackThrust * rb.mass;
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockBackRoutine());
    }

    private IEnumerator KnockBackRoutine()
    {
        yield return new WaitForSeconds(knockBackTime);
        rb.linearVelocity = Vector2.zero;
        gettingKnockedBack = false;
    }   


}
