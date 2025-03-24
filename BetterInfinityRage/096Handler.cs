using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp096;
using PlayerRoles;
using MEC;
using System.Linq;
using UnityEngine;

namespace BetterInfinityRage
{
    public class EventHandlers
    {
        private readonly HashSet<Player> _trackedTargets = new();
        private CoroutineHandle _trackingCoroutine;
        private Player _scp096;

        public void AddinTarget(AddingTargetEventArgs ev)
        {
            if (ev.Player.Role.Type != RoleTypeId.Scp096)
                return;

            _trackedTargets.Add(ev.Target);
            _scp096 = ev.Player;
            if (!_trackingCoroutine.IsRunning)
                _trackingCoroutine = Timing.RunCoroutine(TrackTargetPositions());
        }

        public void Calming(CalmingDownEventArgs ev)
        {
            if (ev.Player.Role.Type == RoleTypeId.Scp096 && _trackedTargets.Count > 0)
                ev.IsAllowed = false;
            else
                ev.IsAllowed = true;
        }

        public void TargetDied(DiedEventArgs ev)
        {
            if (_trackedTargets.Remove(ev.Player) && _trackedTargets.Count == 0 && _trackingCoroutine.IsRunning)
            {
                Timing.KillCoroutines(_trackingCoroutine);
                _trackingCoroutine = default;
            }
        }

        private IEnumerator<float> TrackTargetPositions()
        {
            float interval = Plugin.Instance.Config.PositionCheckInterval;
            while (_trackedTargets.Count > 0 && _scp096 != null && _scp096.IsAlive)
            {
                Player closestTarget = GetClosestTarget();

                if (closestTarget != null)
                {
                    ShowHintToScp096(closestTarget);
                }

                yield return Timing.WaitForSeconds(interval);
            }
            _trackingCoroutine = default;
        }

        private Player GetClosestTarget()
        {
            if (_scp096 == null || !_scp096.IsAlive || _trackedTargets.Count == 0)
                return null;

            return _trackedTargets
                .Where(target => target.IsAlive)
                .OrderBy(target => Vector3.Distance(_scp096.Position, target.Position))
                .FirstOrDefault();
        }

        private void ShowHintToScp096(Player target)
        {
            if (_scp096 == null || !_scp096.IsAlive || target == null)
                return;

            string roomName = target.CurrentRoom?.Name.Replace("(Clone)", "") ?? Plugin.Instance.Translation.UnknownRoom;
            if (!Plugin.Instance.Config.AlwaysShowPlayer && _scp096.Zone == target.Zone)
                return;
            string message = Plugin.Instance.Config.AlwaysShowPlayer
                ? Plugin.Instance.Translation.AlwaysShowPlayerMessage
                : Plugin.Instance.Translation.TargetRoomMessage;
            message = message.Replace("{room}", roomName);
            _scp096.ShowHint(message);
        }
    }
}
