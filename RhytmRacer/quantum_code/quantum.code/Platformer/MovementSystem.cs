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
        Input input = default;
        if (f.Unsafe.TryGetPointer(filter.Entity, out PlayerLink* playerLink))
        {
            input = *f.GetPlayerInput(playerLink->Player);
        }
        
        if (input.Jump.WasPressed)
        {
            filter.CharacterController->Jump(f);
        }
        
        // note: pointer property access via -> instead of .
        filter.CharacterController->Move(f, filter.Entity, input.Directon.XOY);
    }
}