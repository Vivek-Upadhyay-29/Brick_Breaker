using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Slider slider;
    public float speed;
    [SerializeField] private float sliderValue;
    Vector2 startPos;
  Quaternion startRot;
    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.localRotation;
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        speed = 400f;
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = slider.value;
        transform.rotation = Quaternion.Euler(0, 0, -sliderValue * 25);
        if (Input.GetMouseButtonUp(0))
        {
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            //ball rotation working///
           rb.velocity = Vector2.zero;
           transform.position = new Vector2(startPos.x, startPos.y);
           Debug.Log("Position Reset");
        }
    }
}
