using System.Collections; 
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Personajes
{
    Detective,
    Abuela,
    Nada
}   
public class Dialog
{
    public string speakerName;
    public string text;
    public int textSpeed;
    public Personajes personaje;
    public Dialog()
    {
        speakerName = "Tú";
        text = "";
        textSpeed = 5;
        personaje = Personajes.Detective;

    }
}

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject charImage;
    private Image imageComponent;

    [SerializeField] private TMP_Text speakerDialogBox;
    [SerializeField] private TMP_Text textDialogBox;

    [SerializeField] private Button btMirar;
    [SerializeField] private Button btUsar;
    [SerializeField] private Button btCoger;
    [SerializeField] private Button btHablar;
    [SerializeField] private Button btInventario;

    [SerializeField] private Sprite spriteDetective;
    [SerializeField] private Sprite spriteAbuela;
    [SerializeField] private Sprite spriteNull;

    private bool isTyping = false;

    public static DialogManager Instance { get; private set; }
    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speakerDialogBox.text = "";
        textDialogBox.text = "";

        imageComponent = charImage.GetComponent<Image>();
    }

    public void setDialog(Dialog dialog)
    {
        
        if (dialog.personaje == Personajes.Detective)
        {
            imageComponent.sprite = spriteDetective;
        }
        else if (dialog.personaje == Personajes.Abuela)
        {
            imageComponent.sprite = spriteAbuela;

        }
        else
        {
            imageComponent.sprite = spriteNull;
        }

        if (!isTyping)
        {
            isTyping = true;
            SetButtonsInteractable(false);

            // Actualiza el nombre del hablante
            if(dialog.speakerName != "")
            {
                speakerDialogBox.text = $"{dialog.speakerName} : ";

            }
            else{
                speakerDialogBox.text = dialog.speakerName;

            }

            // Inicia la corrutina para escribir el texto
            StartCoroutine(TypeText(dialog));
        }
    }

    private IEnumerator TypeText(Dialog dialog)
    {
        textDialogBox.text = "";

        foreach (char c in dialog.text)
        {
            textDialogBox.text += c;
            yield return new WaitForSeconds(0.5f/dialog.textSpeed); 
        }
        SetButtonsInteractable(true);

        isTyping = false;
    }
    private void SetButtonsInteractable(bool value)
    {
        btMirar.interactable = value;
        btUsar.interactable = value;
        btCoger.interactable = value;
        btHablar.interactable = value;
        btInventario.interactable = value;
    }

    public void ResetButtons()
    {
 
        Color normalColor = Color.white;

        ColorBlock colorBlock = btMirar.colors;
        colorBlock.normalColor = normalColor;

        // Assign the modified ColorBlock to all buttons
        btMirar.colors = colorBlock;
        btUsar.colors = colorBlock;
        btCoger.colors = colorBlock;
        btHablar.colors = colorBlock;
        btInventario.colors = colorBlock;

        return;
        
    }
}
