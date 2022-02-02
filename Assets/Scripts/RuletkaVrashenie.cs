using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RuletkaVrashenie : MonoBehaviour
{
    private int k, q, w, e, r;
    public GameObject ruletka, win;
    private bool krug = false, times = false, cell1 = false, cell2 = false, cell3 = false, cell4 = false;
    private float g = 10, time, s;
    public Button button, button1;
    public GameObject[] winCell, win1, win2, win3, win4;
    public Money monyScript;
    public TextMeshProUGUI text2;
    void Update()
    {
        text2.text = $"{monyScript.bank}";

        if (krug == true)
            ruletka.transform.Rotate(new Vector3(0, 0, g) * (Time.deltaTime * time));

        if (times == true || time > 0)
        {
            time -= 10;
        }
        else krug = false; times = false;
    }
    public void Vrashenie()
    {
        time = Random.Range(500, 1000);
        krug = true;
        StartCoroutine(Wait());
        button.interactable = false;
        button1.interactable = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        times = true;
        s = transform.eulerAngles.z;

        if (s > 0 && s <= 55)
        {
            if (monyScript.button80[0].activeSelf || monyScript.button160[0].activeSelf || monyScript.button240[0].activeSelf)
            {
                k = Random.Range(0, 3);
                win.SetActive(true);
                winCell[k].SetActive(true);
                StartCoroutine(WaitWinCell());
            }
            else
            {
                monyScript.bank += 100;
                win.SetActive(true);
                k = 12;
                winCell[k].SetActive(true);
                StartCoroutine(WaitWinCell());
            }

        }

        else if (s >= 55 && s <= 125)
        {
            if (monyScript.button80[1].activeSelf || monyScript.button160[1].activeSelf || monyScript.button240[1].activeSelf)
            {
                k = Random.Range(8, 11);
                win.SetActive(true);
                winCell[k].SetActive(true);
                StartCoroutine(WaitWinCell());
            }
            else
            {
                monyScript.bank += 100;
                win.SetActive(true);
                k = 12;
                winCell[k].SetActive(true);
                StartCoroutine(WaitWinCell());
            }
        }

        else if (s >= 125 && s <= 180)
        {
            if (monyScript.button80[2].activeSelf || monyScript.button160[2].activeSelf || monyScript.button240[2].activeSelf)
            {
                k = Random.Range(4, 7);
                win.SetActive(true);
                winCell[k].SetActive(true);
                StartCoroutine(WaitWinCell());
            }
            else
            {
                monyScript.bank += 100;
                win.SetActive(true);
                k = 12;
                winCell[k].SetActive(true);
                StartCoroutine(WaitWinCell());
            }
        }

        else if (s >= 180 && s <= 360)
        {
            monyScript.bank += 100;
            win.SetActive(true);
            k = 12;
            winCell[k].SetActive(true);
            StartCoroutine(WaitWinCell());
        }

        yield return new WaitForSeconds(1f);
        button.interactable = true;
        button1.interactable = true;
    }

    IEnumerator WaitWinCell()
    {
        if (k == 1) { monyScript.button80[0].SetActive(false); }
        if (k == 2) { monyScript.button160[0].SetActive(false); }
        if (k == 3) { monyScript.button240[0].SetActive(false); }
        if (k == 5) { monyScript.button80[1].SetActive(false); }
        if (k == 6) { monyScript.button160[1].SetActive(false); }
        if (k == 7) { monyScript.button240[1].SetActive(false); }
        if (k == 9) { monyScript.button80[2].SetActive(false); }
        if (k == 10) { monyScript.button160[2].SetActive(false); }
        if (k == 11) { monyScript.button240[2].SetActive(false); }

        yield return new WaitForSeconds(1f);

        winCell[k].SetActive(false);
        win.SetActive(false);
        StartCoroutine(WaitWin1());
    }
    IEnumerator WaitWin1()
    {
        if (cell1 == true)
        {
            win1[q].SetActive(false);
            StartCoroutine(WaitWin2());
        }

        yield return new WaitForSeconds(0.5f);

        win1[k].SetActive(true);
        if (win1[k].activeInHierarchy)
        { cell1 = true; q = k; }
    }
    IEnumerator WaitWin2()
    {
        if (cell2 == true)
        {
            win2[w].SetActive(false);
            StartCoroutine(WaitWin3());
        }

        yield return new WaitForSeconds(0.5f);

        win2[q].SetActive(true);
        if (win2[q].activeInHierarchy)
        { cell2 = true; w = q; }
    }
    IEnumerator WaitWin3()
    {
        if (cell3 == true)
        {
            win3[e].SetActive(false);
            StartCoroutine(WaitWin4());
        }

        yield return new WaitForSeconds(0.5f);

        win3[w].SetActive(true);
        if (win3[w].activeInHierarchy)
        { cell3 = true; e = w; }
    }
    IEnumerator WaitWin4()
    {
        if (cell4 == true)
        {
            win4[r].SetActive(false);
        }

        yield return new WaitForSeconds(0.5f);
        
        win4[e].SetActive(true);
        if (win4[e].activeInHierarchy)
        { cell4 = true; r = e; }
    }
}
