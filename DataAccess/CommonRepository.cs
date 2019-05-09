using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class CommonRepository
    {
        private string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RpRecipeManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int ExecuteNonQuery(string q)
        {
            int rowsAffected = 0;

            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(q, con))
            {
                con.Open();

                rowsAffected = com.ExecuteNonQuery();
            }
            return rowsAffected;
        }

        public int ExecuteNonQueryScalar(string q)
        {
            int id = 0;
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(q, con))
            {
                con.Open();

                id = (int)com.ExecuteScalar();
            }
            return id;
        }

        public DataTable ExecuteQuery(string q)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(q, con))
            using (SqlDataAdapter dap = new SqlDataAdapter(com))
            {
                dap.Fill(ds);
            }
            return ds.Tables[0];
        }

        public void BulkInsert(DataTable table, string destination)
        {

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conString))
            {
                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.DestinationTableName = destination;
                bulkCopy.WriteToServer(table);
            }
        }
    }
}
