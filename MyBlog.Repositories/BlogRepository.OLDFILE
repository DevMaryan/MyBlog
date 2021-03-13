using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MyBlog.Models;

namespace MyBlog.Repositories
{
    public class BlogRepository
    {
        public List<Blog> Articles { get; set; }
        public BlogRepository()
        {
            var article1 = new Blog();
            article1.Id = 1;
            article1.Title = "Attract More Attention to Your Business Online by Improving Your Copywriting";
            article1.ImageUrl = "https://assets.entrepreneur.com/content/3x2/2000/1614894388-Ent-DigitalCopywriting.jpg?width=700&crop=2:1";
            article1.Author = "Marjan";
            article1.Content = "If you're marketing your products or services online, good copywriting is a must. Quality copywriting can be the difference between someone deciding your product isn't worth the trouble or that it's the most important thing they've ever needed in their life. It's all about perspective, and copywriting helps people get into the right perspective. It\'s easy to outsource your copywriting needs, but that can get expensive quickly. If you\'re cutting costs and want to manage your copywriting yourself, learn how to do it properly in The Premium Digital Copywriting Training Bundle.";
            article1.Date = DateTime.Now;

            var article2 = new Blog();
            article2.Id = 2;
            article2.Title = "Expand Your Skill-Set and Learn Photography and Photoshop From Professionals Who Have Worked With Marvel, Kanye, and More ";
            article2.ImageUrl = "https://assets.entrepreneur.com/content/3x2/2000/1614641879-pexels-cottonbro-3917727.jpg?width=700&crop=2:1";
            article2.Author = "Marjan";
            article2.Content = "Photoshop is one of those skills, like Excel or PowerPoint, that isn't essential in school, but becomes extremely valuable when you're in the workforce – especially if you're running your own business. Quality design is crucial for startups and established companies alike, but it can be costly. If you can handle your business's own design needs, that's a huge cost-saving measure. So, why not learn photography and Photoshop now? Whether you want to tell a story, sell a product, or just become a better photographer, this professional Photo School is available now for $199.99.";
            article2.Date = DateTime.Now;

            var article3 = new Blog();
            article3.Id = 3;
            article3.Title = "From Email to TikTok, This Digital Marketing Training Covers It All ";
            article3.ImageUrl = "https://assets.entrepreneur.com/content/3x2/2000/1614640417-solen-feyissa-XfnfMlNpWDo-unsplash.jpg?width=700&crop=2:1";
            article3.Author = "Marjan";
            article3.Content = "The world of digital marketing is constantly changing, but that's no excuse to cut back on your business's investment in digital channels, especially considering how much business is being conducted through online channels nowadays. You may not know now how to best leverage the leading digital marketing channels, but you can get a solid idea after The 2021 Complete Digital Marketing Super Bundle.";
            article3.Date = DateTime.Now;

            Articles = new List<Blog>() { article1, article2, article3 };
        }

        public List<Blog> GetAllArticles()
        {
            return Articles;
        }

        public Blog GetArticleById(int id)
        {
            return Articles.FirstOrDefault(x => x.Id == id);
        }
    }
}
