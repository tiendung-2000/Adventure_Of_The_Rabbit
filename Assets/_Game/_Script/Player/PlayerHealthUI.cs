using System.Collections;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    public static PlayerHealthUI Ins;

    public GameObject[] healthIcon;

    public PlayerHealthController _player;

    private void Awake()
    {
        Ins = this;
    }

    private void OnEnable()
    {
        if (_player == null)
        {
            _player = GetComponent<PlayerHealthController>();
        }
        SetUp();
    }

    public IEnumerator SetUp()
    {
        yield return new WaitForSeconds(.1f);
        for (int i = 0; i < healthIcon.Length; i++)
        {
            if (i < _player.currentHealth)
            {
                healthIcon[i].SetActive(true);
            }
            else
            {
                healthIcon[i].SetActive(false);
            }
        }
    }
}
