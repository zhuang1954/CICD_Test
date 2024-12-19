using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CICD_PracticesTest;

[TestFixture]
public class UnitTest1
{
    [Test]
    public void Test1()
    {
        Assert.That(1 == 1, Is.True);
    }


    [Test]
    public void Test2()
    {
        Assert.That(2 == 1, Is.True);
    }
}