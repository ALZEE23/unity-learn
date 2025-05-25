using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> holes = new List<GameObject>();
    private List<HoleItem> holeItems = new List<HoleItem>();
    [SerializeField] private float showDuration = 1f; 
    [SerializeField] private float timeBetweenHoles = 2f; 
    private bool isGameActive = true;
    
    void Start()
    {
        foreach(GameObject hole in holes)
        {
            HoleItem item = hole.GetComponent<HoleItem>();
            if(item != null)
            {
                holeItems.Add(item);
            }
        }
        
        StartCoroutine(ShowRandomHole());
    }

    IEnumerator ShowRandomHole()
    {
        while(isGameActive)
        {
           
            yield return new WaitForSeconds(timeBetweenHoles);
            
            
            int randomIndex = Random.Range(0, holeItems.Count);
            HoleItem selectedHole = holeItems[randomIndex];
            
            
            selectedHole.SetOpen(true);
            
            
            yield return new WaitForSeconds(showDuration);
            
            
            selectedHole.SetOpen(false);
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if(hit.collider != null)
            {
                HoleItem clickedHole = hit.collider.GetComponent<HoleItem>();
                if(clickedHole != null && clickedHole.IsOpen())
                {
                    
                    clickedHole.SetOpen(false);
                }
            }
        }
    }
}
