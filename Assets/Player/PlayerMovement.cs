using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isGrounded;

    public Transform groundCheckTransform;
    public float groundCheckRadius;
    public LayerMask groundMask;
    public Transform sprite;

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position += Vector3.right * 8.6f * Time.deltaTime;

        if (isGrounded)
        {
            // pris d'une vidéo pour la rotation ainsi que les valeurs pour la vitesse et jump
            Vector3 Rotation = sprite.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
            sprite.rotation = Quaternion.Euler(Rotation);

            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * 26.6581f, ForceMode2D.Impulse);
            }
        }
        else
        {
            sprite.Rotate(Vector3.back);
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundMask);
    }

}
