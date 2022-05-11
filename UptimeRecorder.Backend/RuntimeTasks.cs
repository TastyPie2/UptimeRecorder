using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TastyIO;

namespace UptimeRecorder.Backend
{
    public sealed class RuntimeTasks
    {
        public static readonly RuntimeTasks Instance = new RuntimeTasks();

        #region Session

        internal JsonFileDataPointer<Session>? _sessionPointer;

        public void EndSession()
        {
            lock (_sessionPointer)
            {
                var session = _sessionPointer?.Get() ?? throw new Exception("Session already ended.");

                session.StopDateTime = DateTime.Now;

                _sessionPointer.Set(session);
                _sessionPointer.Move(TaskHelpers.sessionsFolder);
                _sessionPointer = null;
            }
        }

        public void UpdateSessionEndTime()
        {
            if (_sessionPointer == null)
                return;

            lock (_sessionPointer)
            {

                var session = _sessionPointer.Get();
                session.StopDateTime = DateTime.Now;

                _sessionPointer.Set(session);
            }
        }

        public List<JsonFileDataPointer<Session>> GetSessions()
        {
            if (!Directory.Exists(TaskHelpers.sessionsFolder))
                return new List<JsonFileDataPointer<Session>>();


            var sessions = new List<JsonFileDataPointer<Session>>();

            DirectoryUtils.GetDirectoriesRecursiveParallel(TaskHelpers.sessionsFolder)
                .ForEach(i => sessions.Add(new JsonFileDataPointer<Session>(i)));

            return sessions;
        }

        #endregion
    }
}
