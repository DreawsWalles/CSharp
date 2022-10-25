using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace project
{
    static class DBWork
    {
        static SqlConnection connection = null;
        public static void Load(FormMain form)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBHistory"].ConnectionString);
            connection.Open();
            List<string> tmp = new List<string>();
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesMatrix]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    switch ((string)reader["Format"])
                    {
                        case "txt":
                            try
                            {
                                using (StreamReader file = new StreamReader((string)reader["FileName"]))
                                {
                                    TridiagonalMatrix matrix = new TridiagonalMatrix();
                                    matrix.Initialize(file);
                                    form.comboBox.Items.Add((string)reader["Name"]);
                                }
                            }
                            catch
                            {
                                tmp.Add((string)reader["Name"]);
                            }
                            break;
                        case "bin":
                            try
                            {
                                using (BinaryReader file = new BinaryReader(File.Open((string)reader["FileName"], FileMode.Open)))
                                {
                                    TridiagonalMatrix matrix = new TridiagonalMatrix();
                                    matrix.Initialize(file);
                                    form.comboBox.Items.Add((string)reader["Name"]);
                                }
                            }
                            catch
                            {
                                tmp.Add((string)reader["Name"]);
                            }
                            break;
                        case "XML":
                            try
                            {
                                using (FileStream file = new FileStream((string)reader["FileName"], FileMode.Open))
                                {
                                    TridiagonalMatrix matrix = new TridiagonalMatrix();
                                    matrix.Initialize(file);
                                    form.comboBox.Items.Add((string)reader["Name"]);
                                }
                            }
                            catch
                            {
                                tmp.Add((string)reader["Name"]);
                            }
                            break;
                    }
                }
            }
            foreach (string element in tmp)
            {
                command = new SqlCommand("DELETE FROM [FilesMatrix] where [Name] = @Name", connection);
                command.Parameters.AddWithValue("Name", element);
                command.ExecuteNonQuery();
            }
            if (form.comboBox.Items.Count > 0)
            {
                form.comboBox.SelectedIndex = form.comboBox.Items.Count - 1;
                form.nameMatrix.Text = form.comboBox.Text;
                form.comboBox.Visible = true;
            }
            tmp = new List<string>();
            command = new SqlCommand("SELECT * FROM [FilesVector]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    switch ((string)reader["Format"])
                    {
                        case "txt":
                            try
                            {
                                using (StreamReader file = new StreamReader((string)reader["FileName"]))
                                {
                                    ScalarVector vector = new ScalarVector();
                                    vector.Initialize(file);
                                    form.comboBoxVector.Items.Add((string)reader["Name"]);
                                }
                            }
                            catch
                            {
                                tmp.Add((string)reader["Name"]);
                            }
                            break;
                        case "bin":
                            try
                            {
                                using (BinaryReader file = new BinaryReader(File.Open((string)reader["FileName"], FileMode.Open)))
                                {
                                    ScalarVector vector = new ScalarVector();
                                    vector.Initialize(file);
                                    form.comboBoxVector.Items.Add((string)reader["Name"]);
                                }
                            }
                            catch
                            {
                                tmp.Add((string)reader["Name"]);
                            }
                            break;
                        case "XML":
                            try
                            {
                                using (FileStream file = new FileStream((string)reader["FileName"], FileMode.Open))
                                {
                                    ScalarVector vector = new ScalarVector();
                                    vector.Initialize(file);
                                    form.comboBoxVector.Items.Add((string)reader["Name"]);
                                }
                            }
                            catch
                            {
                                tmp.Add((string)reader["Name"]);
                            }
                            break;
                    }
                }
            }
            foreach(string element in tmp)
            {
                command = new SqlCommand("DELETE FROM [FilesVector] where [Name] = @Name", connection);
                command.Parameters.AddWithValue("Name", element);
                command.ExecuteNonQuery();
            }
            if (form.comboBoxVector.Items.Count > 0)
            {
                form.comboBoxVector.SelectedIndex = form.comboBoxVector.Items.Count - 1;
                form.NameVector.Text = form.comboBoxVector.Text;
                form.comboBoxVector.Visible = true;
            }
        }
        public static void AddMatrix(string filePath)
        {
            string[] tmp = filePath.Split('\\');
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesMatrix]", connection);
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    if ((string)reader["Name"] == tmp[tmp.Length - 1])
                        throw new Exception("Матрица с таким именем уже сущетсвует в ранее добавленных");   
            }
            command = new SqlCommand("INSERT INTO [FilesMatrix] (Name, FileName, Format) VALUES (@Name, @FileName, @Format)", connection);
            command.Parameters.AddWithValue("Name", tmp[tmp.Length - 1]);
            tmp = tmp[tmp.Length - 1].Split('.');
            command.Parameters.AddWithValue("FileName", filePath);
            command.Parameters.AddWithValue("Format", tmp[1]);
            command.ExecuteNonQuery();
        }
        public static void AddVector(string filePath)
        {
            string[] tmp = filePath.Split('\\');
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesVector]", connection);
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    if ((string)reader["Name"] == tmp[tmp.Length - 1])
                        throw new Exception("Вектор с таким же именем уже существует в ранее добавленных");
            }
            command = new SqlCommand("INSERT INTO [FilesVector] (Name, FileName, Format) VALUES (@Name, @FileName, @Format)", connection);
            command.Parameters.AddWithValue("Name", tmp[tmp.Length - 1]);
            tmp = tmp[tmp.Length - 1].Split('.');
            command.Parameters.AddWithValue("FileName", filePath);
            command.Parameters.AddWithValue("Format", tmp[1]);
            command.ExecuteNonQuery();
        }
        public static string GetFilePathMatrix(string fileName)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesMatrix]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    if ((string)reader["Name"] == fileName)
                        return (string)reader["FileName"];
            }
            return null;
        }
        public static string GetFormatMatrix(string fileName)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesMatrix]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    if ((string)reader["Name"] == fileName)
                        return (string)reader["Format"];
            }
            return null;
        }
        public static string GetFilePathVector(string fileName)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesVector]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    if ((string)reader["Name"] == fileName)
                        return (string)reader["FileName"];
            }
            return null;
        }
        public static string GetFormatVector(string fileName)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesVector]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    if ((string)reader["Name"] == fileName)
                        return (string)reader["Format"];
            }
            return null;
        }
        public static void RemoveMatrix(string fileName, FormMain form)
        {
            form.comboBox.Items.Clear();
            SqlCommand command = new SqlCommand("DELETE FROM [FilesMatrix] where [Name] = @Name", connection);
            command.Parameters.AddWithValue("Name", fileName);
            command.ExecuteNonQuery();
            command = new SqlCommand("SELECT * FROM [FilesMatrix]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    form.comboBox.Items.Add((string)reader["Name"]);
                }
            }
        }
        public static bool CheckNameMatrix(string fileName)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesMatrix]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    if ((string)reader["Name"] == fileName)
                        return false;
            }
            return true;
        }
        public static void RemoveVector(string fileName, FormMain form)
        {
            form.comboBoxVector.Items.Clear();
            SqlCommand command = new SqlCommand("DELETE FROM [FilesVector] where [Name] = @Name", connection);
            command.Parameters.AddWithValue("Name", fileName);
            command.ExecuteNonQuery();
            command = new SqlCommand("SELECT * FROM [FilesVector]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    form.comboBoxVector.Items.Add((string)reader["Name"]);
                }
            }
        }
        public static bool CheckNameVector(string fileName)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesVector]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    if ((string)reader["Name"] == fileName)
                        return false;
            }
            return true;
        }
        public static void UpdateMatrix(string fileName, FormMain form)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesMatrix]", connection);
            int count = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    if ((string)reader["Name"] == fileName)
                        count++;
                    if (count == 2)
                        throw new Exception("Матрица с таким именем уже сущетсвует в ранее добавленных");
            }
            form.comboBox.Items.Clear();
            command = new SqlCommand("UPDATE [FilesMatrix] Set [Name] = @Name", connection);
            command.Parameters.AddWithValue("Name", fileName);
            command.ExecuteNonQuery();
            command = new SqlCommand("SELECT * FROM [FilesMatrix]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    form.comboBox.Items.Add((string)reader["Name"]);
                }
            }
            form.comboBox.SelectedIndex = form.comboBox.Items.Count - 1;
        }
        public static void UpdateVector(string fileName, FormMain form)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesVector]", connection);
            int count = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    if ((string)reader["Name"] == fileName)
                        count++;
                if (count == 2)
                    throw new Exception("Вектор с таким именем уже сущетсвует в ранее добавленных");
            }
            form.comboBoxVector.Items.Clear();
            command = new SqlCommand("UPDATE [FilesVector] Set [Name] = @Name", connection);
            command.Parameters.AddWithValue("Name", fileName);
            command.ExecuteNonQuery();
            command = new SqlCommand("SELECT * FROM [FilesVector]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    form.comboBoxVector.Items.Add((string)reader["Name"]);
                }
            }
            form.comboBoxVector.SelectedIndex = form.comboBoxVector.Items.Count - 1;
        }
        public static int GetCountMatrices()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesMatrix]", connection);
            int count = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    count++;
            }
            return count;
        }
        public static int GetCountVectors()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesVector]", connection);
            int count = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    count++;
            }
            return count;
        }
        public static void LoadComboBoxes(ComboBox firstParam, ComboBox secondParam, ComboBox result = null)
        {
            firstParam.Items.Clear();
            firstParam.Items.Add("None");
            firstParam.Items.Add("--Матрицы--");
            secondParam.Items.Clear();
            secondParam.Items.Add("None");
            secondParam.Items.Add("--Матрицы--");
            if (result != null)
            {
                result.Items.Clear();
                result.Items.Add("None");
                result.Items.Add("--Матрицы--");
            }
            SqlCommand command = new SqlCommand("SELECT * FROM [FilesMatrix]", connection);
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    firstParam.Items.Add((string)reader["Name"]);
                    secondParam.Items.Add((string)reader["Name"]);
                    if (result != null)
                        result.Items.Add((string)reader["Name"]);
                }
            }
            firstParam.Items.Add("--Вектора--");
            secondParam.Items.Add("--Вектора--");
            if (result != null)
                result.Items.Add("--Вектора--");
            command = new SqlCommand("SELECT * FROM [FilesVector]", connection);
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    firstParam.Items.Add((string)reader["Name"]);
                    secondParam.Items.Add((string)reader["Name"]);
                    if (result != null)
                        result.Items.Add((string)reader["Name"]);
                }
            }
            firstParam.SelectedIndex = 0;
            secondParam.SelectedIndex = 0;
            if (result != null)
                result.SelectedIndex = 0;
        }
    }
}
