using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ShoppingCart.DAL
{
    /// <summary>
    /// Doesn't attempt to check for model compatibility. Since we are using EF code-first, no compatibility checks are required.
    /// This saves us a couple of database queries and prevents some failed query 'noise' when logging SQL queries
    /// </summary>
    public class SilentDatabaseInitializer : IDatabaseInitializer<ShoppingCartContext>
    {
        public void InitializeDatabase(ShoppingCartContext context)
        {
            // Do nothing
        }
    }

    /// <summary>
    /// Doesn't attempt to check for model compatibility. Since we are using EF code-first, no compatibility checks are required.
    /// This saves us a couple of database queries and prevents some failed query 'noise' when logging SQL queries
    /// </summary>
    public class SilentNorthwindDatabaseInitializer : IDatabaseInitializer<NorthwindDataContext>
    {
        public void InitializeDatabase(NorthwindDataContext context)
        {
            // Do nothing
        }
    }
}
