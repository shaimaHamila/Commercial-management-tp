using CONTROLLER.Controllers;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using CONTROLLER;
namespace CONTROLLER
{
    internal class ArticleController
    {
        public static ClientController obje;
        public List<Article> liste = new List<Article>();
        public bool isloaded = false;
        Connection connection = new Connection();
        CategoryController categoryController = new CategoryController();
        public void getArticles()
        {
            if (!isloaded)
            {
                Connection.connecter();
                String query = "select * from Article";
                SqlDataReader reader = Connection.ExecuteReader(query);

                while (reader.Read())
                {
                    Article article = new Article();
                    article.Code = Convert.ToInt32(reader.GetValue(0));
                    article.Designation = Convert.ToString(reader.GetValue(1));
                    article.Price = Convert.ToInt32(reader.GetValue(2));
                    // Fetch category information for the article
                    int categoryCode = Convert.ToInt32(reader.GetValue(3)); // Assuming category code is stored in the fourth column
                    article.Category = categoryController.GetCategoryById(categoryCode); // Call the method to get the category by ID
                    liste.Add(article);
                }
                reader.Close();
                Connection.connecter().Close();
                isloaded = true;
            }
        }

        public void saveArticle(Article article)
        {
            // Ensure that the category is not null and has a valid ID
            if (article.Category == null || article.Category.Codecateg <= 0)
            {
                Console.WriteLine("Invalid category for the article. Please provide a valid category.");
                return;
            }
            //TODO add category 
            Connection.connecter();
            SqlCommand query = new SqlCommand();

            query.CommandText = "insert into Article(designation,price, codeCategory) values(@designation,@price, @codeCategory)";
            query.CommandType = CommandType.Text;

            SqlParameter designation = new SqlParameter("@designation", SqlDbType.VarChar);
            SqlParameter price = new SqlParameter("@price", SqlDbType.Decimal);
            SqlParameter codeCategory = new SqlParameter("@codeCategory", SqlDbType.Int);

            designation.Value = article.Designation;
            price.Value = article.Price;
            codeCategory.Value = article.Category.Codecateg;

            query.Parameters.Add(designation);
            query.Parameters.Add(price);
            query.Parameters.Add(codeCategory);

            Connection.ExecuteCommand(query);
            Console.WriteLine("Article Added Successfully");
        }

        public void deleteArticle(Article article)
        {
            Connection.connecter();
            SqlCommand query = new SqlCommand("delete from Article where Article.code = @code", Connection.connecter());
            query.Parameters.AddWithValue("@code", article.Code);
            Connection.ExecuteCommand(query);
            Console.WriteLine("Article deleted successfully :)");
        }

        public void UpdateArticle(Article article)
        {
            Connection.connecter();
            SqlCommand query = new SqlCommand("UPDATE Article SET designation = @designation, price = @price, codeCategory= @codeCategory  WHERE code = @code",
                                                    Connection.connecter());

            query.Parameters.AddWithValue("@code", article.Code);
            query.Parameters.AddWithValue("@designation", article.Designation);
            query.Parameters.AddWithValue("@price", article.Price);
            query.Parameters.AddWithValue("@codeCategory", article.Category.Codecateg);


            Connection.ExecuteCommand(query);
            Console.WriteLine("Article updated successfully");
        }

        public Article GetArticleById(int var)
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Article not exist");
            }
            foreach (Article article in liste)
            {
                if (article.Code.Equals(var))
                {
                    return article;
                }
            }
            return null;

        }
    }
}
