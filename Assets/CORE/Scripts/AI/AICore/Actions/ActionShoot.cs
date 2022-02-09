using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Shoot", fileName = "ActionShoot")]
public class ActionShoot : AIAction
{
    private Vector2 aimDirection;

    public override void Act(StateController controller)
    {
        DeterminateAim(controller);
        ShootPlayer(controller);
    }

    private void ShootPlayer(StateController controller)
    {
        // Stop enemy
        controller.CharacterMovement.SetHorizontal(0);
        controller.CharacterMovement.SetVertical(0);

        // Shoot
        if (controller.CharSpell.CurrentSpell != null)
        {

            controller.CharSpell.CurrentSpell.UseSpell();
        }
    }

    private void DeterminateAim(StateController controller)
    {
        aimDirection = controller.Target.position - controller.transform.position;
    }
}