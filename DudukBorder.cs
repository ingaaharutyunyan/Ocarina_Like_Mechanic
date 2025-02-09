using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DudukBorder : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private DudukToolScriptableObject dtSO;
    [SerializeField] private Image image;
    void OnEnable()
    {
        image.sprite = sprites[0];
        dtSO.OnDudukProgress += Progress;
    }

    void OnDisable()
    {
        dtSO.OnDudukProgress -= Progress;
    }

    public void Make(bool b)
    {
        this.gameObject.SetActive(b);
    }

    public void Progress(float progress, float codeLength)
    {
        float f = (float)progress/codeLength;
        if (f < 0.4f) image.sprite = sprites[0];
        else if (f >= 0.4f && f <= 0.7f) image.sprite = sprites[1];
        else image.sprite = sprites[2];
    }
}
