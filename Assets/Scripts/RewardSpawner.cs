using UnityEngine;

public class RewardSpawner : MonoBehaviour
{
    [SerializeField] private float spawn_time_ = 1f; // spawn reward every 1 second
    private float last_spawn_time_ = 0f; // last time a reward was spawned
    [SerializeField] private GameObject reward_prefab_; // prefab of the reward to be spawned

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - last_spawn_time_ >= spawn_time_)
        {
            SpawnReward(); // Call the method to spawn a reward
            last_spawn_time_ = Time.time; // Update the last spawn time
        }
    }

    void SpawnReward()
    {
        // Check if the time since the last spawn is greater than the spawn time

        // create random position x, where x = [-2.5, 2.5]
        float x = Random.Range(-2.5f, 2.5f);
        float y = transform.position.y;

        // create a new position vector
        Vector3 position = new Vector3(x, y, 0); // z is 0

        // Instantiate the reward prefab at the new position with no rotation
        GameObject reward = Instantiate(reward_prefab_, position, Quaternion.identity);
    }
}
