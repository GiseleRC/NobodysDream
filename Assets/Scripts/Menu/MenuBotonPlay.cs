using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuBotonPlay : MonoBehaviour
{
    public GameObject controls;
    public AudioSource Click;
  public void ChangeSceneStart(string Level1)
    {
        SceneManager.LoadScene(Level1);
        Click.Play();
    }

    public void ShowControls()
    {
        controls.SetActive(true);
        Click.Play();
    }

    public void ExiGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetButtonDown("CancelTutorial&Pause"))
        {
            Click.Play();
            controls.SetActive(false);
        }
        
    }
}
