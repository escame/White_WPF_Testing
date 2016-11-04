using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Utility;

namespace SmokeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_add_a_department()
        {
            //Launch the application
            Application application = Application.Launch(
                @"C:\Users\tfslabservice\Source\Repos\White_WPF_Testing\SmokeTests\Northwind.UI\bin\Debug\Northwind.UI.exe");

            //Wait for App to open
            Window main = Retry.For(() => application.GetWindows().First(x => x.Title.Contains("Northwind")),
                TimeSpan.FromSeconds(10));
            
            //Select Department
            var listBox = main.Get<ListBox>();
            listBox.Item("Departments").Select();
            
            //Click Add
            main.Get<Button>(SearchCriteria.ByText("Add")).Click();

            //Wait for window to open
            Window newDepartment = Retry.For(() => application.GetWindows().First(x => x.Title.Contains("New department")),
                TimeSpan.FromSeconds(5));

            //Fill the form
            newDepartment.Get<TextBox>().Text = "Automation Department";

            //Click OK
            newDepartment.Get<Button>(SearchCriteria.ByText("OK")).Click();

            //Verify the Department was stored
            var departments = main.Get<ListView>();
            Assert.AreEqual("Automation Department", departments.Rows[0].Cells["Name"].Text);
        }

        [TestMethod]
        public void Can_add_a_project()
        {
            //Launch the application
            Application application = Application.Launch(
                @"C:\Users\tfslabservice\Source\Repos\White_WPF_Testing\SmokeTests\Northwind.UI\bin\Debug\Northwind.UI.exe");

            //Wait for App to open
            Window main = Retry.For(() => application.GetWindows().First(x => x.Title.Contains("Northwind")),
                TimeSpan.FromSeconds(10));

            //Select Department
            var listBox = main.Get<ListBox>();
            listBox.Item("Projects").Select();

            //Click Add
            main.Get<Button>(SearchCriteria.ByText("Add")).Click();

            //Wait for window to open
            Window newProject = Retry.For(() => application.GetWindows().First(x => x.Title.Contains("New project")),
                TimeSpan.FromSeconds(5));

            //Fill the form
            newProject.Get<TextBox>(SearchCriteria.Indexed(0)).Text = "Internal project";
            newProject.Get<TextBox>(SearchCriteria.Indexed(1)).Text = "10000";

            //Click OK
            newProject.Get<Button>(SearchCriteria.ByText("OK")).Click();

            //Verify the Department was stored
            var projects = main.Get<ListView>();
            Assert.AreEqual("Internal project", projects.Rows[0].Cells["Name"].Text);
        }
    }
}
