using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health = 1;
    public TextMeshPro valueText;
    public GameObject ParentObj;
    
    public void SetValue(int value)
    {
        health = value;
        valueText.text = value.ToString();
      
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
            AudioMangerScript.Instance.PlayOneShot(AudioType.BALL);
                //ParentObj.SetActive(false);
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("EndTrigger"))
    //     {
    //         gameObject.SetActive(false);
    //     }
    // }
}

