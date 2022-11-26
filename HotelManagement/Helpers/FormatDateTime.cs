using System;
namespace HotelManagement.Helpers
{
    public class FormatDateTime
    {
        public static String formatDate(String date)
        {
            String cutDate = date.Substring(0, 10);
            string newDate = cutDate.Replace('-', '/');
            string[] result = newDate.Split('/');

            String dateFormatted = result[2] + "/" + result[1] + "/" + result[0];
            return dateFormatted;
        }
    }
}
