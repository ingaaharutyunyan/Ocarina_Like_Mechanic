using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DudukToolScriptableObject", menuName = "ScriptableObject/DudukTool")]
public class DudukToolScriptableObject : ScriptableObject
{
    private void Awake()
    {
        s = "";
    }
    
    public void SetCode(string c) { code = c;}
    public bool CheckString(char a)
    {
        s += a;
        int length = s.Length;

        if (string.Equals(s, code))
        {
            s = "";
            Debug.Log("Inputted correct code");
            DudukTriggered?.Invoke();
            OnDudukProgress?.Invoke( length , code.Length);
            PlayerBarController.instance.GetDudukAnim().OnHeadClicked();
            return true;
        }

        if ((s.Length >= code.Length) || (s[length - 1] != code[length - 1]))
        {
            Debug.Log("Inputted incorrect code");
            s = "";
            OnDudukProgress?.Invoke( 0 , code.Length);
            return false;
        }
        OnDudukProgress?.Invoke( length , code.Length);
        return false;
    }

    [SerializeField] private string s, code;
    public delegate void OnDudukTriggered();
    public event OnDudukTriggered DudukTriggered;
    public Action<float, float>  OnDudukProgress;

}
