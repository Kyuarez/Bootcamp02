using MySqlConnector;
using System.Data;

namespace MysqlClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Login
            string connectionString = "server=localhost;user=root;database=membership;password=0575";
            MySqlConnection mysqlConnection = new MySqlConnection(connectionString);

            try
            {
                mysqlConnection.Open();

                MySqlCommand mysqlCommand = new MySqlCommand();
                mysqlCommand.Connection = mysqlConnection;
                //mysqlCommand.CommandText = "select * from users limit 0, 10";
                mysqlCommand.CommandText = "select * from users where user_id = @user_id and user_password = @user_password";
                mysqlCommand.Prepare();
                mysqlCommand.Parameters.AddWithValue("@user_id", "manager");
                mysqlCommand.Parameters.AddWithValue("@user_password", "manager");

                MySqlDataReader dataReader = mysqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader["name"] + ", " + dataReader["email"]);
                }
                dataReader.Close();

                    //회원가입
                    MySqlCommand assignCommand = new MySqlCommand();
                    assignCommand.Connection = mysqlConnection;
                    assignCommand.CommandText = "insert into users (user_id, user_password, name, email) values ( @user_id, @user_password, @name, @email)";
                    assignCommand.Prepare();
                    assignCommand.Parameters.AddWithValue("@user_id", "abc001");
                    assignCommand.Parameters.AddWithValue("@user_password", "2855");
                    assignCommand.Parameters.AddWithValue("@name", "신지용");
                    assignCommand.Parameters.AddWithValue("@email", "abc001@naver.com");
                    assignCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mysqlConnection.Close();
            }

            mysqlConnection.Close();
        

        }
    }
}
