using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float move_speed_ = 5f; // Speed of the background movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // For each unit time, it will move up by move_speed_ units
        transform.position += new Vector3(0, move_speed_ * Time.deltaTime, 0);
        if (transform.position.y >= 10f) // If the background has moved up by 10 units
        {
            transform.position = new Vector3(0, -10f, 0); // Reset the position to the bottom
        }
    }
}
