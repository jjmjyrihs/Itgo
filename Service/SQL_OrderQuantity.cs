﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Service
{
    public class SQL_OrderQuantity
    {
        public void InsertBook_Quantity(string Book_ID, string GetOrder_Quantity, string Order_ID)
        {
            string sql = "update dbo.Shopping_Car set Order_Quantity=" + GetOrder_Quantity +" where Book_ID = '" + Book_ID + "'";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString);
            using (conn)
            {
                conn.Open();
              
                SqlCommand cmd_sql = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter_sql = new SqlDataAdapter(cmd_sql);
                try
                {
                    cmd_sql.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    conn.Close();
                }
                conn.Close();
            }
        }
    }
}
