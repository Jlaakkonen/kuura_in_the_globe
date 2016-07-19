using UnityEngine;
using System.Collections;

public class ChooseLevel : MonoBehaviour
{


	public void ChangeToScene(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
	}

    //IEnumerator ChangeToScene(string sceneToChangeTo)
    //{
    //    //        Application.LoadLevel(sceneToChangeTo);
    //    AsyncOperation async = Application.LoadLevelAdditiveAsync(sceneToChangeTo);
    //    yield return async;
    //    Debug.Log("Loading complete");
    //}
}
