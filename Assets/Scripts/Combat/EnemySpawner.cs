using SwordShield.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordShield.Combat
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject enemy = null;

        [SerializeField]
        private GameObject player = null;

        [SerializeField]
        private Transform parent = null;

        [SerializeField]
        private float radius = 20f;

        private int enemyCount = 0;
        private int maxEnemy = 1;
        private int enemyKilled = 0;

        private Dictionary<IHealth, GameObject> map;

        private void Start()
        {
            map = new Dictionary<IHealth, GameObject>();
        }

        private void Update()
        {
            

            CheckDeadEnemies();

            if (enemyCount < maxEnemy)
            {
                Debug.Log("ADDING ENEMY");
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
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);

            GameObject spawnEnemy = Instantiate(enemy, newPos, Quaternion.identity, parent);

            spawnEnemy.GetComponent<Fighter>().WeaponRange= Random.Range(6f, 11f);

            map.Add(spawnEnemy.GetComponent<IHealth>(), spawnEnemy);

            enemyCount++;
        }

        private void CheckDeadEnemies()
        {
            //foreach(IHealth enemyHealth in enemyList.ToArray())
            //{
            //    if (enemyHealth.IsDead)
            //    {
            //        Debug.Log("REMOVING ENEMY");
            //        enemyCount--;
            //        enemyList.Remove(enemyHealth);
            //    }
            //}

            Dictionary<IHealth, GameObject> copy = new Dictionary<IHealth, GameObject>(map);

            foreach (var elem in copy)
            {
                if (elem.Key.IsDead)
                {
                    Debug.Log("REMOVING ENEMY");
                    enemyCount--;
                    enemyKilled++;

                    StartCoroutine(DestroyDeadEnemy(elem.Value));

                    map.Remove(elem.Key);


                    if (enemyKilled <= 1)
                    {
                        maxEnemy = 2;
                    }
                    else if (enemyKilled <= 2)
                    {
                        maxEnemy = 3;
                    }
                    else if (enemyKilled <= 3)
                    {
                        maxEnemy = 4;
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
