using System;
namespace Tutorial.Akka04.Persistence.Messages
{
    public class SetSomeValueMessage
    {
        public string Value { get; }

        public SetSomeValueMessage(string val)
        {
            Value = val;
        }
    }
}
