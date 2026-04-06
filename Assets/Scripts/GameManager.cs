using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0; // biến để lưu điểm số của người chơi
    [SerializeField] private TextMeshProUGUI scoreText; // biến để hiển thị điểm số trên giao diện người dùng
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int points)
    {
                score += points; // cộng điểm số vào biến score
                UpdateScore();

    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString(); // cập nhật điểm số trên giao diện người dùng
    }
}
