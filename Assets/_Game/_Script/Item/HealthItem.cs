using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthValue;
    public bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController _player = other.GetComponent<PlayerHealthController>();
            if (!isCollected)
            {
                isCollected = true;
                _player.OnHealth(healthValue);

                Destroy(gameObject);
            }
        }
    }
}
