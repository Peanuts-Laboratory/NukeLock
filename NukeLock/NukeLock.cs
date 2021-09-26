﻿using Exiled.API.Features;
using NukeLock.Events;
using System;
using MEC;

namespace NukeLock
{
    public class NukeLock : Plugin<Config>
    {
        public override string Author => "Marco15453";
        public override string Name => "NukeLock";
        public override Version Version => new Version(1, 3, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        private WarheadHandler warheadHandler;
        private ServerHandler serverHandler;

        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            warheadHandler = new WarheadHandler(this);
            serverHandler = new ServerHandler(this);

            // Server
            Exiled.Events.Handlers.Server.RoundStarted += serverHandler.onRoundStarted;

            // Warhead
            Exiled.Events.Handlers.Warhead.Stopping += warheadHandler.onStopping;
        }

        private void UnregisterEvents()
        {
            // Server
            Exiled.Events.Handlers.Server.RoundStarted -= serverHandler.onRoundStarted;

            // Warhead
            Exiled.Events.Handlers.Warhead.Stopping -= warheadHandler.onStopping;

            warheadHandler = null;
            serverHandler = null;
        }
    }
}
