using UnityEngine;
using System; // Import the System namespace for Math functions

public class RewardSpawner : MonoBehaviour
{
    [SerializeField] private float spawn_period_ = 0.5f; // spawn reward every 1 second
    private float last_spawn_time_ = 0f; // last time a reward was spawned
    [SerializeField] private GameObject[] reward_prefabs_; // prefab of the reward to be spawned
    [SerializeField] private int remaining_reward_waves_ = 50; // maximum number of reward waves to spawn

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - last_spawn_time_ >= spawn_period_)
        {
            SpawnReward(); // Call the method to spawn a reward
            last_spawn_time_ = Time.time; // Update the last spawn time
            remaining_reward_waves_--; // Decrease the number of reward waves left to spawn
            spawn_period_ = Math.Max(0.01f, spawn_period_ - 0.01f); // Decrease the spawn period by 0.01 seconds, but not less than 0

            if (remaining_reward_waves_ == 0) {
                GameManager.instance.SetGameOver(); // Call the method to set the game over state in the GameManager
                Destroy(gameObject); // Destroy the RewardSpawner object
            }
        } 
    }

    void SpawnReward()
    {
        // Check if the time since the last spawn is greater than the spawn time

        // create random position x, where x = [-2.5, 2.5]
        float x = UnityEngine.Random.Range(-2.5f, 2.5f);
        float y = transform.position.y;

        // create a new position vector
        Vector3 position = new Vector3(x, y, 0); // z is 0

        // Instantiate the reward prefab at the new position with no rotation
        float rand_value = UnityEngine.Random.value; // Generate a random value between 0 and 1
        int random_index;
        if (rand_value < 0.5) random_index = 0;
        else if (rand_value < 0.75) random_index = 1;
        else if (rand_value < 0.9) random_index = 2;
        else random_index = 3;
        Instantiate(reward_prefabs_[random_index], position, Quaternion.identity);
    }
}
