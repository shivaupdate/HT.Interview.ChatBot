using HT.Interview.ChatBot.Common.Entities;
using System.Linq;

namespace HT.Interview.ChatBot.Test
{
    public class FakeUserDBSet : FakeDbSet<User>
    {
        public override User Find(params object[] keyValues)
        {
            var keyValue = (int)keyValues.FirstOrDefault();
            return this.SingleOrDefault(x => x.Id == keyValue);
        }
    }
}
