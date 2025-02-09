using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MusicalButtonPress : MonoBehaviour
{
    [SerializeField] private Sprite ButtonUp;
    [SerializeField] private Sprite ButtonDown;
    [SerializeField] private char ch;
    [SerializeField] private DudukToolScriptableObject dudukToolSO;
    [SerializeField] private InputAction playerInput;
    Button button;
    Image image;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        image.sprite = ButtonUp;
        playerInput.Enable();

        playerInput.started += TriggerButtonDown;
        playerInput.canceled += TriggerButtonUp;
    }

    private void OnDisable()
    {
        playerInput.Disable();
        
        playerInput.started -= TriggerButtonDown;
        playerInput.canceled -= TriggerButtonUp;
    }

    private void TriggerButtonDown(InputAction.CallbackContext context)
    {
        image.sprite = ButtonDown;
        GameManager.instance.GetAudioManager().PlaySFX("" + ch);
        PassChar(ch);
    }

    private void PassChar(char c) // what the hell is this i love my boyfriend
    {
        dudukToolSO.CheckString(c);
    }

    private void TriggerButtonUp(InputAction.CallbackContext context)
    {
        image.sprite = ButtonUp;
        GameManager.instance.GetAudioManager().StopSFX();
    }
}
