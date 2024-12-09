using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetStand : MonoBehaviour
{
    public Transform temp;
    [SerializeField] List<Transform> winnerParticles;
    [SerializeField] GameObject prefabEnemy;
    [SerializeField] List<GameObject> prefabPlans;
    public List<Vector3> blocksPosList;
    public int frameCounter = 0, enemyCounter = 0;
    public bool endTurn = false;
    public bool changeTarget;
    public int blocksCount;
    ThrowCube throwCube;
    HighScore highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore = FindFirstObjectByType<HighScore>();
        transform.position = RandomPosition();
        RandomRotation();

        Instantiate(prefabPlans[0], transform).transform.localPosition =
            GameObject.Find("planState").transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        throwCube = FindFirstObjectByType<ThrowCube>();
        temp = throwCube.transform.parent;

        frameCounter++;
        blocksCount = GetComponentsInChildren<Transform>()
            .Where(b => b.name.Contains("block"))
            .Count();

        var enemies = FindObjectsByType<GameObject>(FindObjectsSortMode.None).Where(g => g.transform.name.Contains("enemy")).ToList();

         if (blocksCount is 0 && !endTurn)
        {
            winnerParticles =
               GetComponentsInChildren<Transform>()
               .FirstOrDefault(s => s.name.Contains("stand_floor")).
               GetComponentsInChildren<Transform>()
               .Where(p => p.name.Contains("Particle")).ToList();

            var stageCompleteSound = transform.GetComponent<AudioSource>();
            if (!stageCompleteSound.isPlaying)
                stageCompleteSound.Play();

            winnerParticles[0].GetComponent<ParticleSystem>().Play();
            winnerParticles[1].GetComponent<ParticleSystem>().Play();
            winnerParticles[2].GetComponent<ParticleSystem>().Play();

            endTurn = true;
            highScore.endOfStage = true;
        }

        //when cube in throow (on air) enemy not Instantiate
        if (frameCounter >= 30 /*&& enemyCounter < 128*/ &&
            throwCube.gameObject.transform.parent is not null &&
            enemies.Count < 4096)
        {
            var enemyObject = Instantiate(prefabEnemy);

            rndTransform(enemyObject);
            enemyCounter++;
            frameCounter = 0;
        }
    }

   
    private Vector3 RandomPosition()
    {

        newRandom:
        var standY = Random.Range(10.0f, 20.0f);
        var standX = Random.Range(-40.0f, 40.0f);//-15
        var standZ = Random.Range(-40.0f, 40.0f);

        if ((standX < 15 && standX > -15) && (standZ < 15 && standZ > -15))
            goto newRandom;

        return new Vector3(standX, standY, standZ);
    }
    private void rndTransform(GameObject enemy)
    {

        var prefabScale = Random.Range(0.5f, 2.0f);
        //var prefabX = Random.Range(0.5f, 2.0f);
        //var prefabZ = Random.Range(0.5f, 2.0f);

        enemy.transform.localScale = new Vector3(prefabScale, prefabScale, prefabScale);

        //set random position
        var standPos = transform.position;
        float posX, posY, posZ = 0.0f;
        posX = Random.Range(-50.0f, 50.0f);
        posY = Random.Range(1.0f, 40.0f);
        posZ = Random.Range(-50.0f, 50.0f);


      
        enemy.transform.position = new Vector3(posX, posY, posZ);

    }
    private /*Quaternion*/ void RandomRotation()
    {
        //float rotY = 0.0f;
        var standPos = transform.position;
        var camPos = Camera.main.transform.position;

        var rotY = Random.Range(-25.0f, 25.0f);

        var direction = standPos - new Vector3(camPos.x+rotY, standPos.y, camPos.z);
        transform.rotation = Quaternion.LookRotation(direction);

        //return Quaternion.Euler(transform.rotation.x, rotY, transform.rotation.z);
    }

   
}
