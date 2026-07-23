using UnityEngine;
using UnityEngine.UI;

public class MainMenuBtnActions : MonoBehaviour
{
    [SerializeField] private GameObject CreditMenu;
    [SerializeField] private Sprite MusicOnSprite, MusicOffSprite, SfxOnSprite, SfxOffSprite;
    [SerializeField] private Image MusicImage, SfxImage;
    public void OnPlayerBtnPressed()
    {
        GameSceneManager.Instance.TransitionWithReplaceScene("MainMenu", "level 1", 0.5f, true);
    }

    public void OnCreditBtnPressed()
    {
        CreditMenu.SetActive(!CreditMenu.activeSelf);
    }

    public void OnMusicBtbPressed()
    {
        SettingManager.Instance.ToggleMusic();
        MusicImage.sprite = SettingManager.Instance.Music ? MusicOnSprite : MusicOffSprite;
    }

    public void OnSFXBtnPressed()
    {
        SettingManager.Instance.ToggleSFX();
        SfxImage.sprite = SettingManager.Instance.Sfx ? SfxOnSprite : SfxOffSprite;
    }

    public void OnQuitBtnPressed()
    {
        Application.Quit();
    }
}
