using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSchet : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI textSchet;
    private int schet = 99;

    void Update()
    {
        textSchet.text = $"{ schet}";
        
        if (schet <= 0)
        { button.interactable = false; }
    }

    public void Schet()
    {
        schet--;
    }
}
