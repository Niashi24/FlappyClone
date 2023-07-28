using Player;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerClickJump : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private PlayerStateMachine player;

    [SerializeField]
    private BoolReference paused;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (paused.Value) return;
        player.Flap();
    }
}
