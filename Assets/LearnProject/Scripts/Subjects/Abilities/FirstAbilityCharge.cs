using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAbilityCharge : MonoBehaviour
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
            if(!player.MagicBook.HaveFirstAbility)
            {
                GameplayInterface.ShowMessageInRightUpCorner("” вас нет первой способоности!", 1);
                return;
            }
            //print($"¬ы подобрали {Count} зар€д(ов) дл€ первой способности!");
            player.AddMagicItem(gameObject);
            Destroy(gameObject);
        }
    }
}
