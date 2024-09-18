using Assets.Scripts.Audio;
using Assets.Scripts.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assets.Scripts.Ineractibles
{
    /// <summary>
    /// Class defines behaviour of the keys
    /// </summary>
    public class Key : Interactible
    {
        protected override void Activate()
        {
            sounds.PlayRandom();
            Destroy(gameObject, 0.2f);
        }
    }
}
