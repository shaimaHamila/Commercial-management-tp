using CONTROLLER.Controllers;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
namespace CONTROLLER
{
    public class CategoryController
    {
        public List<Category> liste = new List<Category>();
        public bool isloaded = false;
        Connection connection = new Connection();
        public void getCategories()
        {
            if (!isloaded)
            {
                Connection.connecter();
                String query = "select * from Category";
                SqlDataReader reader = Connection.ExecuteReader(query);

                while (reader.Read())
                {
                    Category category = new Category();
                    category.Codecateg = Convert.ToInt32(reader.GetValue(0));
                    category.Descateg = Convert.ToString(reader.GetValue(1));
                    liste.Add(category);
                }
                reader.Close();
                Connection.connecter().Close();
                isloaded = true;
            }
        }

        public void saveCategory(Category category)
        {
            Connection.connecter();
            SqlCommand query = new SqlCommand();

            query.CommandText = "insert into Category(descateg) values(@descateg)";
            query.CommandType = CommandType.Text;

            SqlParameter descateg = new SqlParameter("@descateg", SqlDbType.VarChar);

            descateg.Value = category.Descateg;
       
            query.Parameters.Add(descateg);
     

            Connection.ExecuteCommand(query);
            Console.WriteLine("Category Added Successfully");
        }

        public void deleteCategory(Category category)
        {
            Connection.connecter();
            SqlCommand query = new SqlCommand("delete from Category where Category.codecateg = @codecateg", Connection.connecter());
            query.Parameters.AddWithValue("@codecateg", category.Codecateg);
            Connection.ExecuteCommand(query);
            Console.WriteLine("Category deleted successfully :)");
        }

        public void UpdateCategory(Category category)
        {
            Connection.connecter();
            SqlCommand query = new SqlCommand("UPDATE Category SET descateg = @descateg WHERE codecateg = @codecateg",
                                                    Connection.connecter());

            query.Parameters.AddWithValue("@codecateg", category.Codecateg);
            query.Parameters.AddWithValue("@descateg", category.Descateg);

            Connection.ExecuteCommand(query);
            Console.WriteLine("Category updated successfully");
        }

        public Category GetCategoryById(int var)
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Category not exist");
            }
            foreach (Category category in liste)
            {
                if (category.Codecateg.Equals(var))
                {
                    return category;
                }
            }
            return null;

        }

    }
}
