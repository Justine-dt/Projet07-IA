using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public void Restart() => GameManager.Instance.Restart();
    public void Quit() => Application.Quit();
}