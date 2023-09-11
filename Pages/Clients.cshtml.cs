using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace SImpleWebApp.Pages
{
    public class ClientsModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=simpleWeb1;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                ClientInfo clients = new ClientInfo();
								clients.id = reader.GetInt32(0);
                                clients.name = reader.GetString(1);
                                clients.email = reader.GetString(2);
                                clients.phone = reader.GetString(3);
                                clients.address = reader.GetString(4);

                                listClients.Add(clients);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {

            } 
           
        }
    }
    public class ClientInfo
    {
        public int id;
        public string name;
        public string email;
        public string phone;
        public string address;
    }
}
