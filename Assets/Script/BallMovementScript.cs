using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Slider slider;
    [SerializeField] private float speed = 1;
    [SerializeField] private float sliderValue;
    private Vector2 startPos;
    private bool isMoving;
    private Vector2 newStartPos;
   Vector2 endPos;
   private float _laserLength;
   private  LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        sliderValue = slider.value;
        transform.rotation = Quaternion.Euler(0, 0, -sliderValue * 25);
        if (Input.GetMouseButtonUp(0) && !isMoving)
        {
            isMoving = true;
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }

    }

    //  void FixedUpdate()
    // {
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.up,200f);
    //     
    //     if (hit)
    //     {
    //         line.SetPosition(0, hit.point);
    //         //line.SetPosition(1, hit.transform.position);
    //         
    //         Debug.DrawRay(startPos, transform.up, Color.yellow);
    //     }
    //     // RaycastHit2D hit = Physics2D.Linecast(startPos, new Vector2(0,15));
    //     //
    //     // if (hit)
    //     // {
    //     //     Debug.DrawLine(startPos, hit.point, Color.red);
    //     // }
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            newStartPos = transform.position;
           rb.velocity = Vector2.zero;
           slider.value = 0;
           transform.position = new Vector2(newStartPos.x, newStartPos.y);
           isMoving = false;
           Debug.Log("Position Reset");
        }
    }
    
}
