using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject spaceshipPrefab;
    private GameObject spaceship;
    [SerializeField] private float minCollisionRadius = 2.0f;

    private void Awake()
    {
        InitializeLevel();
    }

    private void InitializeLevel()
    {
        //spawn asteroids
        spawnAsteroid();

        //spawn spaceship
        spawnSpaceship();
    }

    //spawn a new asteroid
    private void spawnAsteroid()
    {
        bool valid;
        GameObject newAsteroid;
        do
        {
            newAsteroid = Instantiate(asteroidPrefab);
            newAsteroid.gameObject.tag = "Asteroid";

            valid = CheckTooCloseToAsteroid(newAsteroid);

        } while (valid == false);
    }

    //spawn a spaceship
    private void spawnSpaceship()
    {
        bool valid;
        do
        {
            spaceship = Instantiate(spaceshipPrefab);
            spaceship.gameObject.tag = "Spaceship";

            valid = CheckTooCloseToAsteroid(spaceship);

        } while (valid == false);
        return;
    }

    private bool CheckTooCloseToAsteroid (GameObject testObject)
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach(GameObject asteroid in asteroids)
        {
            if (asteroid != testObject)
            {
                if(Vector3.Distance(testObject.transform.position, asteroid.transform.position) < minCollisionRadius)
                {
                    Destroy(testObject);
                    return false;
                }
            }
        }
        return true;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
