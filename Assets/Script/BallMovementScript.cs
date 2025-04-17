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
    public GameObject BallGameObject;


    [Header("Raycast")]
    [SerializeField] private LayerMask layermask;
    private RaycastHit2D ray;
    private float angle;
    [SerializeField] Vector2 minMaxAngle;

    [Header("LineRenderer")]
    [SerializeField] LineRenderer line;
    [SerializeField] private bool useRay;
    [SerializeField] private bool useLine;
    
    [Header("Ball Prefab")]
    [SerializeField] private GameObject ballPreab;
    [SerializeField] private int _ballcount  =  1;
    void Start()
    {
     
        line = GetComponent<LineRenderer>();
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
                if (useRay)
                {
                 Debug.DrawRay(transform.position, transform.up * ray.distance, Color.red);
                 Debug.DrawRay(ray.point, reflactpos.normalized * 2f, Color.green);
            
                }

            if (useLine)
            {
                line.SetPosition(0, transform.position);
                line.SetPosition(1, ray.point);
                line.SetPosition(2, ray.point + reflactpos.normalized * 2f);
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
            StartCoroutine(Shootball());
            isMoving = true;
            if (isMoving)
            {
                 line.enabled = false;
                 Debug.Log(gameObject.name );
            }
          
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
                        
        }


    }

    IEnumerator Shootball()
    {
        for (int i = 0; i < _ballcount; i++)
        {
            yield return new WaitForSeconds(0.08f);
            GameObject ball = Instantiate(ballPreab, transform.position, Quaternion.identity);
            Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
            ballRb.AddForce(transform.up * speed, ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(BallGameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

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
           line.transform.position = transform.position;
           if (!isMoving)
           {
                line.enabled = true;
               Debug.Log(gameObject.name );
           }
        }

        if (collision.gameObject.tag == "Multiplier")
        {
            _ballcount++;
            Debug.Log(_ballcount);
        }
    }
    
}
