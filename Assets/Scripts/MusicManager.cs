using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource backgroundMusic;  // Referencja do komponentu AudioSource
    public Button muteButton;            // Referencja do przycisku mute/unmute
    public Sprite soundOnIcon;           // Ikona dla stanu "dŸwiêk w³¹czony"
    public Sprite soundOffIcon;          // Ikona dla stanu "dŸwiêk wyciszony"

    private bool isMuted = false;        // Zmienna œledz¹ca, czy dŸwiêk jest wyciszony

    void Start()
    {
        // Ustawienie stanu pocz¹tkowego (dŸwiêk w³¹czony)
        UpdateButtonIcon();

        // Dodaj listener do przycisku
        muteButton.onClick.AddListener(ToggleSound);
    }

    // Funkcja prze³¹czaj¹ca dŸwiêk
    public void ToggleSound()
    {
        isMuted = !isMuted;  // Zmieñ stan wyciszenia
        backgroundMusic.mute = isMuted;  // Ustaw wyciszenie AudioSource

        // Zaktualizuj ikonê przycisku
        UpdateButtonIcon();
    }

    // Funkcja aktualizuj¹ca ikonê przycisku
    void UpdateButtonIcon()
    {
        if (isMuted)
        {
            muteButton.image.sprite = soundOffIcon;  // Ustaw ikonê wyciszenia
        }
        else
        {
            muteButton.image.sprite = soundOnIcon;  // Ustaw ikonê dŸwiêku
        }
    }
}
