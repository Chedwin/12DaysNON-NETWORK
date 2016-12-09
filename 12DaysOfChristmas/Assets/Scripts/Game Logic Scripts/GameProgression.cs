using UnityEngine;


using System.Collections.Generic;
using System.Collections;


public enum WAVE_DAY {
    ONE = 1,
    TWO = 2,
    THREE = 3,
    FOUR = 4,
    FIVE = 5,
    SIX = 6,
    SEVEN = 7,
    EIGHT = 8,
    NINE = 9,
    TEN = 10,
    ELEVEN = 11,
    TWELVE = 12,
    FINISH = 13
}


public class GameProgression : MonoBehaviour {

    public GameObject enemy;
    public Transform[] spwnPoints;

    
    public WAVE_DAY waveDay;

    const float maxBreakTime = 30.0f;
    ParticleSystem snowParticleSys;
    PlayerController player;

    
    public float breakTime = 0.0f;

    
    public bool snowHeavy = false;

    
    public bool onBreak = false;

    
    public float waveTime = 0.0f;

    const float maxWaveTime = 10.0f;

    float playerDefaultSpeed;

    
    public int numEnemiesLeft = 0;

    const int startEnmCount = 1;

    
    public int snowfallChance = 10;

    void Start()
    { 
        waveDay = WAVE_DAY.ONE;
        snowParticleSys = GameObject.FindGameObjectWithTag("Snow").GetComponent<ParticleSystem>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //playerDefaultSpeed = player.movementSpeed;

        numEnemiesLeft = startEnmCount;

        LightSnow();
        SpawnWave();
    }


    void Update()
    {

        if ((numEnemiesLeft <= 0) && (onBreak == false)) {
            onBreak = !onBreak;
            LightSnow();

            if (waveDay == WAVE_DAY.TWELVE) {
                Debug.Log("YOU WIN");
                return;
            }
        }

        

        if (onBreak == true) {

            breakTime += Time.deltaTime;
            if (breakTime >= maxWaveTime) {
                breakTime = 0.0f;
                onBreak = false;
                WaveUpdate();
                CalculateSnowFall();
                numEnemiesLeft = startEnmCount + ((int)waveDay + 2);
                SpawnWave();
            }
        }
    }

    void CalculateSnowFall() {
        int rand = Random.Range(0, 100);

        if (rand <= snowfallChance)
        {
            HeavySnow();
        }
        else
        {
            LightSnow();
        }
        snowfallChance += 7;
        Debug.Log(rand);
    }

    void HeavySnow() {
        snowHeavy = true;
        snowParticleSys.startSpeed = 40;
        snowParticleSys.emissionRate = 2000;
        //player.movementSpeed /= 2.0f;
        
    }

    void LightSnow() {
        snowHeavy = false;
        snowParticleSys.startSpeed = 10;
        snowParticleSys.emissionRate = 500;
        //player.movementSpeed = playerDefaultSpeed;
    }

    void WaveUpdate() {
        waveDay++;

        if (waveDay == WAVE_DAY.FINISH) {
            Debug.Log("YOU WIN!");
        }
    }


    void SpawnWave() {
        for (int i = 0; i < numEnemiesLeft; i++) {
            int rand = Random.Range(0, spwnPoints.Length);
            Vector3 offset = new Vector3(Random.Range(-4.0f, 4.0f), 0.0f, Random.Range(-4.0f, 4.0f));

            Vector3 spawnPosition = spwnPoints[rand].position + offset;

            Quaternion spawnRotation = Quaternion.Euler(
                0.0f, Random.Range(0, 180), 0.0f);

            GameObject enemyObject = (GameObject)Instantiate(
                enemy, spawnPosition, spawnRotation);
        }
    }


} // end class GameProgression
