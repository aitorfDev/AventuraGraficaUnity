using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public enum ButtonType
{
    Nada,
    Iniciar,
    TextoInicio,
    Reiniciar,
}
public class OnClickScene : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private ButtonType btType = ButtonType.Nada;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Botón clickeado: " + btType);
            switch (btType)
            {
                case ButtonType.Nada:
                    break;
                case ButtonType.Iniciar:
                    GameSceneManager.Instance.LoadIntro();

                    break;
                case ButtonType.TextoInicio:
                    GameSceneManager.Instance.LoadMain();

                    break;
                case ButtonType.Reiniciar:
                    GameSceneManager.Instance.LoadMenu();
                    break;

                default:
                    break;
            }




        }
    }
}