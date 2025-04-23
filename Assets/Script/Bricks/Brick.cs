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
                ParentObj.SetActive(false);
        }
    }
}
//using TMPro;
//using UnityEngine;

//public class Brick : MonoBehaviour
//{
//    public int health = 1;
//    public TextMeshPro valueText;
//    public GameObject ParentObj;

//    private void Awake()
//    {
//        if (valueText == null)
//            valueText = GetComponentInChildren<TextMeshPro>();
//    }

//    public void SetValue(int value)
//    {
//        health = value;
//        valueText.text = value.ToString();
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("cloneBall"))
//        {
//            health--;
//            valueText.text = health.ToString();
//            if (health <= 0)
//                ParentObj.SetActive(false);
//        }
//    }
//}





















//using TMPro;
//using UnityEngine;

//public class Brick : MonoBehaviour
//{
//    public int value;
//    public TextMeshPro valueText;

//    public void SetValue(int val)
//    {
//        value = val;
//        UpdateText();
//    }

//    void UpdateText()
//    {
//        if (valueText != null)
//            valueText.text = value.ToString();
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("cloneBall"))
//        {
//            value--;
//            UpdateText();

//            if (value <= 0)
//            {
//                gameObject.SetActive(false); 
//            }
//        }
//    }
//}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;
//public class Brick : MonoBehaviour
//{
//     public int hit;
//     public TMP_Text hitText;
//     public bool isBallMultiplier = false;

//     public void Init(int value, bool isPowerUp = false)
//     {
//         hit = value;
//         isBallMultiplier = isPowerUp;
//         UpdateText();
//         Hit();
//         gameObject.SetActive(true); //gcw;ljfewf
//     }

//     private void Hit()
//     {
//         hit--;
//         UpdateText();

//         if (hit <= 0)
//         {
//             gameObject.SetActive(false); 
//         }
//     }

//     private void UpdateText()
//     {
//           if (hitText != null)
//             hitText.text = hit.ToString();
//     }
//}
//using UnityEngine;
//using TMPro;

//public class Brick : MonoBehaviour
//{
//    public int brickValue;
//    public TextMeshPro valueText;

//    public void SetValue(int value)
//    {
//        brickValue = value;
//        if (valueText != null)
//            valueText.text = value.ToString();
//    }

//    public void ResetBrick()
//    {

//        gameObject.SetActive(false);
//    }

//    public void OnHit()
//    {

//        ResetBrick();
//    }
//}
