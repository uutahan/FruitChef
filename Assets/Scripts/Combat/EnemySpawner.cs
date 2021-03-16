using SwordShield.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordShield.Combat
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject scoreTextGO;

        private TMPro.TMP_Text textScore;

        public Game game;

        [SerializeField]
        private GameObject enemy = null;

        [SerializeField]
        private GameObject player = null;

        [SerializeField]
        private Transform parent = null;

        private int enemyCount = 0;
        private int maxEnemy = 1;
        private int enemyKilled = 0;

        private Dictionary<IHealth, GameObject> map;

        private void Start()
        {
            Debug.Log("Game Mode is normal: " + game.isNormalMode);

            textScore = scoreTextGO.GetComponent<TMPro.TextMeshProUGUI>();
            map = new Dictionary<IHealth, GameObject>();
        }

        private void Update()
        {
            CheckDeadEnemies();

            if (enemyCount < maxEnemy)
            {
                //GameObject spawnEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity, parent);
                //map.Add(spawnEnemy.GetComponent<IHealth>(), spawnEnemy);

                //enemyCount++;

                SpawnEnemy();
            }
            
        }

        private void SpawnEnemy()
        {
            //float radius = 1f;
            //for (int i = 0; i < 8; i++)
            //{
            //    float angle = i * Mathf.PI * 2f / 8;
            //    Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);

            //    GameObject spawnEnemy = Instantiate(enemy, newPos, Quaternion.identity, parent);
            //}

            float rand = Random.Range(0f, 2f);
            float angle = Mathf.PI * rand ;

            float randRadius = Random.Range(9f, 13f);
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * randRadius, 0, Mathf.Sin(angle) * randRadius);

            GameObject spawnEnemy = Instantiate(enemy, newPos, Quaternion.identity, parent);

            spawnEnemy.GetComponent<Fighter>().WeaponRange= Random.Range(6f, 11f);

            map.Add(spawnEnemy.GetComponent<IHealth>(), spawnEnemy);

            enemyCount++;
        }

        private void CheckDeadEnemies()
        {
            Dictionary<IHealth, GameObject> copy = new Dictionary<IHealth, GameObject>(map);

            foreach (var elem in copy)
            {
                if (elem.Key.IsDead)
                {
                    enemyCount--;
                    enemyKilled++;

                    int score = enemyKilled;
                    textScore.text = score.ToString();

                    StartCoroutine(DestroyDeadEnemy(elem.Value));

                    map.Remove(elem.Key);

                    if (game.isNormalMode)
                    {
                        if (enemyKilled <= 2)
                        {
                            maxEnemy = 2;
                        }
                        else if (enemyKilled <= 4)
                        {
                            maxEnemy = 3;
                        }
                        else if (enemyKilled <= 6)
                        {
                            maxEnemy = 4;
                        }

                        else if (enemyKilled <= 10)
                        {
                            maxEnemy = 5;
                        }
                    }

                    else if (!game.isNormalMode)
                    {
                        maxEnemy = enemyKilled + 1;

                    }
                }
            }
        }

        private IEnumerator DestroyDeadEnemy(GameObject enemy)
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(enemy);
        }
    }
}
