using System.Collections.Generic;

namespace NsubstituteExtraExercise3
{
    public interface IAuditLogger
    {
        void AddMessage(string message);
        List<string> GetLog();
    }
}