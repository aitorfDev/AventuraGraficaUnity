using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum ButtonState
{
    NadaClicked,
    HablarClicked,
    UsarClicked,
    MirarClicked,
    CogerClicked,
    ItemClicked
}
public enum ItemName
{
    Nada,
    Cuchillo,
    Grifo,
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public ButtonState CurrentState { get; private set; } = ButtonState.NadaClicked;
    public ItemName ActualItemClicked { get; private set; } = ItemName.Nada;


    private DialogManager dialogManager;
    private Stack<GameObject> inventory = new Stack<GameObject>();

    [SerializeField] private GameObject inventoryGrid;
    [SerializeField] private GameObject itemPickups;

    private TMP_Text textComponent;
    private Image imageComponent;

    void Awake()
    {
        textComponent = itemPickups.transform.Find("Text").GetComponent<TMP_Text>();
        imageComponent = itemPickups.transform.Find("Image").GetComponent<Image>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        dialogManager = FindFirstObjectByType<DialogManager>();
        itemPickups.SetActive(false);


    }
    public void SetState(ButtonState newState)
    {
        if (CurrentState == newState) return;

        CurrentState = newState;
    }

    public void InventoryAdd(GameObject gameObjectParam)
    {
        AudioManager.Instance.emitAudio(Audios.Pickup);
        inventory.Push(gameObjectParam);
        Debug.Log("Item added to inventory. Total items: " + inventory.Count);


        textComponent.text = "Nuevo objeto recogido!";
        imageComponent.sprite = gameObjectParam.GetComponent<ItemInfo>().sprtEnInventario; // ejemplo
        itemPickups.SetActive(true);
        StartCoroutine(HideItemPickup());
    }
    private IEnumerator HideItemPickup()
    {
        yield return new WaitForSeconds(1.5f);
        itemPickups.SetActive(false);
    }

    public void ClearDialog()
    {
        dialogManager.setDialog(new Dialog
        {
            speakerName = "",
            text = "",
            personaje = Personajes.Nada
        });
    }

    public void SetDialog(Dialog dialog)
    {
        dialogManager.setDialog(dialog);
    }
}

