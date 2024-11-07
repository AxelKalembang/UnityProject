using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void LoadScene(string Main)
    {
        Debug.Log("LoadScene called for scene: " + Main);
        StartCoroutine(LoadSceneAsync(Main));
    }

    private IEnumerator LoadSceneAsync(string Main)
    {
        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
        }

        yield return new WaitForSeconds(1f); 

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Main);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        if (animator != null)
        {
            animator.SetTrigger("EndTransition");
        }
    }
}
