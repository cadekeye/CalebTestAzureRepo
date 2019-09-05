using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DAL2.Models;

namespace DAL2.Repositories
{
    public class Repository<T> : IRepository<T> where T : class {
        private readonly RestaurantDBEntities restaurantDbContext;
        public Repository(RestaurantDBEntities restaurantDbContext)
        {
            this.restaurantDbContext = restaurantDbContext;
        }

        public IEnumerable<T> GetEntityBySqlCommand(string sql, params object[] param)
        {
            // var conn = ConfigurationManager.ConnectionStrings["RestaurantDBEntities"].ConnectionString;
            var connString = "Data Source=TMPC125;Initial Catalog=RestaurantDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
            using (var sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();

                using (var sqlCommand = new SqlCommand(sql, sqlConn))
                {
                    sqlCommand.CommandType = CommandType.Text;

                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();

                        dataTable.Load(reader);
                        return ConvertDataTableToList(dataTable);
                    }
                }
            }
        }
        private static IEnumerable<T> ConvertDataTableToList(DataTable dataTable)
        {
            List<T> data = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                T item = GetItem(row);
                data.Add(item);
            }

            return data;
        }

        private static T GetItem(DataRow row)
        {
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in row.Table.Columns)
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (column.ColumnName == prop.Name)
                    {
                        prop.SetValue(obj, row[column.ColumnName], null);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return obj;
        }

        public void Add(T entity) {
            restaurantDbContext.Set<T>().Add(entity);
        }

        public void Remove(T entity) {
            restaurantDbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll() {
            return restaurantDbContext.Set<T>().ToList();
        }

        public async Task<T> GetAllById(int id) {
            return await restaurantDbContext.Set<T>().FindAsync();
        }

        public IQueryable<T> GetNextEntities(string sql, params object[] param) {
            return restaurantDbContext.Database.SqlQuery<T>(sql, param).AsQueryable();
        }
    }
}
