using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    [SerializeField] Vector2 maxSpeed;
    [SerializeField] Vector2 stopClamp;

    [SerializeField] Vector2 moveFriction;
    [SerializeField] Vector2 stopFriction;

    Vector2 moveVelocity;
    Vector2 moveDirection;
    Rigidbody2D rb;

    void Start()
    {
     
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }

    void Update()
    {
        
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
       
        if (moveDirection != Vector2.zero)
        {
            
            moveVelocity = moveDirection * maxSpeed;
        }
        else
        {
            
            Vector2 friction = GetFriction();
            moveVelocity -= friction * Time.deltaTime;

            
            if (moveVelocity.magnitude < stopClamp.magnitude)
            {
                moveVelocity = Vector2.zero;
            }
        }

        
        moveVelocity.x = Mathf.Clamp(moveVelocity.x, -maxSpeed.x, maxSpeed.x);
        moveVelocity.y = Mathf.Clamp(moveVelocity.y, -maxSpeed.y, maxSpeed.y);

        
        rb.velocity = moveVelocity;
    }

    Vector2 GetFriction()
    {
        
        if (moveDirection == Vector2.zero)
        {
            
            return new Vector2(rb.velocity.x * stopFriction.x, rb.velocity.y * stopFriction.y);
        }
        return Vector2.zero; 
    }

    public bool IsMoving()
    {
        
        return rb.velocity.magnitude > 0;
    }
}
