using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using UserMicroService.Models;
using UserMicroService.Util;

namespace UserMicroService.DataAccess
{
    public static class UserDB
    {
        public static User ReadDBRow(SqlDataReader reader) //iscitavanje iz baze
        {
            User retVal = new User();

            retVal.Id = (int)reader["Id"];
            retVal.Name = reader["Name"] as string;
            retVal.Email = reader["Email"] as string;

            return retVal;
        }

        public static User GetUserById(int Id)
        {
            try
            {
                User userToReturn = new User(); //model praznog usera koji kasnije popunjavamo 
                using (SqlConnection connection=new SqlConnection(DBFunctions.ConnectionString)) //koji server i koja baza
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = String.Format(@"
                        SELECT *
                        FROM [user].[User]
                        WHERE [Id]=@Id 
                    "); //@id je SQL parametar

                    command.Parameters.Add("@Id",SqlDbType.Int);
                    command.Parameters["@Id"].Value = Id;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader()) //upit nad bazom
                    {
                        if (reader.Read())
                        {
                            userToReturn = ReadDBRow(reader); //metoda koja vraca usera 1 po id
                        }
                    }
                }
                return userToReturn;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
        }
    }
}

        
    