using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuManager : MonoBehaviour
{
    private VisualElement _ui;
    private Button _playButton;
    private Button _creditsButton;
    private Button _quitButton;

    private const string GAME_SCENE = "GameScene";

    private void Awake()
    {
        _ui = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        _playButton = _ui.Q<Button>("PlayButton");
        _creditsButton = _ui.Q<Button>("CreditsButton");
        _quitButton = _ui.Q<Button>("QuitButton");

        _playButton.clicked += OnPlayButtonClicked;
        _creditsButton.clicked += OnCreditsButtonClicked;
        _quitButton.clicked += OnQuitButtonClicked;
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(GAME_SCENE);
    } 

    private void OnCreditsButtonClicked()
    {
        Debug.Log("Credits");
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #endif
    }
}
