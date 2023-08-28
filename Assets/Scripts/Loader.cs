using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader
{
    //Loader class to manage the loading of scenes

    //enum to hold all the possible values for the scene to load. allows for only certain scenes/text to be used for the parameters of Load()
    public enum Scene
    {
        Level1,
    }
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
