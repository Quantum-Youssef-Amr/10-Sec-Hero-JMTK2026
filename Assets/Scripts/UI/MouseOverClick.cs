using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverClick : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private AudioClip MouseClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySound(MouseClick);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySound(MouseClick);
    }
}
