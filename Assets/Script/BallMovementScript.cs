using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallMovementScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1;
    [SerializeField] private  bool isIdle;
    [SerializeField] private  Vector2 newStartPos;
    [SerializeField] private  Vector2 endPos;
    public float sliderValue;
    public   Slider slider;
    public bool isMoving;
    
    [Space]
    [Space]
    
    [Header("Raycast")] 
    [SerializeField] private  LayerMask layermask;
    [SerializeField] private   RaycastHit2D ray;
    [SerializeField] private  float angle;
    [SerializeField] private Vector2 minMaxAngle;

    [Space]
    [Space]
   
    [Header("LineRenderer")] 
    [SerializeField] private LineRenderer line;
    [SerializeField] private bool useRay;
    [SerializeField] private bool useLine;

    [Space]
    [Space]
    
    [Header("Ball Prefab")]
    [SerializeField] SpriteRenderer sprite;
    public List<GameObject> ballClone;
    public bool _isCloned;
    public int _ballcount = 1;
    public int presentBallCount;
    public bool canForceDownBall = true; 
    public Vector2 startPos;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        line = GetComponent<LineRenderer>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        line.enabled = false;
        _isCloned = false;
        AudioMangerScript.Instance.BackgroundMusic(AudioType.BACKGROUND);

    }

    public void RayCheck()

    {
        bool anyBallActive = false;

        foreach (GameObject ball in ObjectPool.Instance.pooledObjects)
        {
            if (ball.activeInHierarchy)
            {
                anyBallActive = true;
                break;
            }
        }
        if (Input.GetMouseButton(0) && !isMoving && sliderValue !=0 && !anyBallActive  ) 
        {
            line.enabled = true;
            // sprite.enabled = true;

            ray = Physics2D.Raycast(transform.position, transform.up, 20f, layermask);
            // Debug.DrawRay(transform.position, ray.point, Color.red);

            Vector2 reflactpos = Vector2.Reflect(new Vector3(ray.point.x, ray.point.y, 0) - transform.position, ray.normal);
            Vector3 pos = transform.up * reflactpos.y + transform.position;
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
                line.positionCount = 3;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, ray.point);
                line.SetPosition(2, ray.point + reflactpos.normalized * 2f);
            }

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
        else
        {
            line.enabled = false;
            //sprite.enabled = false;
        }
    }

    void Update()
    {
        bool anyBallActive = false;

        foreach (GameObject ball in ObjectPool.Instance.pooledObjects)
        {
            if (ball.activeInHierarchy)
            {
                anyBallActive = true;
                break;
            }
        }
        RayCheck();
        sliderValue = slider.value;
        transform.rotation = Quaternion.Euler(0, 0, -sliderValue * 80);
        if (Input.GetMouseButtonUp(0) && !isMoving && sliderValue !=0 && !anyBallActive)
        {
            

            StartCoroutine(Shootball());
            isMoving = true;
            canForceDownBall = false;
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);

        }


    }

    IEnumerator Shootball()
    {
        Vector2 shootPosition = transform.position;
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < _ballcount; i++)
        {

            GameObject ball = ObjectPool.Instance.GetPooledObject();
            if (ball != null)
            {
                ball.transform.position = shootPosition;
                ball.SetActive(true);
                ballClone.Add(ball);
            }

            Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();

            ballRb.AddForce(transform.up * speed, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.1f);

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallCollider"))
        {
            AudioMangerScript.Instance.PlayOneShot(AudioType.WALLHIT);
        }

        if (collision.gameObject.CompareTag("ground"))
        {

            newStartPos = transform.position;
            rb.velocity = Vector2.zero;
            slider.value = 0;
            transform.position = new Vector2(newStartPos.x, newStartPos.y);
            isMoving = false;
            canForceDownBall = true;
            Debug.Log("Position Reset");
            line.transform.position = transform.position;
            
            foreach (var balls in ballClone)
            {

                presentBallCount++;

            }
            Debug.Log(presentBallCount);
            
            if (!isMoving)
            {
                // line.enabled = true;
                Debug.Log(gameObject.name);
            }
        }
    }


    //Ball multiplier detection
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Multiplier"))
        {
            _ballcount++;
            Debug.Log("  Ball Count: " + _ballcount);
        }
    }
}
