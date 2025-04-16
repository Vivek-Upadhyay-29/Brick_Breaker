using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    // Start is called before the first frame update
    public class Ground : MonoBehaviour
    {
        public RandomPrefabGenerator generator;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag =="Player")
            {
                Debug.Log(collision.gameObject.name);
                generator.MoveDown();

            }
        }
    }

