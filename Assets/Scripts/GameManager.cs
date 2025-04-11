using UnityEngine;
using TMPro; // Import the TextMeshPro namespace for UI text handling
using UnityEngine.SceneManagement; // Import the SceneManagement namespace for scene handling

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; // Singleton instance of the GameManager
    private int score_ = 0; // Player's score

    [HideInInspector] public bool is_game_over_ = false; // Flag to check if the game is over

    [SerializeField] private TextMeshProUGUI score_text_; // Reference to the UI text element for displaying the score

    [SerializeField] private GameObject game_over_panel_; // Reference to the game over panel UI element

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        game_over_panel_.SetActive(false); // Activate the game over panel UI element
    }

    public void UpdateScore(int score) {
        score_ += score; // Update the score by adding the new score
        Debug.Log("Score: " + score_); // Log the updated score
        score_text_.SetText(score_.ToString()); // Update the UI text element with the new score
    }

    public void SetGameOver() {
        is_game_over_ = true; // Set the game over flag to true
        Debug.Log("Game Over!"); // Log the game over message

        Invoke("ShowGameOverPanel", 6f); // Invoke the ShowGameOverPanel method after a delay of 1 second
    }

    void ShowGameOverPanel() {
        game_over_panel_.SetActive(true); // Activate the game over panel UI element
    }

    public void PlayAgain() {
        SceneManager.LoadScene("SampleScene"); // Reload the current scene to restart the game
    }
}
