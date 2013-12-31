using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class Dal
    {
       public void ExecSp3P(string Spname, string PName1, string P1,string Pname2, string P2, string Pname3, string P3)
       {
           string connectionString = @"Data Source=localhost;Initial Catalog=TheNews;Integrated Security=True;Connect Timeout=30";
           SqlConnection sqlConnection1 = new SqlConnection(connectionString);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandText = Spname;
           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue(PName1, P1);
           cmd.Parameters.AddWithValue(Pname2, P2);
           cmd.Parameters.Add(Pname3,SqlDbType.Text,10000).Value=P3;
           cmd.Connection = sqlConnection1;
           try
           {
               sqlConnection1.Open();
               cmd.ExecuteNonQuery();
               sqlConnection1.Close();
           }
           catch (Exception ex)
           {
               var msg = ex.Message;
           }
       }

       public void ExecSp7P(string Spname, string Pname1, string P1, string Pname2, string P2, string Pname3, string P3
           ,string Pname4, string P4, string Pname5, string P5, string Pname6, string P6, string Pname7, string P7
           ) { 
       
        string connectionString = @"Data Source=localhost;Initial Catalog=TheNews;Integrated Security=True;Connect Timeout=30";
           SqlConnection sqlConnection1 = new SqlConnection(connectionString);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandText = Spname;
           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue(Pname1, P1);
           cmd.Parameters.AddWithValue(Pname2, P2);
           cmd.Parameters.Add(Pname3,SqlDbType.Text,10000).Value=P3;
           cmd.Parameters.AddWithValue(Pname4, P4);
           cmd.Parameters.AddWithValue(Pname5, P5);
           cmd.Parameters.AddWithValue(Pname6, P6);
               cmd.Parameters.AddWithValue(Pname7, P7);
           cmd.Connection = sqlConnection1;
           try
           {
               sqlConnection1.Open();
               cmd.ExecuteNonQuery();
               // Data is accessible through the DataReader object here.
               sqlConnection1.Close();
           }
           catch (Exception ex)
           {
               var msg = ex.Message;
           }
       
       
       }
    };

