using System.Collections;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Ins;//dat instance cho script => co the goi tu bat cu dau

    public int currentHealth;
    public int maxHealth;
    public bool isLive;
    public Rigidbody2D rb;
    public float invicible;
    public Material material; // Chat lieu cua nguoi choi

    private void Awake()
    {
        Ins = this;
    }

    private void OnEnable()
    {
        isLive = true;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        invicible -= Time.deltaTime;
        if (invicible <= 0) invicible = 0;
    }

    public void TakeDamage(int value)
    {
        if (isLive && invicible <=0)
        {
            invicible = 3;
            currentHealth -= value;
            StartCoroutine(TakeDamageFX());
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isLive = false;
                PlayerManager.Ins.OnLose();
            }

            PlayerHealthUI.Ins.StartCoroutine(PlayerHealthUI.Ins.SetUp());
        }
    }

    public void OnHealth(int value)
    {
        if (isLive)
        {
            currentHealth += value;
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }

            PlayerHealthUI.Ins.StartCoroutine(PlayerHealthUI.Ins.SetUp());
        }
    }

    IEnumerator TakeDamageFX()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Material defaultMaterial = spriteRenderer.material;//Default material
        Material flickerMaterial = material;//materual mau do
        float flickerDuration = 0.5f;
        int flickerCount = 3;

        for (int i = 0; i < flickerCount; i++)
        {
            spriteRenderer.material = flickerMaterial;
            yield return new WaitForSeconds(flickerDuration);
            spriteRenderer.material = defaultMaterial;
            yield return new WaitForSeconds(flickerDuration);
        }
        spriteRenderer.material = defaultMaterial;
    }
}
