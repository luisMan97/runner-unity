using UnityEngine;
using TMPro; 

public class DistanceCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText, scoretextInPause; 
    public float speed = 10f; 

    private float distanceTraveled = 0f;

    void Update()
    {
        
        distanceTraveled += speed * Time.deltaTime;

       
        scoreText.text =  Mathf.Round(distanceTraveled).ToString()+" Mts";
        scoretextInPause.text = "Distance: " + Mathf.Round(distanceTraveled).ToString() + " mts";
    }
}
