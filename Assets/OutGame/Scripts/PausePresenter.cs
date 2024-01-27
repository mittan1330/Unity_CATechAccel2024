using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePresenter : MonoBehaviour
{
    [SerializeField] private PauseView _view;

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (_view.pauseUIInstance == null)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        _view.makePauseUI();
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _view.destroyPauseUI();
        Time.timeScale = 1;
    }
}
