using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuButtonController : MonoBehaviour
{
    void Start()
    {
    }

    public void Load()
    {
        SceneManager.LoadScene("GameRoom");
    }

    public void Leave()
    {
        Application.Quit();
    }
}