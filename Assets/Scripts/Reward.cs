using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private int score_ = 1; // Score to be added when the reward is collected
    [SerializeField] private float move_speed_ = 2f; // Speed of the reward movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // For each unit time, it move up
        Vector3 pos_delta = new Vector3(0, move_speed_ * Time.deltaTime, 0); // Create a new vector for the movement direction
        // Create rotation around the Z axis 
        Quaternion rotation = Quaternion.Euler(0, 0, 45 * Time.deltaTime); // Create a rotation around the Z axis

        transform.position += pos_delta;
        transform.rotation *= rotation; // Apply the rotation to the reward object
        if (transform.position.y >= 10f) // If the reward has moved up by 10 units
        {
            // Destroy the reward object
            Destroy(gameObject); // Destroy the reward object
        }
    }

    public int GetScore()
    {
        return score_; // Return the score of the reward
    }
}
