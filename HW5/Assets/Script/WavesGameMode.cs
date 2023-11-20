using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WavesGameMode : MonoBehaviour
{
    [SerializeField] private Life playerLife;
    [SerializeField] private Life BaseLife;

    private void Awake()
    {
        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        BaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
    }

    void OnPlayerOrBaseDied()
    {
        SceneManager.LoadScene("Lose Scene");
    }
}
