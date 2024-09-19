
namespace Assets.Scripts.Ineractibles
{
    /// <summary>
    /// Simple logic sutable for different traps
    /// </summary>
    public class Trap : Interactible
    {
        protected override void Activate()
        {
            animator.SetTrigger("Activate");
            sounds.PlayRandom();
        }

        public void RaiseEvent()
        {
            activationEvent.Raise(param);
        }
    }
}
