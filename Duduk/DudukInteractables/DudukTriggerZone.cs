using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudukTriggerZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            PassCode(code);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        PassCode("xxxx"); // so that no action can be triggered outside of the approprite collider
    }

    public void PassCode(string c)
    {
        dudukToolSO.SetCode(c);
    }
    [SerializeField] private string serializedCode;
    [SerializeField] private string code {get; set;}
    public string Code
    {
        get { return code; }
        set { code = value; }
    }
    void OnEnable() { code = serializedCode; }
    [SerializeField] private DudukToolScriptableObject dudukToolSO;
}
