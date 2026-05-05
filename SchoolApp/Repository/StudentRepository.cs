using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SchoolApp.Model;

namespace SchoolApp.Data
{
    public class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SchoolDB"]?.ConnectionString
                ?? throw new InvalidOperationException("Connection string 'SchoolDB' not found in App.config.");
        }

        public int InsertStudent(Students student)
        {
            const string sql = @"
INSERT INTO dbo.Students (FirstName, LastName, Age, Class, Section, FatherName, MotherName)
VALUES (@FirstName, @LastName, @Age, @Class, @Section, @FatherName, @MotherName);
SELECT CAST(SCOPE_IDENTITY() AS INT);
";
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@Class", student.Class ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Section", student.Section ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FatherName", student.FatherName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MotherName", student.MotherName ?? (object)DBNull.Value);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return (result != null) ? Convert.ToInt32(result) : 0;
                }
            }
            catch (SqlException ex)
            {
                // Log or rethrow as needed
                throw new Exception("Database error while inserting student.", ex);
            }
        }

        public bool UpdateStudent(Students student)
        {
            const string sql = @"
UPDATE dbo.Students
SET FirstName = @FirstName,
    LastName = @LastName,
    Age = @Age,
    Class = @Class,
    Section = @Section,
    FatherName = @FatherName,
    MotherName = @MotherName
WHERE Id = @Id;
";
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", student.Id);
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@Class", student.Class ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Section", student.Section ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FatherName", student.FatherName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MotherName", student.MotherName ?? (object)DBNull.Value);

                    conn.Open();
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while updating student.", ex);
            }
        }

        public bool DeleteStudent(int id)
        {
            const string sql = "DELETE FROM dbo.Students WHERE Id = @Id;";
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while deleting student.", ex);
            }
        }

        public Students GetStudentById(int id)
        {
            const string sql = "SELECT Id, FirstName, LastName, Age, Class, Section, FatherName, MotherName FROM dbo.Students WHERE Id = @Id;";
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                            return MapReaderToStudent(reader);
                        return null;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while retrieving student.", ex);
            }
        }

        public List<Students> GetAllStudents()
        {
            const string sql = "SELECT Id, FirstName, LastName, Age, Class, Section, FatherName, MotherName FROM dbo.Students ORDER BY Id;";
            var list = new List<Students>();
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapReaderToStudent(reader));
                        }
                    }
                }
                return list;
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while retrieving students.", ex);
            }
        }

        private Students MapReaderToStudent(SqlDataReader reader)
        {
            var s = new Students
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                FirstName = reader["FirstName"] as string,
                LastName = reader["LastName"] as string,
                Age = reader["Age"] != DBNull.Value ? Convert.ToInt32(reader["Age"]) : 0,
                Class = reader["Class"] as string,
                Section = reader["Section"] as string,
                FatherName = reader["FatherName"] as string,
                MotherName = reader["MotherName"] as string
            };
            return s;
        }
    }
}