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


    [Header("Raycast")]
    private RaycastHit2D ray;
    [SerializeField] private LayerMask layermask;
    private float angle;
    [SerializeField] Vector2 minMaxAngle;

    [SerializeField] private bool useRay;
    [SerializeField] private bool useLine;
    [SerializeField] LineRenderer line;
    void Start()
    {
    
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    
    {
        if (Input.GetMouseButton(0))
        {
            
        ray = Physics2D.Raycast(transform.position, transform.up, 20f, layermask);
       // Debug.DrawRay(transform.position, ray.point, Color.red);
        
            Vector2 reflactpos = Vector2.Reflect(new Vector3(ray.point.x, ray.point.y, 0) -transform.position, ray.normal);
            Vector3 pos =  transform.up * reflactpos.y + transform.position;
            Vector2 direction = Input.mousePosition - pos;

            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            if (angle >= minMaxAngle.x && angle <= minMaxAngle.y)
                
            {
                Debug.DrawRay(transform.position, transform.up * ray.distance, Color.red);
                Debug.DrawRay(ray.point, reflactpos.normalized * 2f, Color.green);
            }

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        }
        
    }
    
    void Update()
    {
        sliderValue = slider.value;
        transform.rotation = Quaternion.Euler(0, 0, -sliderValue * 45);
        if (Input.GetMouseButtonUp(0) && !isMoving)
        {
            isMoving = true;
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }
    
    }

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
