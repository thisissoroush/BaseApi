
namespace BaseAPI.Contracts.v1
{
    public static class ApiRoutes
    {
        public const string root = "api";
        public const string version = "v1";
        public const string Base = root + "/" + version;

        public static class Test
        {
            public const string GetAll = Base + "/test";
        }
        public static class Identity
        {
            public const string partBase = Base + "/identity";

            public const string login = partBase + "/login";
            public const string register = partBase + "/register";
        }
        public static class Google
        {
            public const string partBase = Base + "/google";

            public const string addQuery = partBase + "/addQuery";
            public const string getSearchQueries = partBase + "/getsearchqueries";
            public const string setResult = partBase + "/setresult";
            public const string whatToDo = partBase + "/whattodo";

        }

    }
}
