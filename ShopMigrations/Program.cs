﻿using Microsoft.EntityFrameworkCore;

namespace ShopMigrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ContextFactory().CreateDbContext(args).Database.Migrate();
        }
    }
}
