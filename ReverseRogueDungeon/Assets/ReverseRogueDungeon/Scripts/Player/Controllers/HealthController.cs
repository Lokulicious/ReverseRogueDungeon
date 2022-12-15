using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [Title("Settings")]
    [SerializeField] int maxHealth;
    private int health;
    [SerializeField][ColorPalette] Color damageColor;
    [SerializeField] private float damageAnimationTime;
    [SerializeField][ColorPalette] Color healColor;
    [SerializeField] private float healAnimationTime;


    [Title("References")]
    [SerializeField] GameObject HealthBar;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResetHealth();
    }


    public void Damage(int amount)
    {
        //deduct damage from health
        health -= amount;
        ColorCharacter(damageAnimationTime, damageColor);
    }

    public void Heal(int amount)
    {
        //add heal amount to health
        health += amount;
        ColorCharacter(healAnimationTime, healColor);
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

    public bool IsAlive()
    {
        //checks if health is above 0 and returns weather it is true
        if (health > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateHealthBar()
    {
        var rectTransform = (RectTransform)HealthBar.transform;
        var parentRectTransform = (RectTransform)rectTransform.parent.transform;

        rectTransform.sizeDelta = new Vector2(parentRectTransform.rect.width * health / maxHealth, parentRectTransform.rect.height);
    }

    IEnumerator ColorCharacter(float colorTime, Color color)
    {
        spriteRenderer.color = color;
        yield return new WaitForSeconds(colorTime);
        spriteRenderer.color = Color.white;
    }
}
