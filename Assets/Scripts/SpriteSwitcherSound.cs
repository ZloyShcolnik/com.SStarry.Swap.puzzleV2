using UnityEngine.UI;
using UnityEngine;

public class SpriteSwitcherSound : MonoBehaviour
{
    public Image enabledObject; // Первый спрайт
    public Image disabledObject; // Второй спрайт

    [SerializeField] private Sprite _onSprite, _ofSprite;

    private bool isSprite1Active = true; // Для отслеживания текущего спрайта
    private Image buttonImage; // Компонент Image у кнопки

    void Start()
    {
        enabledObject.gameObject.SetActive(SoundService.IsSoundOn);
        disabledObject.gameObject.SetActive(!SoundService.IsSoundOn);
    }

    public void SwitchSprite()
    {
        isSprite1Active = !isSprite1Active;
        SoundService.IsSoundOn = isSprite1Active;

        enabledObject.gameObject.SetActive(SoundService.IsSoundOn);
        disabledObject.gameObject.SetActive(!SoundService.IsSoundOn);
    }
}
