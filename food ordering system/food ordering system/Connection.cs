using food_ordering_system.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace food_ordering_system
{
    public class Connection
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }
    }

    public class Utils
    {
        SqlConnection conn;
        SqlCommand cmd;

        public static bool IsValidExtension(string fileName)
        {

            bool isValid = false;
            string[] fileExtension = { ".jpg", ".png", "jpeg" };
            for (int i = 0; i < fileExtension.Length - 1; i++)
            {

                if (fileName.Contains(fileExtension[i]))
                {
                    isValid = true;
                    break;
                }



            }
            return isValid;

        }

        //setting default image if there is no image exist

        public static string GetImageUrl(object url)
        {

            string url1 = "";
            if(string.IsNullOrEmpty(url.ToString()) || url==DBNull.Value)
            {

                url1 = "../Images/No_image.png";


            }

        else
            {

                url1 = string.Format("../{0}",url);

               

            }
            //return resolverUrl(url1)
            return url1;

        }

        public bool updateCartQuantity(int quantity,int productId, int userId)
        {
            bool isUpdated = false;
            conn = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Cartt_Crud", conn);
            cmd.Parameters.AddWithValue("@Action", "UPDATE");
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                isUpdated = false;
                System.Web.HttpContext.Current.Response.Write("<Script>alert('Error - " + ex.Message + "');<script>");
                    }
            finally
            {
                conn.Close();
            }
            return isUpdated;
        }

    }

}