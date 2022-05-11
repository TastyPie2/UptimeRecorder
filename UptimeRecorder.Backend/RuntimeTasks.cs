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
            var session = _sessionPointer?.Get() ?? throw new Exception("Session already ended.");

            session.StopDateTime = DateTime.Now;

            _sessionPointer.Set(session);
            _sessionPointer.Move(TaskHelpers.sessionsFolder);
            _sessionPointer = null;
        }



        List<JsonFileDataPointer<Session>> GetSessions()
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
