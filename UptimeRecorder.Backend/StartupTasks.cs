using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TastyIO;

namespace UptimeRecorder.Backend
{
    public sealed class StartupTasks
    {
        public static readonly StartupTasks Instance = new StartupTasks();

        public StartupTasks()
        {
            CreateSessionPointer();
        }

        #region Session

        internal JsonFileDataPointer<Session>? _sessionPointer;

        void CreateSessionPointer()
        {
            var session = new Session();
            _sessionPointer = new JsonFileDataPointer<Session>(Path.Combine(TaskHelpers.currentSessionFolder), session.Id.ToString());
            
            _sessionPointer.Set(session);
        }

        public void StartSession()
        {
            var session = _sessionPointer?.Get() ?? throw new Exception("Session already ended.");

            session.StartDateTime = DateTime.Now;

            _sessionPointer.Set(session);
            RuntimeTasks.Instance._sessionPointer = _sessionPointer;
            
        }

        #endregion
    }
}
