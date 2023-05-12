using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBotonPlay : MonoBehaviour
{
    public AudioSource Click;
  public void ChangeSceneStart(string EntregaProgramacion2)
    {
        SceneManager.LoadScene(EntregaProgramacion2);
        Click.Play();
    }
}
