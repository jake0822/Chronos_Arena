using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spanwPoint;
    public List<Transform> enemys;
    public TextMeshProUGUI waveText;

    private int wave = 0;

    private void Start()
    {
       

    }
    private void FixedUpdate()
    {
        if (enemys.Count == 0)
        {
            incrementWave();
        }
        for (int i = enemys.Count - 1; i >= 0; i--)
        {
            if (enemys[i] == null)
            {
                enemys.RemoveAt(i);
            }
        }

    }
    void incrementWave()
    {
        wave++;
        waveText.text = "WAVE " + wave;
        GameObject newEnemy;
        for (int i = 0; i < wave*2; i++)
        {
            newEnemy = Instantiate(enemyPrefab, spanwPoint);
            enemys.Add(newEnemy.transform);
        }
    }
}
