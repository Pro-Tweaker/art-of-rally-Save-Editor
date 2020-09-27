using System;

namespace art_of_rally_Save_Editor.Utils
{
    public static class DateUtils
    {
        public static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}
