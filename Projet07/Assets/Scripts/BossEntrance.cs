using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEntrance : MonoBehaviour
{
    [SerializeField, Scene] private string _bossLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        SceneManager.LoadScene(_bossLevel);
    }
}