using UnityEngine;
using UnityEngine.InputSystem;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject resetButton;
    private bool btState = false;
  
    private void Start()
    {
        resetButton.SetActive(btState);
    }

    private void Update()
    {
      
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            btState = !btState;
            resetButton.SetActive(btState);
        }
    }
}
