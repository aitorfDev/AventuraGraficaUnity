using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class OnClickButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string speakerNameParam = "Error";
    [SerializeField] private string textParam = "Error";
    [SerializeField] private int textSpeedParam = 3;
    [SerializeField] private ButtonState newState = ButtonState.NadaClicked;

    private Color normalColor = Color.white;
    private Color clickedColor = Color.darkGreen;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            DialogManager.Instance.ResetButtons();

            DialogManager dialogManager = FindFirstObjectByType<DialogManager>();
            Button button = GetComponent<Button>();
            ColorBlock colorblock = button.colors;

            if (GameManager.Instance.CurrentState == newState)
            {

                colorblock.normalColor = normalColor;
                button.colors = colorblock;

                GameManager.Instance.SetState(ButtonState.NadaClicked);
                GameManager.Instance.ClearDialog();
                return;
            }
               
            Dialog dialogo = new Dialog
            {
                speakerName = speakerNameParam,
                text = textParam,
                textSpeed = textSpeedParam
            };

            colorblock.normalColor = clickedColor;
            button.colors = colorblock;

            dialogManager.setDialog(dialogo);
            GameManager.Instance.SetState(newState);




        }
    }
}