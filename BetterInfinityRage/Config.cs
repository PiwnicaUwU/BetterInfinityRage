using Exiled.API.Interfaces;
using System.ComponentModel;

namespace BetterInfinityRage
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
        [Description("Should SCP-096 always see the target's current room?")]
        public bool AlwaysShowPlayer { get; set; } = false;
        [Description("Time (in seconds) between position checks.")]
        public float PositionCheckInterval { get; set; } = 1.0f;
    }
}
