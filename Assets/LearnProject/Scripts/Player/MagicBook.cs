using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.LearnProject.Player
{
    public class MagicBook
    {
        public bool HaveFirstAbility { get; private set; }
        public FirstAbility FirstAbility { get; private set; }

        internal void AddAbility(GameObject gameObject)
        {
            if (gameObject.name == "Ability1")
            {
                FirstAbility = gameObject.GetComponent<FirstAbility>();
                HaveFirstAbility = true;
                Console.WriteLine("Теперь вы можете стрелять по левой кнопке мыши.");
            }
            if (gameObject.CompareTag("Charge1"))
            {
                FirstAbility.AddCharges(gameObject.GetComponent<FirstAbilityCharge>());
            }
        }
    }
}
