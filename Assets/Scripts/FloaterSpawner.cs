using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterSpawner : MonoBehaviour {
    public GameObject[] prefabs; // prefabs from which to randomly select and generate
    public Vector3 start;
    public Vector3 stop;
    public float cutoffDistance;

    public float minRotationSpeed;
    public float maxRotationSpeed;
    public float minFloatSpeed;
    public float maxFloatSpeed;

    public float lifetime = 10;
    public float spawnTime;
    float timer = 0;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnNewRandomFloater();
            timer = spawnTime;
        }
	}

    void SpawnNewRandomFloater()
    {
        int prefabIndex = Random.Range(0, prefabs.Length);
        GameObject newFloater = Instantiate(prefabs[prefabIndex], this.transform);
        newFloater.transform.position = GetRandomVector(start.x, stop.x, start.y, stop.y, start.z, stop.z);

        Floater floater = newFloater.GetComponent<Floater>();
        floater.cutoffDistance = cutoffDistance;
        floater.rotation = GetRandomVector(-1, 1, -1, 1, -1, 1);
        floater.rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        floater.floatSpeed = Random.Range(minFloatSpeed, maxFloatSpeed);
        floater.lifetime = lifetime;
    }

    Vector3 GetRandomVector(float x0, float x1, float y0, float y1, float z0, float z1)
    {
        return new Vector3(Random.Range(x0, x1), Random.Range(y0, y1), Random.Range(z0, z1));
    }
}