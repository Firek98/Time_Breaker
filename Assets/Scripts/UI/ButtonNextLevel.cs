using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonNextLevel : MonoBehaviour {

    public GameObject Seguro;

    void Start()
    {
        Seguro.SetActive(false);
    }
    
    public void NextLevelButton(int index)
    {
        Application.LoadLevel(index);
    }

    public void AbrirEstasSeguro()
    {
        Seguro.SetActive(true);
    }

    public void CerrarEstasSeguro()
    {
        Seguro.SetActive(false);
    }

    public void FinishApplication()
    {
        Application.Quit();
    }
}
