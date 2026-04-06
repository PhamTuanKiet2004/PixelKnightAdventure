using UnityEngine;

public class PlayerCollision : MonoBehaviour
{ 
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    // phương thức để xử lý khi player va chạm với các vật thể khác
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            gameManager.AddScore(1); // gọi phương thức AddScore của GameManager để cộng điểm số
        }
    }
}
