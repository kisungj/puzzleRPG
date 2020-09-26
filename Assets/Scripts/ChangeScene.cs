using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void StageScene1()
    {
        SceneManager.LoadScene(2);
    }

    public void StageScene2()
    {
        SceneManager.LoadScene(3);
    }

    public void StageScene3()
    {
        SceneManager.LoadScene(4);
    }
}
