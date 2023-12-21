using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this);
    }

    public void GameOver()
    {
        //TODO -> add game over scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}