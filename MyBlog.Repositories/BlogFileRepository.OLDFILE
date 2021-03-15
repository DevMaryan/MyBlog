using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace MyBlog.Repositories
{
    public class BlogFileRepository : IBlogRepository
    {
        const string Path = "Articles.txt";

        public BlogFileRepository()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }
            var result = File.ReadAllText(Path);
            var deserializedList = JsonConvert.DeserializeObject<List<Blog>>(result);
            Articles = deserializedList;
        }


        public List<Blog> Articles { get; set; }

        // Get All Articles from the List Articles
        public List<Blog> GetAllArticles()
        {
            return Articles;
        }

        // Find Article ID 
        public Blog GetArticleById(int id)
        {
            return Articles.FirstOrDefault(x => x.Id == id);
        }
        // Create Movie
        public void CreateArticle(Blog article)
        {
            article.Id = GenerateId();
            Articles.Add(article);
            SaveChanges();

        }

        // Save the changes to file
        private void SaveChanges()
        {
            var serialized = JsonConvert.SerializeObject(Articles);
            File.WriteAllText(Path, serialized);
        }


        // Generate ID for object.id
        private int GenerateId()
        {
            var maxId = 0;
            if (Articles.Any())
            {
                maxId = Articles.Max(x => x.Id);
            }
            return maxId + 1;
        }
    }
}
