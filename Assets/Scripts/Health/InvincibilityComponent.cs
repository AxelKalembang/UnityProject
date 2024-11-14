using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 3; // Number of blinks during invincibility
    [SerializeField] private float blinkInterval = 0.1f; // Interval between blinks
    
    private SpriteRenderer spriteRenderer;
    public bool isInvincible = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        for (int i = 0; i < blinkingCount; i++)
        {
            // Toggle the sprite renderer visibility
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
        }

        // Ensure the sprite is visible and invincibility is turned off
        spriteRenderer.enabled = true;
        isInvincible = false;
    }
}
