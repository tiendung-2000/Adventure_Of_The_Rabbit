using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; //Toc do cua player
    public float jumpSpeed = 8f; //Chieu cao nhay cua player
    private float direction = 0f; //Huong di chuyen
    public float groundCheckRadius;
    private bool isTouchingGround; // Dung de check xem nguoi choi co cham vao mat dat hay khong
    private bool facingRight = true; // Check nguoi choi co dang quay mat ve ben phai

    private Rigidbody2D player; //Rigidbody => Tac dong, su dung vat ly len player
    public Animator animator; //Dung de dieu khien animation cua doi tuong bang code
    public Transform groundCheck; //La 1 game object co chua tranform, khi tuong tasc voi mat dat se check xem do co phai la mat dat hay khong
    public LayerMask groundLayer; //Layer cua ground la gi
    public PlayerHealthController healthController;// Quan ly mau cua nguoi choi

    void Start() //Star se chay 1 lan duy nhat khi vua vao game hoac khi doi tuong duoc bat len
    {
        player = GetComponent<Rigidbody2D>();// De gan component Rigidbody vao bien "player"
    }
    void Update()//La 1 ham, chay 60 lan /1 giay
    {
        if (!healthController.isLive)//Check tu script healthcontroller xem nguoi choi co con song hay khong
        {
            healthController.rb.velocity = Vector3.zero; //Set velocity = 0 => de nguoi choi khong di chuyen duoc
            return;// De dung script tai dong nay
        }
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxisRaw("Horizontal");//giup nguoi choi di chuyen trai phai

        animator.SetFloat("Speed", Mathf.Abs(direction));

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            animator.SetBool("isJumping", true);
        }
    }
    private void FixedUpdate()
    {
        if (!facingRight && direction > 0)
        {
            Flip();
        }
        else if (facingRight && direction < 0)
        {
            Flip();
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }


    //public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    //}
}