using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int score = 0; // biến để lưu điểm số của người chơi
    [SerializeField] private TextMeshProUGUI scoreText; // biến để hiển thị điểm số trên giao diện người dùng
    [SerializeField] private GameObject gameOverUI; // biến để hiển thị giao diện kết thúc game
    [SerializeField] private GameObject gameWinUI;
    private bool isGameOver = false; // biến để kiểm tra trạng thái kết thúc game
    private bool isGameWin = false;
                                     
    void Start()
    {
        UpdateScore();
        gameOverUI.SetActive(false); // ẩn giao diện kết thúc game khi bắt đầu
        gameWinUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int points)
    {
        if (!isGameOver && !isGameWin)
        {
            score += points; // cộng điểm số vào biến score
            UpdateScore();

        }
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f; // tiếp tục thời gian trong game
    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString(); // cập nhật điểm số trên giao diện người dùng
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0f; // tạm dừng thời gian trong game
        gameOverUI.SetActive(true); // hiển thị giao diện kết thúc game
    }
    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0f; // tạm dừng thời gian trong game
        gameWinUI.SetActive(true);
    }
    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1f; // tiếp tục thời gian trong game
        SceneManager.LoadScene("Game");
    }
    public bool IsGameOver() {
        return isGameOver;
    }
        public bool IsGameWin()
        {
            return isGameWin;
    }
}
