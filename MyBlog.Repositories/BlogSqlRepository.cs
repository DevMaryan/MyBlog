using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyBlog.Repositories
{
    public class BlogSqlRepository : IBlogRepository
    {
        public void CreateArticle(Blog article)
        {
            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyBlogSql;Trusted_Connection=True"))
            {
                cnn.Open();
                var query = @"INSERT INTO Articles(Title, ImageUrl, Author, Content, Date) VALUES (@Title, @ImageUrl, @Author, @Content, @Date)";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Title", article.Title);
                cmd.Parameters.AddWithValue("@ImageUrl", article.ImageUrl);
                cmd.Parameters.AddWithValue("@Author", article.Author);
                cmd.Parameters.AddWithValue("@Content", article.Content);
                cmd.Parameters.AddWithValue("@Date", article.Date);

                cmd.ExecuteNonQuery();

            }
        }

        public List<Blog> GetAllArticles()
        {
            var result = new List<Blog>();
            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyBlogSql;Trusted_Connection=True"))
            {
                cnn.Open();
                var query = "SELECT * FROM Articles";
                var cmd = new SqlCommand(query, cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var article = new Blog();
                    article.Id = reader.GetInt32(0);
                    article.Title = reader.GetString(1);
                    article.ImageUrl = reader.GetString(2);
                    article.Author = reader.GetString(3);
                    article.Content = reader.GetString(4);
                    article.Date = reader.GetDateTime(5);

                    result.Add(article);
                }

            }
            return result;
        }

        public Blog GetArticleById(int id)
        {
            Blog result = null;

            // Automatically will remove it from memory in case we have many connections
            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyBlogSql;Trusted_Connection=True"))
            {
                cnn.Open();
                var query = "SELECT * FROM Articles WHERE Id = @Id";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var article = new Blog();
                    article.Id = reader.GetInt32(0);
                    article.Title = reader.GetString(1);
                    article.ImageUrl = reader.GetString(2);
                    article.Author = reader.GetString(3);
                    article.Content = reader.GetString(4);
                    article.Date = reader.GetDateTime(5);
                }
            }
            return result;
        }
    }
}
