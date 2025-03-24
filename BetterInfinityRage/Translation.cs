using Exiled.API.Interfaces;
using System.ComponentModel;

namespace BetterInfinityRage
{
    public class Translation : ITranslation
    {
        [Description("Message displayed when SCP-096 is tracking a target and AlwaysShowPlayer is false.")]
        public string TargetRoomMessage { get; set; } = "<align=right>Target is in: {room}</align>";

        [Description("Message displayed when AlwaysShowPlayer is enabled.")]
        public string AlwaysShowPlayerMessage { get; set; } = "<align=right>Target is currently in: {room}</align>";

        [Description("Message displayed when the room is unknown.")]
        public string UnknownRoom { get; set; } = "Unknown Room";
    }
}
