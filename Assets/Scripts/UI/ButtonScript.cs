using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _clicked = false;

    public UnityEvent OnClicked;

    public void OnPointerDown(PointerEventData eventData)
    {
        _clicked = true;
        transform.Translate(Vector3.down);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_clicked)
        {
            transform.Translate(Vector3.up);
            _clicked = false;
            OnClicked?.Invoke();
        }
    }
}
