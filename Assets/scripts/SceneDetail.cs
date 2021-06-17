using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDetail : MonoBehaviour
{
   // public bool IsLoaded { get; private set; }

   // List<SavableEntity> SavableEntities;
    
   // public void LoadScene()
  //  {
   //     if (!IsLoaded)
   //     {
    //        var operation = SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
     //       IsLoaded = true;

       //     operation.completed += (AsyncOperation op) =>
       //     {

       //     };

       //     SavableEntities = GetSavableEntitiesInScene();
     //       SavingSystem.i.RestoreEntityStates(SavableEntities);
    //    }
  //  }

  //  public void UnloadScene()
  //  {
  //      if (IsLoaded)
  //      {
   //         SavingSystem.i.CaptureEntityStates(SavableEntities);
            
    //        SceneManager.UnloadSceneAsync(gameObject.name);
    //        IsLoaded = false;

    //        var savableEntites = GetSavableEntitiesInScene();
    //    }
    //}

    //List<SavableEntity> GetSavableEntitiesInScene()
    //{
    //    var currScene = SceneManager.GetSceneByName(gameObject.name);
    //    var savableEntities = FindObjectsOfType<SavableEntity>().Where(x => x.gameObject.scene == currScene).ToList();
    //    return savableEntities;
    //}
}
