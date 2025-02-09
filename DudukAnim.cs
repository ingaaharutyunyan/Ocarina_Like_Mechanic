using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.InputSystem;

public class DudukAnim : MonoBehaviour
{
    [SerializeField] private GameObject dudukHead, musicButtons;
    [SerializeField] private DudukBorder dudukBorder;
    [SerializeField] private InputAction inputAction;
    [SerializeField] private Vector3 closeDuduk, closeDudukHead, openDuduk, openDudukHead;
    public static event Action<bool> OnDudukInstrumentOpened;
    private bool opened = false;


    private void OnEnable()
    {
        inputAction.Enable();
        inputAction.performed += OnHeadClicked;
        dudukBorder.Make(false);
        musicButtons.SetActive(false);
    }

    private void OnDisable()
    {
        inputAction.Disable();
        inputAction.performed -= OnHeadClicked;
    }

    public void OnHeadClicked()
    {
        if (opened)
        {
            dudukBorder.Make(false);
            OnDudukInstrumentOpened?.Invoke(false);
            GameManager.instance.SetPlayerMovement(true);
            /// just cancel movement
            MoveDuduk(closeDuduk, closeDudukHead);
            GameManager.instance.GetAudioManager().FadeOutMusic();
            musicButtons.SetActive(false);
        }
        else
        {
            dudukBorder.Make(true);
            OnDudukInstrumentOpened?.Invoke(true);
            GameManager.instance.SetPlayerMovement(false);
            MoveDuduk(openDuduk, openDudukHead);
            GameManager.instance.GetAudioManager().FadeInMusic();
            musicButtons.SetActive(true);
        }
        opened = !opened;
    }

    public void OnHeadClicked(InputAction.CallbackContext context)
    {
        OnHeadClicked();
    }

    private void MoveDuduk(Vector3 moveTarget, Vector3 popTarget)
    {
        Vector3 movePosition = new Vector3(moveTarget.x * Screen.width, moveTarget.y * Screen.height, 0);
        Vector3 popPosition = new Vector3(popTarget.x * Screen.width, popTarget.y * Screen.height, 0);
        this.gameObject.transform.DOMove(movePosition, 0.5f);//.OnComplete(() => PopCap(popPosition));
    }

    private void PopCap(Vector3 target)
    {
        Vector3 popPosition = new Vector3(target.x * Screen.width, target.y * Screen.height, 0);

        dudukHead.transform.DOMove(popPosition, 0.5f);
    }
}
