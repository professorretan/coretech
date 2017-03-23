using UnityEngine;
using System.Collections;

public enum PlayerState
{
    PLAYER_SPAWNING,
    PLAYER_IDLE,
    PLAYER_MOVING,
    PLAYER_ATTACKING,
    PLAYER_HIT,
    PLAYER_DYING,
    PLAYER_DEAD
}

public class Player : MonoBehaviour {

/* THIS IS AN EXAMPLE OF A SINGLETON WHERE YOU CAN ACCESS IT FROM ANYWHERE */
    // There will never be more than one player
    public static Player Inst { get { return m_Inst; } }
    static Player m_Inst;

    // This the class constructor and we assign the static instance here
    public Player()
    {
        if (m_Inst == null)
            m_Inst = this;
    }
/*///////////////////////SINGLETON EXAMPLE//////////////////////////*/

    // The player's current state
    PlayerState CurrentState = PlayerState.PLAYER_IDLE;

    // This is the collider that we will turn on when the player attacks
    [SerializeField] private BoxCollider2D PlayerAttackCollider;

    // The animator component
    public Animator PlayerAnimator;

    // Update is called once per frame
    void Update() {
        // Player STATE MACHINE
        switch (CurrentState)
        {
            case PlayerState.PLAYER_IDLE:
                break;

        }
    }

    // Set the animator property to Attack
    public void PlayAttackAnimation()
    {
        // Trigger attack animation on player
        if (PlayerAnimator)
            PlayerAnimator.SetTrigger("hit");
    }

    // Turn on the player attack collider
    public void AnimEventTurnOnPlayerAttackCollider()
    {
        // Turn on the collider component when we get an animation event
        if (PlayerAttackCollider)
            PlayerAttackCollider.enabled = true;
    }

    // Turn off the player attack collider
    public void AnimEventTurnOffPlayerAttackCollider()
    {
        // Turn off the collider component when we get an animation event
        if (PlayerAttackCollider)
            PlayerAttackCollider.enabled = false;
    }
}
