using UnityEngine;


public interface IPlayerState
{
    void EnterState(Player player);
    void UpdateState(Player player);
}

// El personaje está en el suelo
public class GroundedState : IPlayerState
{
    public void EnterState(Player player)
    {
        player.ResetExtraJumps();
    }

    public void UpdateState(Player player)
    {
        if (Input.GetButtonDown("Jump"))
        {
            player.ExecuteJump();
            player.ChangeState(new InAirState());
        }
    }
}

// El personaje está en el aire 
public class InAirState : IPlayerState
{
    public void EnterState(Player player) { }

    public void UpdateState(Player player)
    {
        if (Input.GetButtonDown("Jump") && player.CanExtraJump())
        {
            player.ExecuteJump();
            player.DecrementExtraJump();
        }

        if (player.CheckIsGrounded())
        {
            player.ChangeState(new GroundedState());
        }
    }
}