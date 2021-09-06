using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField] private TextMeshProUGUI numberOfPlatforms;
    [SerializeField] private int platformsCounter;

    [SerializeField] private GameObject pauseUI, gameOverUI;
    [SerializeField] private Button pauseButton;

    private void Awake()
    {
        instance = this;
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

    public void GameOver()
    {
        pauseButton.gameObject.SetActive(false);

    }

    public void FinishGame()
    {
        pauseButton.gameObject.SetActive(false);
    }


}
