using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EndCard : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private CanvasGroup _gameOverGroup;

    public event UnityAction RestartButtonClicked;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartButtonClicked);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartButtonClicked);
    }

    private void Start()
    {
        _gameOverGroup.alpha = 0;
    }

    public void Show()
    {
        _gameOverGroup.alpha = 1;
        _restartButton.gameObject.SetActive(true);
    }
}
