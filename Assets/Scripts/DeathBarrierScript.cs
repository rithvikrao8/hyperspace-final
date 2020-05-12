using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathBarrierScript : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entered collision");
        int prevIndex = SceneManager.GetActiveScene().buildIndex +1;
        SceneManager.LoadScene(prevIndex);
    }
}