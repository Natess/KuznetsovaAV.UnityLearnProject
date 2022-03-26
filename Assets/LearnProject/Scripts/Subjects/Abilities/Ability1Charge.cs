using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability1Charge : MonoBehaviour
{
    [SerializeField] public int Count { get; private set; }

    private void Start()
    {
        Count = Random.Range(1, 7);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            if(!player.HaveAbility1)
            {
                print("” вас нет первой способоности!");
                return;
            }
            print($"¬ы подобрали {Count} зар€д(ов) дл€ первой способности!");
            player.AddItem(gameObject);
            Destroy(gameObject);
        }
    }
}
