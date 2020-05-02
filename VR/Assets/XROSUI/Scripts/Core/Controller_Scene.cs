using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller_Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.F10))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.F11))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.F12))
        {
            SceneManager.LoadScene(3);
        }
    }

    public void LoadSceneById(int i)
    {
        SceneManager.LoadScene(i);
    }
}