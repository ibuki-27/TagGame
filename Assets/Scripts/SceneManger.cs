using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    public void RestartGame()
    {
        // ƒQ[ƒ€‚ÌŠÔ‚ğŒ³‚É–ß‚·
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
