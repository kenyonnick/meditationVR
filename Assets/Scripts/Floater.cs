using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour {
    public Vector3 rotation;
    public float rotationSpeed;
    public float floatSpeed;
    public float cutoffDistance = 25;
    Vector3 floatDir;
    public float lifetime;

	// Use this for initialization
	void Start () {
        floatDir = new Vector3(0, 0, 0) - this.transform.position;
        floatDir.y = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += floatDir * floatSpeed * Time.deltaTime;
        this.transform.Rotate(rotation * rotationSpeed * Time.deltaTime);

        lifetime -= Time.deltaTime;
        if (this.transform.position.z <= -cutoffDistance || lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
