using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catfood : MonoBehaviour
{
    public float despawnTime = 10f; // Adjust the time after which the Catfood will despawn
    public int catfoodValue = 100; // Adjust the amount of Catfood this prefab provides
    public float fadeDuration = 2f; // Adjust the duration of the fade effect

    private void Start()
    {
        // Schedule the Catfood to despawn after the specified time
        Invoke("DespawnCatfood", despawnTime);
    }

    private void OnMouseDown()
    {
        CollectCatfood();
    }

    private void DespawnCatfood()
    {
        // Start the fading effect
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;

        // Gradually reduce the alpha over the specified duration
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            Color fadedColor = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            spriteRenderer.color = fadedColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the alpha is completely 0 and destroy the Catfood
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        Destroy(gameObject);
    }

    private void CollectCatfood()
    {
        CatfoodBank catfoodBank = Object.FindFirstObjectByType<CatfoodBank>();
        if (catfoodBank != null)
        {
            catfoodBank.AddCatfood(catfoodValue);
            Destroy(gameObject);
            // The Catfood will now be destroyed through the FadeOut coroutine
        }
    }
}