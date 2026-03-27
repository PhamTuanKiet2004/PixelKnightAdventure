using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // [Ser] là thuộc tính, Ser để trong giao diện unity vẫn sửa được speed
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private LayerMask groundLayer; // bộ lọc phân loại vật thể => đâu là mặt đất
    [SerializeField] private Transform groundCheck; // kiểu dữ liệu lưu trữ vị trí (x, y, z) của 1 vật thể => giải quyết vấn đề ở đâu
    private bool isGrounded;
    private Animator animator;

    private Rigidbody2D rb;
    private void Awake() // lấy tham chiếu
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimation();
    }
    private void HandleMovement() // phương thúc di chuyển nv
    {
        float moveInput = Input.GetAxis("Horizontal"); // di chuyển theo phương ngang nên là Horizontal
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }
    // cần giải quyết: kiểm tra ở đâu ? Đạp lên đâu thì là mặt đất
    private void HandleJump() // phương thức nhảy
    {
        if (Input.GetButtonDown("Jump") && isGrounded) // đây là button space
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); 
    }
    private void UpdateAnimation() // hàm này để chuyển đổi những animation trong game
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);

    }
}
