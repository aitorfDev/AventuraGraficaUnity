using UnityEngine;
using UnityEngine.EventSystems;

public enum Escena
{
    cocina,
    comedor,
    vestibulo,
    exterior,
    vestibuloAnimado
}

public class OnClickFlecha : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Escena escenaEscogida;
    [SerializeField] private Animator animacion;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if ( GameManager.Instance.CurrentState != ButtonState.NadaClicked)
            return;

        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            switch (escenaEscogida)
            {
                case Escena.cocina:
                    CameraManager.Instance.MoverACocina();
                    break;

                case Escena.comedor:
                    CameraManager.Instance.MoverAComedor();
                    break;

                case Escena.vestibulo:
                    CameraManager.Instance.MoverAVestibulo();
                    break;

                case Escena.exterior:
                    CameraManager.Instance.MoverAExterior();
                    break;

                case Escena.vestibuloAnimado:
                    Debug.Log("Vestíbulo Animado");
                    animacion.SetTrigger("Caminar");
                    break;
            }
            
            GameManager.Instance.ClearDialog();
        }
    }
}
