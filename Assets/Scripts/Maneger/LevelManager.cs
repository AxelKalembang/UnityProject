using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator;


    void Awake(){
        animator.enabled = false;  // Menonaktifkan animator pada awal game agar tidak langsung memainkan animasi
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        animator.enabled = true; // Mengaktifkan animator untuk transisi
        animator.SetTrigger("EndTransition");
        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(sceneName);

    }
}
