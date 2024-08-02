using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Level "+(LevelData.currentLevel + 1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
