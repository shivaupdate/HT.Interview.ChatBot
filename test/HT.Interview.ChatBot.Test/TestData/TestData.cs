using HT.Interview.ChatBot.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace HT.Interview.ChatBot.Test
{
    public class TestData
    {
        public IQueryable<UserCreateRequest> User
        {
            get
            {
                List<UserCreateRequest> uc = new List<UserCreateRequest>
                {
                    new UserCreateRequest
                    {
                        Id = 1,
                        FirstName = "Ravindra",
                        LastName = "Khapate",
                        Email = "ravindrak@hexaware.com",
                        CreatedBy = "RavindraK",
                        CreatedOn = DateTime.Now,
                        ModifiedBy = "",
                        ModifiedOn = null
                    },
                    new UserCreateRequest
                    {
                        Id = 2,
                        FirstName = "Gourav",
                        LastName = "Tyagi",
                        Email = "tyagi@hexaware.com",
                        CreatedBy = "RavindraK",
                        CreatedOn = DateTime.Now,
                        ModifiedBy = "",
                        ModifiedOn = null
                    }
                };
                return uc.AsQueryable();
            }
        }
    }

    public class TestDataHelper
    {
        private static readonly Random Random = new Random((int)DateTime.Now.Ticks);

        public static string GenerateRandomText(int size, bool upperCase = false)
        {
            string input = "abcdefghijklmnopqrstuvwxyz";
            IEnumerable<char> chars = Enumerable.Range(0, size)
                    .Select(x => input[Random.Next(0, input.Length)]);
            string randomText = new string(chars.ToArray());
            if (upperCase)
            {
                randomText = randomText.ToUpper();
            }
            return randomText;
        }

        public static int GenerateRandomNumber(int size)
        {
            Random random = new Random();
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                output.Append(random.Next(0, 10));
            }
            return int.TryParse(output.ToString(), out int num) ? num : 0;
        }

    }
}