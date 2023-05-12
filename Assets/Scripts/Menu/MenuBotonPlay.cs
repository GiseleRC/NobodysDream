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

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Click.Play();
            controls.SetActive(false);
        }
        if (Input.GetButtonDown("ClickIz"))
        {
            Click.Play();
            controls.SetActive(false);
        }
    }
}
