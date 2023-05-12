using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBotonPlay : MonoBehaviour
{
    public AudioSource Click;
  public void ChangeSceneStart(string Level1)
    {
        SceneManager.LoadScene(Level1);
        Click.Play();
    }
}
