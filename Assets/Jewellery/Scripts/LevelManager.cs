using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Level[] levelContainer;
    private int _currentLevel;
    //private Level _currentLevel;
   

    public Level GetCurrentLevel()
    {
        _currentLevel = PlayerPrefs.GetInt("Level",0);
        return levelContainer[_currentLevel];
    }

    public void ResetLevel()
    {
        if(_currentLevel < levelContainer.Length -1)
        {
            PlayerPrefs.SetInt("Level", ++_currentLevel);
            PlayerPrefs.Save();
        }
       
        //StartCoroutine(nameof(ResetL));
        SceneManager.LoadScene(0);
    }

    //private IEnumerator ResetL()
    //{
    //    yield return new WaitForSeconds(1f);
       
    //}

    private void GetLevel()
    {
        //Addressables.LoadAssetAsync<Level>(levelContainer[0]).Completed += OnLoadDone;
        //levelContainer[0].LoadAssetAsync<Level>().Completed += OnLoadDone;
    }   

    //private void OnLoadDone(AsyncOperationHandle<Level> obj)
    //{
    //    Debug.Log("load complete");
    //    _currentLevel = obj.Result;
    //}
}
