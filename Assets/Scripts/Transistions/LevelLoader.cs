using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1f;
    void Update()
    {
    }

    public void LoadLevelAnimation(string LevelName)
    {
        StartCoroutine(LoadLevel(LevelName));
    }

    IEnumerator LoadLevel(string LevelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelName);
    }
}