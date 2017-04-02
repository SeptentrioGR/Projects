using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour
{
    CameraRaycaster camRaycaster;
    [SerializeField]
    Image Cross;
    [SerializeField]
    Sprite NoAction;
    [SerializeField]
    Sprite Interactable;
    [SerializeField]
    Sprite NotInteractable;
    [SerializeField]
    Sprite Attackable;
    [SerializeField]
    Sprite Unknown;
    [SerializeField]
    CursorMode cursorMode = CursorMode.Auto;
    [SerializeField]
    Vector2 hotSpot = new Vector2(0, 0);

    void Start()
    {
        camRaycaster = GetComponent<CameraRaycaster>();
        camRaycaster.onLayerChange += OnLayerChange;
    }

    void Update()
    {

    }


    private void OnLayerChange(Layer newLayer)
    {
        // print("Cursor over new Layer" + newLayer);
        switch (newLayer)
        {
            case Layer.World:
                Cross.sprite = NoAction;
                break;
            case Layer.Interactable:
                Cross.sprite = Interactable;
                break;
            case Layer.Monster:
                Cross.sprite = Attackable;
                break;
            case Layer.NotInteractable:
                Cross.sprite = NotInteractable;
                break;
            case Layer.RaycastEndStop:
                Cross.sprite = NoAction;
                break;
            default:
                Cross.sprite = NoAction;
                return;
        }
    }
}
