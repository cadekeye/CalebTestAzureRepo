using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DAL2.Models;

namespace DAL2.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly RestaurantDBEntities restaurantDbContext;

        public CustomerRepository(RestaurantDBEntities restaurantDbContext) : base(restaurantDbContext) {
            this.restaurantDbContext = restaurantDbContext;
        }
        public IQueryable<Customer> GetNextCustomers(int skip, int take) {
            var query = from a in this.restaurantDbContext.Customers
                orderby a.CustomerID
                select a;
            //restaurantDbContext.Database.ExecuteSqlCommand()
           return query.Skip(skip).Take(take);
        }

        private IEnumerable<T> ConvertDataTableToList<T>(DataTable dataTable) where T : class {
            List<T> data = new List<T>();

            foreach (DataRow row in dataTable.Rows) {
                T item = GetItem<T>(row);
                data.Add(item);
            }

            return data;
        }

        private static T GetItem<T>(DataRow row) where T : class {
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in row.Table.Columns) {
                foreach (var prop in typeof(T).GetProperties()) {
                    if (column.ColumnName == prop.Name) {
                       prop.SetValue(obj, row[column.ColumnName], null);
                       break;
                    } else {
                        continue;
                    }
                }
            }

            return obj;
        }

        //public IEnumerable<Customer> GetCustomerBySqlCommand(string sql, params object[] param) {
        //   // var conn = ConfigurationManager.ConnectionStrings["RestaurantDBEntities"].ConnectionString;
        //   var connString = "Data Source=TMPC125;Initial Catalog=RestaurantDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        //    using (var sqlConn = new SqlConnection(connString)) {
        //        sqlConn.Open();

        //        using (var sqlCommand = new SqlCommand(sql, sqlConn)) {
        //            sqlCommand.CommandType = CommandType.Text;

        //            using (var reader = sqlCommand.ExecuteReader()) {
        //                DataTable dataTable = new DataTable();

        //                dataTable.Load(reader);
        //                return ConvertDataTableToList<Customer>(dataTable);
        //                //return (IEnumerable<Customer>) dataTable.AsEnumerable();
        //            }
        //        }
        //    }
        //}
    }
}
