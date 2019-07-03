using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject GOCanvas;
    private CanvasGroup CG;
    // Start is called before the first frame update
    void Start()
    {
        CG = Instantiate(GOCanvas.GetComponent<CanvasGroup>(), null, true);
        CG.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        CG.alpha = 1.0f;
    }
}
