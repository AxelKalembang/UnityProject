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

    Vector2 minScreenBounds;
    Vector2 maxScreenBounds;
    float objectWidth;
    float objectHeight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        // Menentukan batas layar berdasarkan ukuran kamera
        Camera mainCamera = Camera.main;
        minScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.z));
        maxScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.z));

        // Mendapatkan lebar dan tinggi dari collider pesawat untuk penyesuaian
        objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        Move();
        ClampPosition();
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

void ClampPosition()
{
    
    float marginX = objectWidth * 1.2f; 
    float marginY = objectHeight * 1.2f; 

    Vector3 clampedPosition = transform.position;
    clampedPosition.x = Mathf.Clamp(clampedPosition.x, minScreenBounds.x + marginX, maxScreenBounds.x - marginX);
    clampedPosition.y = Mathf.Clamp(clampedPosition.y, minScreenBounds.y + marginY, maxScreenBounds.y - marginY);
    
    transform.position = clampedPosition;
}

}
