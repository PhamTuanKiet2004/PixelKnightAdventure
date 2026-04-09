using UnityEngine;

public class PlayerCollision : MonoBehaviour
{ 
    private GameManager gameManager;
    private AudioManager audioManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    // phương thức để xử lý khi player va chạm với các vật thể khác
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            audioManager.playCoinSound();
            gameManager.AddScore(1); // gọi phương thức AddScore của GameManager để cộng điểm số
        } else if (collision.CompareTag("Trap"))
        {
            gameManager.GameOver(); // gọi phương thức GameOver của GameManager để kết thúc game
        } else if (collision.CompareTag("Enermy"))
        {
            gameManager.GameOver();
        }
        else if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            gameManager.GameWin();

        }
    }
}
