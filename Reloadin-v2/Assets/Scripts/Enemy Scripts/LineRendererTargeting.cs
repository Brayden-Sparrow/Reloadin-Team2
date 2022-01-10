using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTargeting : MonoBehaviour
{
    // Variables

    [SerializeField] private Transform[] points;

    // References

    [SerializeField] private LineRendererController line;
    [SerializeField] private DoomedEnemy dEnemy;

    // Function

    private void Awake()
    {
        line.SetUpLine(points);
        
        dEnemy = gameObject.GetComponent<DoomedEnemy>();
    }

    private void Update()
    {

        if (dEnemy.doomedStatus > 0)
        {
            line.gameObject.SetActive(true);
        }
        else
        {
            line.gameObject.SetActive(false);
        }
    }
}
