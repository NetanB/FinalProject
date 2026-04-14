using System.Collections;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private float restoreDefaultMatTime = 0.2f;
    [SerializeField] private Material whiteFlashMat;

    private Material defaultMat;
    private SpriteRenderer spriteRenderer;
    private EnemyHealth enemyHealth;


    private void Awake()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMat = spriteRenderer.material;
        enemyHealth = GetComponent<EnemyHealth>();
    }

    public IEnumerator FlashRoutine()
    {
        spriteRenderer.material = whiteFlashMat;
        yield return new WaitForSeconds(restoreDefaultMatTime);
        spriteRenderer.material = defaultMat;
        enemyHealth.DetectDeath();
    }

}
