using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField] private TextMeshProUGUI numberOfPlatforms, winText, gameOverText;
    [SerializeField] private int platformsCounter;

    [SerializeField] private GameObject pauseUI, gameOverUI;
    [SerializeField] private Button pauseButton;

    private void Awake()
    {
        instance = this;

        Time.timeScale = 1;
    }

    private void Start()
    {
        platformsCounter = TowerBuilder.numberOfPlatforms - 1;
    }

    private void Update()
    {
        numberOfPlatforms.text = platformsCounter.ToString();
        if (platformsCounter == 0) numberOfPlatforms.gameObject.SetActive(false);

    }

    public void DecreaseCounter()
    {
        platformsCounter--;
    }

    public void GameOver(Ball ball)
    {
        ShowFinalScreen(gameOverText, ball);
        AudioManager.instance.PlaySound(AudioManager.LOSE_SOUND);
    }

    public void FinishGame(Ball ball)
    {
        ShowFinalScreen(winText, ball);
        AudioManager.instance.PlaySound(AudioManager.WIN_SOUND);
    }

    public void PauseGame()
    {
        SwitchUI(pauseUI, true, false);
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        SwitchUI(pauseUI, false, true);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void SwitchUI(GameObject uiScreen, bool uiScreenVisibility, bool pauseButtonVisibility)
    {
        uiScreen.SetActive(uiScreenVisibility);
        pauseButton.gameObject.SetActive(pauseButtonVisibility);
    }
    private void ShowFinalScreen(TextMeshProUGUI finalText, Ball ball)
    {
        SwitchUI(gameOverUI, true, false);
        ball.gameObject.SetActive(false);
        finalText.gameObject.SetActive(true);
        numberOfPlatforms.gameObject.SetActive(false);
    }

}
