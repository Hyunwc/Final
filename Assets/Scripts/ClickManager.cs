using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickManager : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SceneChanageMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SceneChanageBack()
    { 
        SceneManager.LoadScene("Start");
    }
    // Start is called before the first frame update

}
