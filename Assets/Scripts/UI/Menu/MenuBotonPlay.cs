using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuBotonPlay : MonoBehaviour
{
    public GameObject controls;
    public AudioSource click;
    bool controlsTutorial;
    public void ChangeSceneStart(string Level1)
    {
        SceneManager.LoadScene(Level1);
        click.Play();
    }
    public void ShowControls()
    {
        controls.SetActive(true);
        click.Play();
    }
    public void HideControls()
    {
        if(controls.activeInHierarchy)
        {
            controls.SetActive(false);
            click.Play();
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            click.Play();
            controls.SetActive(false);
        }
    }

    public void Continue()
    {
        PauseState currentPauseState = PauseStateManager.Instance.CurrentPauseState;
        PauseState newPauseState = currentPauseState == PauseState.Paused
            ? PauseState.Gameplay
            : PauseState.Paused;

        PauseStateManager.Instance.SetState(newPauseState);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
