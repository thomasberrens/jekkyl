using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDetail : MonoBehaviour
{
    public bool IsLoaded { get; private set; }
    
    public void LoadScene()
    {
        if (!IsLoaded)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            IsLoaded = true;

            var currScene = SceneManager.GetSceneByName(gameObject.name);
            var savableEntities = FindObjectsOfType<SavableEntity>().Where(x => x.gameObject.scene == currScene).ToList();
        }
    }

    public void UnloadScene()
    {
        if (IsLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            IsLoaded = false;
        }
    }
}
