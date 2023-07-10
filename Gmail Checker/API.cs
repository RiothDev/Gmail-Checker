using System;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace App
{
    internal class EmailAPI
    {
        public static async Task<bool> SendRequest(string email)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://mail.google.com/mail/gxlu?email={email}");

                    foreach (var header in response.Headers) if (Convert.ToString(header.Key) == "Set-Cookie") return false;

                    return true;

                } catch(Exception e)
                {
                    return false;
                }
            }
        }

        public static string Check(bool state) {
            return state ? "Available" : "Not available";
        }
    }
}