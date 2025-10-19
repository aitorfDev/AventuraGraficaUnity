using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnInventoryClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject inventory;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            inventory.SetActive(!inventory.activeSelf);

            Debug.Log("Inventario");

        }
    }
}