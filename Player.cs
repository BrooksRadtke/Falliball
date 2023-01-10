using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //[SerializeField] private LayerMask platformsLayerMask;
    private Rigidbody rb;
    public float jumpVelocity;
    public float gravityScale = 1f;
    public static float globalGravity = -9.81f;
        
    public float speed;
    public float maxSpeed;
    public float dashSpeed;
    public float dashTime;
    public static float distanceTraveled;

    public bool isOnGround = true;
    public bool jump = false;
    public bool dash = false;

    private SphereCollider sphereCollider;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
        sphereCollider = transform.GetComponent<SphereCollider>();
    }

    private void Start()
    {
        StartCoroutine(InputLogic());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
        
        // Gravity
        Vector2 gravity = globalGravity * gravityScale * Vector2.up;
        rb.AddForce(gravity, ForceMode.Acceleration);

        // If player position is below N, Game over!
        if(rb.position.y < -7f)
        {
            FindObjectOfType<GameManager>().GameOver();
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private IEnumerator InputLogic()
    {
        while(true)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X)) && isOnGround)
            {
                rb.velocity = Vector2.up * jumpVelocity;
                isOnGround = false;
                jump = true;
                GetComponent<AudioSource>().Play();
            }
            else
            {
                jump = false;
            }

            if(Input.GetKeyDown(KeyCode.Z))
            {
                rb.velocity = Vector2.right * jumpVelocity;
                dash = true;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

    // Automated player movement and tracking position
    public void PlayerMovement()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        // This might be where the respawn bug is occuring from!!
        transform.position = transform.position + new Vector3();
        distanceTraveled = transform.localPosition.x;

        //if (jump)
        //{
        //    rb.velocity = Vector2.up * jumpVelocity;
        //    isOnGround = false;
        //}

        // Increment speed over time
        if (speed < maxSpeed)
        {
            speed += Time.deltaTime * .25f;
        }

        // Player Dash
        //if (dash)
        //{
        //    rb.velocity = Vector2.right * jumpVelocity;
        //}
    }
}
