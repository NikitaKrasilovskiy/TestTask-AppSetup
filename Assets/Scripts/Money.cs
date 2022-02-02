using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI text1;
    [HideInInspector] public int bank = 200;
    public GameObject[] button80, button160, button240;
    private Animator animator;

    void Start()
    {animator = FindObjectOfType<Animator>();}

    void Update()
    { text1.text = $"{bank}"; }

    public void Pokupka80()
    {
        if ( bank >= 80)
        {
            for (int i = 0; i < button80.Length; i++)
            {
                if (button80[i].activeInHierarchy)
                {
                    button80[i].SetActive(false);
                }
            }
            bank -= 80;
        }
        else animator.SetTrigger("Alert");
    }
    public void Pokupka160()
    {
        if (bank >= 160)
        {
            for (int i = 0; i < button160.Length; i++)
            {
                if (button160[i].activeInHierarchy)
                {
                    button160[i].SetActive(false);
                }
            }
            bank -= 160;
        }
        else animator.SetTrigger("Alert");
    }
    public void Pokupka240()
    {
        if (bank >= 240)
        {
            for (int i = 0; i < button240.Length; i++)
            {
                if (button240[i].activeInHierarchy)
                {
                    button240[i].SetActive(false);
                }
            }
            bank -= 240;
        }
        else animator.SetTrigger("Alert");
    }
}
