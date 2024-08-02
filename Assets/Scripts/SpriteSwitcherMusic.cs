using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcherMusic : MonoBehaviour
{
    public Image enabledObject; // Первый спрайт
    public Image disabledObject; // Второй спрайт

    [SerializeField] private Sprite _onSprite, _ofSprite;

    private bool isSprite1Active = true; // Для отслеживания текущего спрайта
    private Image buttonImage; // Компонент Image у кнопки

    void Start()
    {

        enabledObject.gameObject.SetActive( SoundService.IsMusicOn);
        disabledObject.gameObject.SetActive(! SoundService.IsMusicOn);
    }

    public void SwitchSprite()
    {
        isSprite1Active = !isSprite1Active;
        SoundService.IsMusicOn = isSprite1Active;

        enabledObject.gameObject.SetActive( SoundService.IsMusicOn);
        disabledObject.gameObject.SetActive(! SoundService.IsMusicOn);
    }
}