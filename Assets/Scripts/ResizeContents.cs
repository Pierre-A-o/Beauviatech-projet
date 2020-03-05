using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeContents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        GetComponent<GridLayoutGroup>().constraintCount = 1;
        GetComponent<GridLayoutGroup>().cellSize = new Vector2(480F, 200F);
        GetComponent<GridLayoutGroup>().spacing = new Vector2(0F, 20F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
