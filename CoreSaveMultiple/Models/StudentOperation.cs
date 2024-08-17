using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Data;
namespace CoreSaveMultiple.Models
{
    public class StudentOperation
    {
        private readonly DbConnection _connect;
        public StudentOperation(DbConnection connect)
        {
            _connect = connect;
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students = new List<Student>();
            using (SqlConnection conn = _connect.getConnection())
            {
                await conn.OpenAsync();

                string query = "SELECT * FROM tbl_Student";

                using (var command = new SqlCommand(query, conn))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var student = new Student
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                age = reader.GetInt32(2),
                                address = reader.GetString(3),
                                mobileno = reader.GetString(4),
                                city = reader.GetString(5),
                                fees = reader.GetDecimal(6)
                            };
                            students.Add(student);
                        }
                    }
                }
            }
            return students;
        }
        public async Task UpdateStudentsAsync(List<Student> students)
        {
            using (SqlConnection conn = _connect.getConnection())
            {
                await conn.OpenAsync();
                try
                {
                    foreach (var student in students)
                    {
                        string query = "UPDATE tbl_Student SET name = @name, age = @age, saddress = @address,smobileno=@mobile,scity=@city,sfee=@fee WHERE sid= @Id";

                        using (var command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@name",student.name);
                            command.Parameters.AddWithValue("@age",student.age);
                            command.Parameters.AddWithValue("@address",student.address);
                            command.Parameters.AddWithValue("@mobile",student.mobileno);
                            command.Parameters.AddWithValue("@city",student.city);
                            command.Parameters.AddWithValue("@fee",student.fees);
                            command.Parameters.AddWithValue("@Id",student.id);
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch(Exception ex)
                {
                    
                }
            }
        }
    }
}
