using UnityEngine;

public class Enermy : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // tốc độ của kẻ địch
    [SerializeField] private float distance = 5f; // khoảng cách mà kẻ địch sẽ di chuyển trước khi đổi hướng
    private Vector3 startPosition; // vị trí ban đầu của kẻ địch
    private bool movingRight = true; // trạng thái di chuyển của kẻ địch
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float left = startPosition.x - distance;
        float right = startPosition.x + distance;
        if(movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= right)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= left)
            {
                movingRight = true;
                Flip();
            }
        }
    }
    void Flip() {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
