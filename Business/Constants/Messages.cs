using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        // category
        public const string CategoryDescriptionEmpty = "Category description cannot be empty";
        public const string CategoryNameEmpty = "Category name cannot be empty";
        public const string CategoryNameTooLong = "Category name can have at most 30 letters";
        public const string CategoryDescriptionTooLong = "Category description can have at most 150 letters";


        // CRUD
        public const string Added = "Added";
        public const string Deleted = "Deleted";
        public const string Updated = "Updated";
        public const string Listed = "Listed";

        // Not found
        public const string NotFound = "Not found";

        // Authorization
        public const string AuthorizationDenied = "Authorization denied";

    }
}
