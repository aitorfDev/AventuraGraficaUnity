using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemType
{
    Item,
    Interactuable,
    Other
}

public enum SpecialItems
{
    Trampilla,
    GrifoDerecho,
    Grifo,
    Abuela,
    Alfombra
}
public class OnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ItemType itemType;

    [SerializeField] private bool hasUse = false;
    [SerializeField] private bool hasPickup = false;
    [SerializeField] private bool hasTalk = false;

    [SerializeField][TextArea] private string dialogUseText = "He podido usar, vamos a ver que nos depara";
    [SerializeField][TextArea] private string dialogWatchText = "Es algo interesante";
    [SerializeField][TextArea] private string dialogTalkText = "Que cuentas ahora?";

    [SerializeField][TextArea] private string dialogNoUseText = "No puedo usar eso";
    [SerializeField][TextArea] private string dialogNoPickupText = "No puedo coger eso";
    [SerializeField][TextArea] private string dialogNoTalkText = "No puedo hablar con eso";

    [SerializeField][TextArea] private string dialogNoItemText = "No puedo usar este objeto aqui";

    [SerializeField] private ItemName interactsWith = ItemName.Nada;
    public void OnPointerClick(PointerEventData pointerEventData)
    {

        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            ButtonState estadoActual = GameManager.Instance.CurrentState;

            switch (estadoActual)
            {
                case ButtonState.MirarClicked:

                    Dialog dialogWatch = new Dialog
                    {
                        text = dialogWatchText,
                    };
                    GameManager.Instance.SetDialog(dialogWatch);
                    break;


                case ButtonState.UsarClicked:

                    if (hasUse)
                    {
                        Dialog dialogUse = new Dialog
                        {
                            text = dialogUseText,
                        };
                        GameManager.Instance.SetDialog(dialogUse);
                    }
                    else
                    {
                        Dialog dialogNoUse = new Dialog
                        {
                            text = dialogNoUseText,
                        };
                        GameManager.Instance.SetDialog(dialogNoUse);
                    }
                    break;

                case ButtonState.CogerClicked:

                    if (hasPickup)
                    {
                        ItemInfo info = gameObject.GetComponent<ItemInfo>();
                        GameManager.Instance.InventoryAdd(gameObject);
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        Dialog dialogNoPickup = new Dialog
                        {
                            text = dialogNoPickupText,
                        };
                        GameManager.Instance.SetDialog(dialogNoPickup);
                    }
                    break;

                case ButtonState.HablarClicked:
                    if (hasTalk)
                    {
                        Dialog dialogTalk = new Dialog
                        {
                            text = dialogTalkText,
                            personaje = Personajes.Abuela
                        };
                        GameManager.Instance.SetDialog(dialogTalk);

                        // Wait for dialog to en 
                    }
                    else
                    {
                        Dialog dialogNoTalk = new Dialog
                        {
                            text = dialogNoTalkText,
                        };
                        GameManager.Instance.SetDialog(dialogNoTalk);
                    }
                    break;

                case ButtonState.ItemClicked:
                    if(GameManager.Instance.ActualItemClicked == interactsWith)
                    {
                        switch (interactsWith)
                        {
                            case ItemName.Cuchillo:
                                
                                AudioManager.Instance.emitAudio(Audios.KillGranny);
                                GameSceneManager.Instance.LoadFinalGranny();

                                break;
                            case ItemName.Grifo:
                                AudioManager.Instance.emitAudio(Audios.Key);
                                GameManager.Instance.DisableGrifo();

                                break;

                            case ItemName.Llave:
                                AudioManager.Instance.emitAudio(Audios.Hatch);
                                GameSceneManager.Instance.LoadFinalChilds();
                                break;

                        }
                    }
                    else
                    {
                        Dialog diag = new Dialog
                        {
                            text = dialogNoItemText,
                        };
                        GameManager.Instance.SetDialog(diag);
                    }


                        break;


            }


        }
    }
}