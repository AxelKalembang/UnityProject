using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 7;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private Material blinkMaterial; 
    [SerializeField] private Material redFlashMaterial; 

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    public bool isInvincible = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void SetBlinkMaterial(Material material)
    {
        blinkMaterial = material;
    }

    public void SetRedFlashMaterial(Material material)
    {
        redFlashMaterial = material;
    }

    public void TriggerInvincibility()
    {
        if (!isInvincible)
        {
            StartCoroutine(BlinkingEffect());
        }
    }

    private IEnumerator BlinkingEffect()
    {
        isInvincible = true;

       
        if (redFlashMaterial != null)
        {
            spriteRenderer.material = redFlashMaterial;
            yield return new WaitForSeconds(blinkInterval);
        }

        
        for (int i = 0; i < blinkingCount; i++)
        {
            spriteRenderer.material = (i % 2 == 0) ? blinkMaterial : originalMaterial;
            yield return new WaitForSeconds(blinkInterval);
        }

        
        spriteRenderer.material = originalMaterial;
        isInvincible = false;
    }
}
