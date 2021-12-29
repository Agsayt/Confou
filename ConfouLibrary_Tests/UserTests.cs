using ConfouLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConfouLibrary_Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CorrectUserCreation()
        {
            var guid = Guid.Parse("1C787089-B541-4F6E-9AAB-60EC0AC461CE");

            var user = new Users()
            {
                UserId = Guid.NewGuid(),
                Login = "CorrectTest2",
                PasswordHash = "PasswordWithoutHash",
                RoleId = guid,
                FirstName = "Юзр",
                LastName = "Юзрев",
                MiddleName = "Юзревич",
                Enabled = true,
                CreateDate = DateTime.Now,
                CreateAuthor = Guid.NewGuid(),
            };

            try
            {
                var cc = new ConfouLibrary.BusinessLogic.UsersManagement();
                bool v = cc.CreateUser(user, out string error);

                if (!v)
                    Assert.IsFalse(true, error);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(true, ex.Message);
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SQLInjectionUserCreation()
        {
                     
        }
    }
}
