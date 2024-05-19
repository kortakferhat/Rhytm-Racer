namespace Quantum.Platformer;

public unsafe class MovementSystem : SystemMainThreadFilter<MovementSystem.Filter>
{
    public struct Filter
    {
        public EntityRef Entity;
        public CharacterController3D* CharacterController;
    }
    
    public override void Update(Frame f, ref Filter filter)
    {
        var input = *f.GetPlayerInput(0);
        
        if (input.Jump.WasPressed)
        {
            filter.CharacterController->Jump(f);
        }
        
        // note: pointer property access via -> instead of .
        filter.CharacterController->Move(f, filter.Entity, input.Directon.XOY);
    }
}