using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private EndCard _endCard;
    [SerializeField] private Finish _finish;

    private void OnEnable()
    {
        _finish.Reached += OnReached;
        _endCard.RestartButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _finish.Reached -= OnReached;
        _endCard.RestartButtonClicked -= OnRestartButtonClick;
    }

    private void OnReached()
    {
        Time.timeScale = 0;
        _endCard.Show();
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
