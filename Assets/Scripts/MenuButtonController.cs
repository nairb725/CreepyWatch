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
        Debug.Log("start");
        SceneManager.LoadScene("GameRoom");
    }

    public void Leave()
    {
        Debug.Log("leave");

        Application.Quit();
    }
}