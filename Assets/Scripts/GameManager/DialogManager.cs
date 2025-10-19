using System.Collections;
using System.Collections.Generic;
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
    private Queue<Dialog> dialogQueue = new Queue<Dialog>();

    public static DialogManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        speakerDialogBox.text = "";
        textDialogBox.text = "";
        imageComponent = charImage.GetComponent<Image>();
    }

    public void setDialog(Dialog dialog)
    {
        dialogQueue.Enqueue(dialog);

        // Si no hay ningún diálogo escribiéndose, iniciar uno
        if (!isTyping)
        {
            StartCoroutine(ProcessNextDialog());
        }
    }

    private IEnumerator ProcessNextDialog()
    {
        while (dialogQueue.Count > 0)
        {
            Dialog dialog = dialogQueue.Dequeue();
            yield return StartCoroutine(TypeText(dialog));
        }
    }

    private IEnumerator TypeText(Dialog dialog)
    {
        isTyping = true;
        SetButtonsInteractable(false);

        // Imagen del personaje
        switch (dialog.personaje)
        {
            case Personajes.Detective:
                imageComponent.sprite = spriteDetective;
                break;
            case Personajes.Abuela:
                imageComponent.sprite = spriteAbuela;
                break;
            default:
                imageComponent.sprite = spriteNull;
                break;
        }

        // Nombre del hablante
        speakerDialogBox.text = string.IsNullOrEmpty(dialog.speakerName)
            ? ""
            : $"{dialog.speakerName} : ";

        // Texto con efecto de escritura
        textDialogBox.text = "";
        foreach (char c in dialog.text)
        {
            textDialogBox.text += c;
            yield return new WaitForSeconds(0.5f / dialog.textSpeed);
        }

        // Fin del diálogo
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

        btMirar.colors = colorBlock;
        btUsar.colors = colorBlock;
        btCoger.colors = colorBlock;
        btHablar.colors = colorBlock;
        btInventario.colors = colorBlock;
    }
}
