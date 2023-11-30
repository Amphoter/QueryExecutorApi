namespace SimpleQueriesExecutor.Constants
{
    public static class OraFunctions
    {
        // public const string
        public static string ValidateQuery(string queryToValidate) => "declare " +
             "l_cursor NUMBER := dbms_sql.open_cursor;" +
             " BEGIN   " +
             " BEGIN" +
             " DBMS_SQL.PARSE (l_cursor, @query, DBMS_SQL.native);".Replace("@query", "'" + queryToValidate.Replace("'","''") + "'") +
             " EXCEPTION WHEN OTHERS THEN DBMS_SQL.CLOSE_CURSOR (l_cursor); RAISE;  END; DBMS_SQL.CLOSE_CURSOR (l_cursor);" +
             " END;";
    }
}
