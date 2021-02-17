using MyTeam.TestUtilities;
using TechTalk.SpecFlow;

namespace MyTeam.Specs.Steps
{
    [Binding]
    public class GivenSystem
    {
        [Given(@"A Newly Configured System")]
        public void GivenANewlyConfiguredSystem()
        {
            TestFixture.Setup();
        }
    }
}
