using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        if (animator != null)
        {
            animator.SetTrigger("StartTransition"); // Memulai animasi pada transisi
        }

        yield return new WaitForSeconds(1f); // Menunggu animasi untuk selesai (sesuaikan pada waktu ini)

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        if (animator != null)
        {
            animator.SetTrigger("EndTransition"); // Mengakhiri animasi pada transisi ini
        }
    }
}
