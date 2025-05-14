using System;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private  int health = 1;
    [SerializeField] private TextMeshPro valueText;
    [SerializeField] private  GameObject HighscorePanel;
    [SerializeField] private  GameObject ScorePanel;
    [SerializeField] private  SpriteRenderer spriteRenderer;


    public void SetValue(int value)
    {
        health = value;
        valueText.text = value.ToString();
        
    }

    private void Update()
    {
        
        if (health <= 3)
        {
            spriteRenderer.color = Color.cyan;
        }
        else if (health  > 3 && health <= 8 )
        {
            spriteRenderer.color = Color.yellow;
        }
        else if (health   >8 &&   health <= 12)
        {
            spriteRenderer.color = Color.Lerp(Color.yellow, Color.green, 0.5f);
        }
        else if (health > 12 && health <= 100)
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("cloneBall"))
        {
            health--;
            valueText.text = health.ToString();

            
            if (health <= 0)
            {
                  gameObject.SetActive(false);
                      if (valueText != null)
                          valueText.text = "";
            }

            if (health == 0)
            {
                    ScoreScript.Instance.Incrementer();
            }
            AudioMangerScript.Instance.PlayOneShot(AudioType.BALL);
     
        }
        
        if (collision.gameObject.CompareTag("WallCollider"))
        {
            AudioMangerScript.Instance.PlayOneShot(AudioType.WALLHIT);
        }
    }
}
