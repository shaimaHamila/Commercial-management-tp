using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using MODEL;
namespace CONTROLLER.Controllers
{
    public class ClientController
    {
        public static ClientController obje;
        public List<Client> liste = new List<Client>();
        public bool isloaded = false;
        Connection connection = new Connection();
        public void getClient()
        {
            if (!isloaded)
            {
                Connection.connecter();
                String query = "select * from Client";
                SqlDataReader reader = Connection.ExecuteReader(query);

                while (reader.Read())
                {
                    Client client = new Client();
                    client.Code = Convert.ToInt32(reader.GetValue(0));
                    client.FirstName = Convert.ToString(reader.GetValue(1));
                    client.LastName = Convert.ToString(reader.GetValue(2));
                    client.Address = Convert.ToString(reader.GetValue(3));
                    client.Phone = Convert.ToString(reader.GetValue(4));
                    client.Email = Convert.ToString(reader.GetValue(5));
                    liste.Add(client);
                }
                reader.Close();
                Connection.connecter().Close();
                isloaded = true;
            }
        }

        public void saveClient(Client client)
        {
            Connection.connecter();
            SqlCommand query = new SqlCommand();

            query.CommandText = "insert into Client(firstName,lastName,address,phone,email) values(@firstName,@lastName,@address,@phone,@email)";
            query.CommandType = CommandType.Text;

            SqlParameter firstName = new SqlParameter("@firstName", SqlDbType.VarChar);
            SqlParameter lastName = new SqlParameter("@lastName", SqlDbType.VarChar);
            SqlParameter address = new SqlParameter("@address", SqlDbType.VarChar);
            SqlParameter phone = new SqlParameter("@phone", SqlDbType.VarChar);
            SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar);

            firstName.Value = client.FirstName;
            lastName.Value = client.LastName;
            address.Value = client.Address;
            phone.Value = client.Phone;
            email.Value = client.Email;

            query.Parameters.Add(firstName);
            query.Parameters.Add(lastName);
            query.Parameters.Add(address);
            query.Parameters.Add(phone);
            query.Parameters.Add(email);

            Connection.ExecuteCommand(query);
            Console.WriteLine("Client Added Successfully");
        }

        public void deleteClient(Client clien)
        {
            Connection.connecter();
            SqlCommand query = new SqlCommand("delete from Client where Client.code = @code", Connection.connecter());
            query.Parameters.AddWithValue("@code", clien.Code);
            Connection.ExecuteCommand(query);
            Console.WriteLine("Client deleted successfully :)");
        }

        public void UpdateClient(Client client)
        {
            Connection.connecter();
            SqlCommand query = new SqlCommand("UPDATE client SET firstName = @firstName, lastName = @lastName, address = @address, phone = @phone, email = @email WHERE code = @code",
                                                    Connection.connecter());

            query.Parameters.AddWithValue("@code", client.Code);
            query.Parameters.AddWithValue("@firstName", client.FirstName);
            query.Parameters.AddWithValue("@lastName", client.LastName);
            query.Parameters.AddWithValue("@address", client.Address);
            query.Parameters.AddWithValue("@phone", client.Phone);
            query.Parameters.AddWithValue("@email", client.Email);

            Connection.ExecuteCommand(query);
            Console.WriteLine("Client updated successfully");
        }

        public Client GetClientById(int var)
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Client not exist");
            }
            foreach (Client client in liste)
            {
                if (client.Code.Equals(var))
                {
                    return client;
                }
            }
            return null;

        }



    }
}