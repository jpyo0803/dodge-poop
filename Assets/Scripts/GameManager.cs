using UnityEngine;
using TMPro; // Import the TextMeshPro namespace for UI text handling

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; // Singleton instance of the GameManager
    private int score_ = 0; // Player's score

    [SerializeField] private TextMeshProUGUI score_text_; // Reference to the UI text element for displaying the score

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void UpdateScore(int score) {
        score_ += score; // Update the score by adding the new score
        Debug.Log("Score: " + score_); // Log the updated score
        score_text_.SetText(score_.ToString()); // Update the UI text element with the new score
    }
}
