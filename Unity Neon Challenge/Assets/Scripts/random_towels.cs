using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_towels : MonoBehaviour {
    public Material[] towel_mat;
    private float spawn_rate = 0.8f;
    // Use this for initialization
    public void Randomize_Towels() {
        
        for(int i = 0; i < transform.childCount; i++)
        {
            if(Random.Range(0f,1f) > spawn_rate)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
            else
            {
                transform.GetChild(i).GetComponent<Renderer>().material = towel_mat[Random.Range(0,3)];
            }
        }
        
	}
}
