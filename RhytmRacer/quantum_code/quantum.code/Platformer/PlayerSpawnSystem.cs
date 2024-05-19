namespace Quantum.Platformer;

public unsafe class PlayerSpawnSystem: SystemSignalsOnly, ISignalOnPlayerDataSet
{
    public void OnPlayerDataSet(Frame frame, PlayerRef player)
    {
        Log.Info("PlayerSpawnSystem.OnPlayerDataSet");
        var data = frame.GetPlayerData(player);
        
        var prototype = frame.FindAsset<EntityPrototype>(data.CharacterPrototype.Id);
        var entity = frame.Create(prototype);
        var playerLink = new PlayerLink()
        {
            Player = player
        };
        
        frame.Add(entity, playerLink);

        if (frame.Unsafe.TryGetPointer<Transform3D>(entity, out var transform))
        {
            transform->Position.X = (int)player;
        }
    }
}