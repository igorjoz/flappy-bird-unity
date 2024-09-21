using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource backgroundMusic;  // Referencja do komponentu AudioSource
    public Button muteButton;            // Referencja do przycisku mute/unmute
    public Sprite soundOnIcon;           // Ikona dla stanu "d�wi�k w��czony"
    public Sprite soundOffIcon;          // Ikona dla stanu "d�wi�k wyciszony"

    private bool isMuted = false;        // Zmienna �ledz�ca, czy d�wi�k jest wyciszony

    void Start()
    {
        // Ustawienie stanu pocz�tkowego (d�wi�k w��czony)
        UpdateButtonIcon();

        // Dodaj listener do przycisku
        muteButton.onClick.AddListener(ToggleSound);
    }

    // Funkcja prze��czaj�ca d�wi�k
    public void ToggleSound()
    {
        isMuted = !isMuted;  // Zmie� stan wyciszenia
        backgroundMusic.mute = isMuted;  // Ustaw wyciszenie AudioSource

        // Zaktualizuj ikon� przycisku
        UpdateButtonIcon();
    }

    // Funkcja aktualizuj�ca ikon� przycisku
    void UpdateButtonIcon()
    {
        if (isMuted)
        {
            muteButton.image.sprite = soundOffIcon;  // Ustaw ikon� wyciszenia
        }
        else
        {
            muteButton.image.sprite = soundOnIcon;  // Ustaw ikon� d�wi�ku
        }
    }
}
