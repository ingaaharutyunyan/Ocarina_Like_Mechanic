using System.Collections;
using DG.Tweening;
using UnityEngine;

public class DudukDoorOpen : MonoBehaviour, IDudukInteractable
{
    [SerializeField] private DudukToolScriptableObject dudukToolSO;
    [SerializeField] private GameObject[] thing;
    [SerializeField] private Vector2 vec;

    void Start()
    {
       this.gameObject.SetActive(!GameManager.instance.GetGameAssetsManager().IsItemAltered(this.gameObject));
       this.gameObject.SetActive(!GameManager.instance.GetGameAssetsManager().IsItemAltered(thing[0]));
    }

    void OnEnable()
    {
        dudukToolSO.DudukTriggered += OnUnlocked;
    }

    void OnDisable()
    {
        dudukToolSO.DudukTriggered -= OnUnlocked;
    }

    public void OnUnlocked()
    {
        GameManager.instance.GetAudioManager().PlaySFX("UnlockDuduk");
        dudukToolSO.DudukTriggered -= OnUnlocked;
        // // Move objects and perform actions after movement is complete
        for (int i = 0; i < thing.Length; i++)
        {  
            GameManager.instance.GetGameAssetsManager().AddItem(thing[i]);
            thing[i].transform.DOMove(vec, 15f);
        }
    }

}
