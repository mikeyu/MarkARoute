﻿using ICities;
using MarkARoute.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkARoute
{
    public class ThreadingMonitor : ThreadingExtensionBase
    {
        private NetManager mNetManager;

        public override void OnCreated(IThreading threading)
        {
            mNetManager = NetManager.instance;
            base.OnCreated(threading);
        }

        public override void OnAfterSimulationTick()
        {
            NetSegment[] buffer = mNetManager.m_segments.m_buffer;
            List<ushort> segments = new List<ushort>(RouteManager.Instance().m_routeDict.Keys);
            foreach (ushort segment in segments)
            {
                if( (buffer[segment].m_flags) == NetSegment.Flags.None)
                {
                    RouteManager.Instance().DelRoadRoute(segment);
                }
            }

            base.OnAfterSimulationTick();
        }
    }
}
