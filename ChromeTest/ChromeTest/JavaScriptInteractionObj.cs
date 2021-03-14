using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ChromeTest
{
public class Person
{
    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = birthDate;
    }

    private string FirstName { get; }
    private string LastName { get; }
    private DateTime DateOfBirth { get; }
    public int SkillLevel { get; set; }
}

    public class JavaScriptInteractionObj
    {
        private Person _mTheMan = null;

        [JavascriptIgnore] private ChromiumWebBrowser MChromeBrowser { get; set; }

        public JavaScriptInteractionObj()
        {
            _mTheMan = new Person("Bat", "Man", DateTime.Now);
        }

        [JavascriptIgnore]
        public void SetChromeBrowser(ChromiumWebBrowser b)
        {
            MChromeBrowser = b;
        }

        public string SomeFunction()
        {
            return "yippieee";
        }

        public string GetPerson()
        {
            var p1 = new Person( "Bruce", "Banner", DateTime.Now );

            string json = JsonConvert.SerializeObject(p1);

            return json;
        }

        public string ErrorFunction()
        {
            return null;
        }

        public string GetListOfPeople()
        {
            var peopleList = new List<Person>
            {
                new Person("Scooby", "Doo", DateTime.Now),
                new Person("Buggs", "Bunny", DateTime.Now),
                new Person("Daffy", "Duck", DateTime.Now),
                new Person("Fred", "Flinstone", DateTime.Now),
                new Person("Iron", "Man", DateTime.Now)
            };

            var json = JsonConvert.SerializeObject(peopleList);

            return json;
        }

        public void ExecJSFromWinForms()
        {
            const string script = "document.body.style.backgroundColor = 'red';";

            MChromeBrowser.ExecuteScriptAsync(script);
        }

        public void TestJSCallback(IJavascriptCallback javascriptCallback)
        {
            using (javascriptCallback)
            {
                javascriptCallback.ExecuteAsync("Hello from winforms and C# land!");
            }
        }
    }
}