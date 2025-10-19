using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class OnClickItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string speakerNameParam = "Tú";
    [SerializeField] private string textParam = "Donde quieres usar el item?";
    [SerializeField] private int textSpeedParam = 3;
    private ButtonState newState = ButtonState.ItemClicked;
    [SerializeField] private ItemName itemNa;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            DialogManager dialogManager = FindFirstObjectByType<DialogManager>();
            DialogManager.Instance.ResetButtons();

            if (GameManager.Instance.ActualItemClicked == itemNa)
            {
                GameManager.Instance.ActualItemClicked = ItemName.Nada;
                GameManager.Instance.SetState(ButtonState.NadaClicked);
                GameManager.Instance.ClearDialog();
                return;
            }
            
            Button button = GetComponent<Button>();
               
            Dialog dialogo = new Dialog
            {
                speakerName = speakerNameParam,
                text = textParam,
                textSpeed = textSpeedParam
            };

            dialogManager.setDialog(dialogo);
            GameManager.Instance.SetState(newState);
            
            GameManager.Instance.ActualItemClicked = itemNa;




        }
    }
}