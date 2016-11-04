using System;


namespace Northwind.Logic.Utils
{
    public static class Initer
    {
        public static void Init()
        {
            SessionFactory.Init(@"Server=.\SQLEXPRESS;Database=Northwind;Trusted_Connection=true");
        }
    }
}
