using Exiled.API.Features;
using System;

namespace BetterInfinityRage
{
    public class Plugin : Plugin<Config, Translation>
    {
        public override string Name => "BetterInfinityRage";
        public override string Author => ".piwnica2137";
        public override string Prefix => "BetterInfinityRage";
        public override Version Version => new(0, 6, 9);

        public static Plugin Instance { get; private set; }

        private EventHandlers _eventHandlers;

        public override void OnEnabled()
        {
            Instance = this;
            _eventHandlers = new EventHandlers();

            Exiled.Events.Handlers.Scp096.AddingTarget += _eventHandlers.AddinTarget;
            Exiled.Events.Handlers.Scp096.CalmingDown += _eventHandlers.Calming;
            Exiled.Events.Handlers.Player.Died += _eventHandlers.TargetDied;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Scp096.AddingTarget -= _eventHandlers.AddinTarget;
            Exiled.Events.Handlers.Scp096.CalmingDown -= _eventHandlers.Calming;
            Exiled.Events.Handlers.Player.Died -= _eventHandlers.TargetDied;

            _eventHandlers = null;
            Instance = null;

            base.OnDisabled();
        }
    }
}
