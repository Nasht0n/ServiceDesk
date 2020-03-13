using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Reflection;

namespace Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Domain.ServiceDeskContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Domain.ServiceDeskContext context)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            // Create View Requests
            var baseDir = Path.GetDirectoryName(path) + "\\Migrations\\RequestsView.sql";
            context.Database.ExecuteSqlCommand(File.ReadAllText(baseDir));
        }
    }
}
