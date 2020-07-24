using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Level[] levelContainer;
    private int _currentLevel;

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
        SceneManager.LoadScene(0);
    }
}
