using MyTeam.Entities;
using MyTeam.TestUtilities;
using MyTeam.UseCases;
using MyTeam.UseCases.SetUserPassword;
using NUnit.Framework;

namespace MyTeam.UnitTests.UseCase.SetUserPassword
{
    [TestFixture]
    public class SetUserPasswordUserCaseTest
    {
        private SetUserPasswordUserCase _useCase;
        private User _subject;

        [SetUp]
        public void SetUp()
        {
            TestFixture.Setup();
            _subject = TestFixture.Context.UserGateway.Save(new User("Subject"));
            _useCase = new SetUserPasswordUserCase(TestFixture.Context);
        }

        class WhenNotLoggedIn : SetUserPasswordUserCaseTest
        {

            [Test]
            public void Unauthorized()
            {
                Assert.False(TestFixture.Context.PasswordLocker.Verify(_subject.Id.Value, "password"));
                Assert.AreEqual(UseCaseStatus.Unauthorized, 
                    _useCase.SetUserPassword(_subject.UserName, "password").Status);
            }
        }

        class WhenLoggedInAsAdmin : SetUserPasswordUserCaseTest
        {
            [SetUp]
            public void SetUpInner()
            {
                User admin = new User("Admin");
                admin.AddRole(UserRoles.Admin);
                admin = TestFixture.Context.UserGateway.Save(admin);

                TestFixture.Context.GateKeeper.SetLoggedIn(admin);
            }

            [Test]
            public void CanChangePassword()
            {
                Assert.AreEqual(UseCaseStatus.Ok, 
                    _useCase.SetUserPassword(_subject.UserName, "password").Status);
                Assert.IsTrue(TestFixture.Context.PasswordLocker.Verify(_subject.Id.Value, "password"));
            }
        }

        class WhenLoggedInAsSubject : SetUserPasswordUserCaseTest
        {
            [SetUp]
            public void SetUpInner()
            {
                TestFixture.Context.GateKeeper.SetLoggedIn(_subject);
            }

            [Test]
            public void CanChangePassword()
            {
                Assert.AreEqual(UseCaseStatus.Ok, 
                    _useCase.SetUserPassword(_subject.UserName, "password").Status);
                Assert.IsTrue(TestFixture.Context.PasswordLocker.Verify(_subject.Id.Value, "password"));
            }

        }
    }
}
