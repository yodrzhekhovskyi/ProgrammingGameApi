using ProgrammingGameApi.Services.Helpers.FakeDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingGameApi.Services.Helpers
{
    /// <summary>
    /// Fake in-memory db
    /// </summary>
    public class Db
    {
        /// <summary>
        /// Creates new <see cref="Db"></see>
        /// </summary>
        public Db()
        {
            //Add initial set of riddles where db instance is created
            FillRiddles();
        }

        /// <summary>
        /// List of riddles (Riddles table)
        /// </summary>
        public List<Riddle> Riddles { get; set; } = new List<Riddle>();

        /// <summary>
        /// List of users (Users table)
        /// </summary>
        public List<User> Users { get; set; } = new List<User>()
        {
            new User()
            {
                Id = 1,
                UserName = "admin",
                Password = "guest",
                Email = "admin@a.com"
            }
        };

        /// <summary>
        /// List of user stats (UserStats table)
        /// </summary>
        public List<UserStats> UsersStats { get; set; } = new List<UserStats>()
        {
            new UserStats()
            {
                UserId = 1,
                UserName = "admin"
            }
        };

        /// <summary>
        /// Fills Riddles table with initial data
        /// </summary>
        private void FillRiddles()
        {
            var riddles = new List<Riddle>
            {
                new Riddle
                {
                    Description = "You need to create a program which will sum 2 passed int numbers. Number are passed on new lines",
                    Id = 1,
                    Name = "Sum Riddle",
                    TestCases = new List<TestCase>
                    {
                        new TestCase
                        {
                            Args = new object [] { 1, 2},
                            Result = 3
                        },
                        new TestCase
                        {
                            Args = new object [] { 3, 4 },
                            Result = 7
                        }
                    }
                },
                new Riddle
                {
                    Description = "You need to create a program which will multiply 2 passed int numbers. Number are passed on new lines",
                    Id = 2,
                    Name = "Multiply Riddle",
                    TestCases = new List<TestCase>
                    {
                        new TestCase
                        {
                            Args = new object [] { 1, 2},
                            Result = 2
                        },
                        new TestCase
                        {
                            Args = new object [] { 0, 2 },
                            Result = 0
                        },
                        new TestCase
                        {
                            Args = new object [] { 10, 4 },
                            Result = 40
                        }
                    }

                },
                new Riddle
                {
                    Description = "You need to create a program which will subtract 2 passed numbers. Number are passed on new lines",
                    Id = 3,
                    Name = "Subtract Riddle",
                    TestCases = new List<TestCase>
                    {
                        new TestCase
                        {
                            Args = new object [] { 1, 2},
                            Result = -1
                        },
                        new TestCase
                        {
                            Args = new object [] { 20, 4 },
                            Result = 16
                        }
                    }

                }
            };

            Riddles.AddRange(riddles);
        }
    }
}
