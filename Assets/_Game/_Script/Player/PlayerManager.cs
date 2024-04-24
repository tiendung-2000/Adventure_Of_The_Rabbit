using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Ins;

    public GameObject gameOverScreen;
    public static Vector2 lastCheckPointPos = new Vector2(-3, 8);

    private void Awake()
    {
        Ins = this;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnLose()
    {
        StartCoroutine(ShowLoseUI());
    }

    public IEnumerator ShowLoseUI()
    {
        yield return new WaitForSeconds(1);
        gameOverScreen.SetActive(true);
    }
}

