using UnityEngine;

public class TrapController : MonoBehaviour
{
    public int damage;
    public bool isDeadZone;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController _player = other.GetComponent<PlayerHealthController>();

            Rigidbody2D theRb = _player.rb;

            Transform trans = _player.transform;
            if (_player.invicible <= 0 || _player.isLive)
            {
                _player.TakeDamage(damage);
                theRb.AddForce((-trans.forward + new Vector3(0f, 3f, 0f)) * 2, ForceMode2D.Impulse);
            }
        }
    }
}
